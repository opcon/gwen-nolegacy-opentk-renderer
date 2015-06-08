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
    
}