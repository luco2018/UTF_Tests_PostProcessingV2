Shader "Hidden/PostProcessing/Test/CustomUserData"
{
	HLSLINCLUDE

		float _Value;

		#include "../../PostProcessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);

		//float4 _MainTex_ST;
		//float4 _MainTex_TexelSize;

		float4 Frag1(VaryingsDefault i) : SV_Target
		{
			float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
			return 1 - color;
		}

		float4 Frag2(VaryingsDefault i) : SV_Target
		{
			float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
			return color * _Value;
		}

	ENDHLSL

	SubShader
	{
		Cull Off ZWrite Off ZTest Always
		
		// 0 - Custom User Data 1
		Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag1

			ENDHLSL
		}
		// 1 - Custom User Data 2
		Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag2

			ENDHLSL
		}
	}
}