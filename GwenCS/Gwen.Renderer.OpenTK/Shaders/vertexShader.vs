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
}