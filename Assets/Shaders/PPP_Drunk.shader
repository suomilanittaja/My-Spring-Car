Shader "Custom/PPP_Drunk"
{
    HLSLINCLUDE

        #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

        TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
        float _Amplitude;
        float _Frequency;
        float2 distortion;

        float4 _Speed;
        float4 _Size;

        float4 Frag(VaryingsDefault i) : SV_Target
        {
            float2 uv = i.texcoord;
            distortion.x = (sin((_Speed.x * _Time.y) + (uv.x * _Size.x) * _Frequency)) * _Amplitude;
            distortion.y = (cos((_Speed.y * _Time.y) + (uv.y * _Size.y) * _Frequency)) * _Amplitude;
            float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv + distortion);
            //float luminance = dot(color.rgb, float3(0.2126729, 0.7151522, 0.0721750));
            //color.rgb = lerp(color.rgb, luminance.xxx, _Blend.xxx);
            return color;
        }

    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}