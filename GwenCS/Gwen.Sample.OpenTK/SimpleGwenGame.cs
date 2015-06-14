using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics;
using System.Drawing;
using Gwen.Control;
using Gwen.Renderer;

namespace Gwen.Sample.OpenTK
{
	/// <summary>
	/// Demonstrates the GameWindow class.
	/// </summary>
	public class SimpleWindow : GameWindow
	{
		private Gwen.Input.OpenTK input;
		private Gwen.Renderer.OpenTK renderer;
		private Gwen.Skin.Base skin;
		private Gwen.Control.Canvas canvas;
		private UnitTest.UnitTest test;

		const int fps_frames = 50;
		private readonly List<long> ftime;
		private readonly Stopwatch stopwatch;
		private long lastTime;
		private bool altDown = false;

	    private Matrix4 _projectionMatrix;

		public SimpleWindow()
			: base (1024, 768, new GraphicsMode (), "gwen OpenTK Renderer", GameWindowFlags.Default, DisplayDevice.Default, 4, 3, GraphicsContextFlags.Default)
		{
			Keyboard.KeyDown += Keyboard_KeyDown;
			Keyboard.KeyUp += Keyboard_KeyUp;

			Mouse.ButtonDown += Mouse_ButtonDown;
			Mouse.ButtonUp += Mouse_ButtonUp;
			Mouse.Move += Mouse_Move;
			Mouse.WheelChanged += Mouse_Wheel;

			ftime = new List<long>(fps_frames);
			stopwatch = new Stopwatch();
		}

		public override void Dispose()
		{
			canvas.Dispose();
			skin.Dispose();
			renderer.Dispose();
			base.Dispose();
		}

		/// <summary>
		/// Occurs when a key is pressed.
		/// </summary>
		/// <param name="sender">The KeyboardDevice which generated this event.</param>
		/// <param name="e">The key that was pressed.</param>
		void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
		{
			if (e.Key == global::OpenTK.Input.Key.Escape)
				Exit();
			else if (e.Key == global::OpenTK.Input.Key.AltLeft)
				altDown = true;
			else if (altDown && e.Key == global::OpenTK.Input.Key.Enter)
				if (WindowState == WindowState.Fullscreen)
					WindowState = WindowState.Normal;
				else
					WindowState = WindowState.Fullscreen;

			input.ProcessKeyDown(e);
		}

		void Keyboard_KeyUp(object sender, KeyboardKeyEventArgs e)
		{
			altDown = false;
			input.ProcessKeyUp(e);
		}

		void Mouse_ButtonDown(object sender, MouseButtonEventArgs args)
		{
			input.ProcessMouseMessage(args);
		}

		void Mouse_ButtonUp(object sender, MouseButtonEventArgs args)
		{
			input.ProcessMouseMessage(args);
		}

		void Mouse_Move(object sender, MouseMoveEventArgs args)
		{
			input.ProcessMouseMessage(args);
		}

		void Mouse_Wheel(object sender, MouseWheelEventArgs args)
		{
			input.ProcessMouseMessage(args);
		}

		/// <summary>
		/// Setup OpenGL and load resources here.
		/// </summary>
		/// <param name="e">Not used.</param>
		protected override void OnLoad(EventArgs e)
		{
			GL.ClearColor(Color.MidnightBlue);

			renderer = new Gwen.Renderer.OpenTK();
			skin = new Gwen.Skin.TexturedBase(renderer, "DefaultSkin.png");

			skin.DefaultFont = new Font(renderer, "Arial", 10);
			canvas = new Canvas(skin);

			input = new Input.OpenTK(this);
			input.Initialize(canvas);

			canvas.SetSize (1024, 768);
			canvas.ShouldDrawBackground = true;
			canvas.BackgroundColor = Color.FromArgb(255, 150, 170, 170);
			//canvas.KeyboardInputEnabled = true;

			test = new UnitTest.UnitTest(canvas);

			stopwatch.Restart();
			lastTime = 0;
		}

		/// <summary>
		/// Respond to resize events here.
		/// </summary>
		/// <param name="e">Contains information on the new GameWindow size.</param>
		/// <remarks>There is no need to call the base implementation.</remarks>
		protected override void OnResize(EventArgs e)
		{
		    _projectionMatrix = Matrix4.CreateOrthographic(Width, Height, -1.0f, 1.0f);

		    _projectionMatrix = Matrix4.Mult(Matrix4.CreateScale(new Vector3(1, -1, 1)), _projectionMatrix);
		    _projectionMatrix = Matrix4.Mult(Matrix4.CreateTranslation(new Vector3(-Width / 2.0f, -Height / 2.0f, 0)), _projectionMatrix);

            //renderer.Resize (Width, Height);
            renderer.Resize(ref _projectionMatrix, Width, Height);

			canvas.SetSize(Width, Height);
		}

		/// <summary>
		/// Add your game logic here.
		/// </summary>
		/// <param name="e">Contains timing information.</param>
		/// <remarks>There is no need to call the base implementation.</remarks>
		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			totalTime += (float)e.Time;
			if (ftime.Count == fps_frames)
				ftime.RemoveAt(0);

			ftime.Add(stopwatch.ElapsedMilliseconds - lastTime);
			lastTime = stopwatch.ElapsedMilliseconds;


			if (stopwatch.ElapsedMilliseconds > 1000)
			{
				//Debug.WriteLine (String.Format ("String Cache size: {0} Draw Calls: {1} Vertex Count: {2}", renderer.TextCacheSize, renderer.DrawCallCount, renderer.VertexCount));
				test.Note = String.Format("String Cache size: {0} Draw Calls: {1} Vertex Count: {2}", renderer.TextCacheSize, renderer.DrawCallCount, renderer.VertexCount);
				test.Fps = 1000f * ftime.Count / ftime.Sum();

				float ft = 1000 * (float)e.Time;

				stopwatch.Restart();

				if (renderer.TextCacheSize > 1000) // each cached string is an allocated texture, flush the cache once in a while in your real project
					renderer.FlushTextCache();
			}
		}

		/// <summary>
		/// Add your game rendering code here.
		/// </summary>
		/// <param name="e">Contains timing information.</param>
		/// <remarks>There is no need to call the base implementation.</remarks>
		float totalTime = 0f;
		protected override void OnRenderFrame(FrameEventArgs e)
		{
			GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
			
			canvas.RenderCanvas ();

			SwapBuffers();
		}

		/// <summary>
		/// Entry point of this example.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			using (SimpleWindow example = new SimpleWindow())
			{
				example.Title = "Gwen-DotNet OpenTK test";
				example.VSync = VSyncMode.Off; // to measure performance
				example.Run(0.0, 0.0);
				//example.TargetRenderFrequency = 60;
			}
		}
	}
}
