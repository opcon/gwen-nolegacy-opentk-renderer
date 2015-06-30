using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using QuickFont;

namespace Gwen.Renderer
{
    class StringCache
    {
        private Dictionary<PrintedTextKey, CacheValueContainer> _levelOneCache;
        private Dictionary<PrintedTextKey, CacheValueContainer> _levelTwoCache;
        private Dictionary<Tuple<string, Font>, Point> _measurementCache; 

        public int LevelOneStartHealth = 10;
        public int LevelOneHealthIncrease = 2;
        public int LevelTwoMinHealth = 2000;

        public int TotalCount {get { return _levelOneCache.Count + _levelTwoCache.Count; }}
        public int LevelOneCount {get { return _levelOneCache.Count; }}
        public int LevelTwoCount {get { return _levelTwoCache.Count; }}

        public StringCache()
        {
            _levelOneCache = new Dictionary<PrintedTextKey, CacheValueContainer>();
            _levelTwoCache = new Dictionary<PrintedTextKey, CacheValueContainer>();
            _measurementCache = new Dictionary<Tuple<string, Font>, Point>();
        }

        public void Update(double time)
        {
            var keysToRemove = new List<PrintedTextKey>();
            var keysToPromote = new List<PrintedTextKey>();
            foreach (var kvp in _levelOneCache)
            {
                kvp.Value.Health--;
                if (kvp.Value.Health <= 0) keysToRemove.Add(kvp.Key); 
                else if (kvp.Value.Health >= LevelTwoMinHealth) keysToPromote.Add(kvp.Key);
            }
            foreach (var k in keysToRemove)
            {
                _levelOneCache.Remove(k);
            }
            foreach (var k in keysToPromote)
            {
                _levelTwoCache.Add(k, _levelOneCache[k]);
                _levelOneCache.Remove(k);
            }
        }

        public void Clear()
        {
            _levelOneCache.Clear();
            _levelTwoCache.Clear();
        }

        public void Remove(PrintedTextKey key)
        {
            _levelOneCache.Remove(key);
            _levelTwoCache.Remove(key);
        }

        public void Remove(string text)
        {
            var keys = _levelOneCache.Where(kv => string.Equals(kv.Key.Text, text)).Select(k => k.Key).ToArray();
            foreach (var k in keys)
            {
                _levelOneCache.Remove(k);
            }
            keys = _levelTwoCache.Where(kv => string.Equals(kv.Key.Text, text)).Select(k => k.Key).ToArray();
            foreach (var k in keys)
            {
                _levelTwoCache.Remove(k);
            }
        }

        public void Remove(string text, Color color)
        {
            var keys = _levelOneCache.Where(kv => string.Equals(kv.Key.Text, text) && kv.Key.Color == color).Select(k => k.Key).ToArray();
            foreach (var k in keys)
            {
                _levelOneCache.Remove(k);
            }
            keys = _levelTwoCache.Where(kv => string.Equals(kv.Key.Text, text) && kv.Key.Color == color).Select(k => k.Key).ToArray();
            foreach (var k in keys)
            {
                _levelTwoCache.Remove(k);
            }
        }

        public bool Contains(PrintedTextKey key)
        {
            return LevelTwoContains(key) || LevelOneContains(key);
        }

        public bool Contains(string text, Font font)
        {
            return LevelTwoContains(text, font) || LevelOneContains(text, font) ;
        }

        private bool LevelOneContains(PrintedTextKey key)
        {
            return _levelOneCache.ContainsKey(key);
        }

        private bool LevelOneContains(string text, Font font)
        {
            return _levelOneCache.Any(kvp => kvp.Key.Text == text && kvp.Key.Font == font);
        }

        private bool LevelTwoContains(PrintedTextKey key)
        {
            return _levelTwoCache.ContainsKey(key);
        }

        private bool LevelTwoContains(string text, Font font)
        {
            return _levelTwoCache.Any(kvp => kvp.Key.Text == text && kvp.Key.Font == font);
        }

        public QFontDrawingPrimitive First(string text, Font font)
        {
            return LevelTwoContains(text, font)
                ? _levelTwoCache.First(kvp => kvp.Key.Text == text && kvp.Key.Font == font).Value.DrawingPrimitive
                : _levelOneCache.First(kvp => kvp.Key.Text == text && kvp.Key.Font == font).Value.DrawingPrimitive;
        }

        public QFontDrawingPrimitive this[PrintedTextKey key]
        {
            get
            {
                CacheValueContainer value;
                if (_levelTwoCache.ContainsKey(key))
                    value = _levelTwoCache[key];
                else
                {
                    value = _levelOneCache[key];
                    value.Health += LevelOneHealthIncrease;
                }
                return value.DrawingPrimitive;
            }
            set
            {
                if (_levelTwoCache.ContainsKey(key))
                    _levelTwoCache[key].DrawingPrimitive = value;
                else if (_levelOneCache.ContainsKey(key))
                    _levelOneCache[key].DrawingPrimitive = value;
                else
                    _levelOneCache.Add(key, new CacheValueContainer {DrawingPrimitive = value, Health = LevelOneStartHealth});
            }
        }

        public void AddMeasurement(string text, Font font, Point point)
        {
            _measurementCache.Add(new Tuple<string, Font>(text, font), point);
        }

        public bool GetMeasurement(string text, Font font, out Point size)
        {
            return _measurementCache.TryGetValue(new Tuple<string, Font>(text, font), out size);
        }

        private class CacheValueContainer
        {
            public QFontDrawingPrimitive DrawingPrimitive;
            public int Health;

            public override string ToString()
            {
                return Health.ToString();
            }
        }
    }
}
