using System;
using System.IO;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

using System.Diagnostics;
using System.Collections.Generic;

namespace Gwen.Renderer
{
	public class GLShader : IDisposable
	{
		public int Program { get; set; }
		public int VertexShader { get; set; }
		public int FragmentShader { get; set; }

		private UniformDictionary _uniforms;
		public UniformDictionary Uniforms { get { return _uniforms; } set { return; } }

		public GLShader ()
		{
			this.Program = 0;
			this.VertexShader = 0;
			this.FragmentShader = 0;
		}

		public void Load (string shaderName)
		{
			Load (shaderName, shaderName);
		}

		public void Apply ()
		{
			GL.UseProgram (this.Program);
		}

		public void Load (string vertexShaderName, string fragmentShaderName)
		{
			string vSource = vShaderSource;
			string fSource = fShaderSource;

			int vShader = GL.CreateShader (ShaderType.VertexShader);
			int fShader = GL.CreateShader (ShaderType.FragmentShader);

			GL.ShaderSource (vShader, vSource);
			GL.ShaderSource (fShader, fSource);
			// Compile shaders
			GL.CompileShader (vShader);
			GL.CompileShader (fShader);
			Debug.WriteLine (GL.GetShaderInfoLog (vShader));
			Debug.WriteLine (GL.GetShaderInfoLog (fShader));

			int program = GL.CreateProgram ();
			// Link and attach shaders to program
			GL.AttachShader (program, vShader);
			GL.AttachShader (program, fShader);

			GL.LinkProgram (program);
			Debug.WriteLine (GL.GetProgramInfoLog (program));

			this.Program = program;
			this.VertexShader = vShader;
			this.FragmentShader = fShader;
			this._uniforms = new UniformDictionary (Program);
		}

	    public int GetAttributeLocation(string name)
	    {
	        int loc = GL.GetAttribLocation(Program, name);
            Debug.Assert(loc != -1);
	        return loc;
	    }

		public class UniformDictionary
		{
			private Dictionary<string, int> _data;
			private int _program;

			public UniformDictionary (int program)
			{
				_data = new Dictionary<string, int> ();
				_program = program;
			}

			public int this[string key]
			{
				get
				{
					if (!this._data.ContainsKey (key)) {
						int uniformLocation = GL.GetUniformLocation (_program, key);
						this._data.Add (key, uniformLocation);
					}

					int loc = -1;
					this._data.TryGetValue (key, out loc);

					return loc;
				}
			}
		}

		public void Dispose ()
		{
			GL.DeleteProgram (this.Program);
		}

		private const string vShaderSource = @"
#version 130

in vec2 in_screen_coords;
in vec2 in_uv;
in vec4 in_color;

out vec2 frag_uv;
out vec4 frag_color;

uniform mat4 uproj_matrix;

void main(void)
{
	frag_uv = in_uv;
	frag_color = in_color;

	vec4 pos = uproj_matrix * vec4(in_screen_coords,0.,1.);
	pos.z = 0.;

	gl_Position = pos;
}";


		private const string fShaderSource = @"
#version 130

in vec2 frag_uv;
in vec4 frag_color;

uniform sampler2D tex;

out vec4 out_frag_color;

uniform float uUseTexture = 0.0;

void main(void)
{
	vec4 texColor = texture(tex, frag_uv);
    vec4 finalColor = texColor * uUseTexture + frag_color * (1.0 - uUseTexture);
    if (finalColor.a <= 0.0)
        discard;

	out_frag_color = finalColor;
    
}";

	}
}

