Shader "Hidden/PostProcessing/Test/CustomSorting"
{
	HLSLINCLUDE

		#include "../../../../PostProcessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);

		//float4 _MainTex_ST;
		//float4 _MainTex_TexelSize;

		float4 Frag1(VaryingsDefault i) : SV_Target
		{
			float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
			return color * 0.5;
		}

		float4 Frag2(VaryingsDefault i) : SV_Target
		{
			float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
			return color + 0.1;
		}
		
		float4 Frag3(VaryingsDefault i) : SV_Target
		{
			float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
			return pow(color, 2);
		}

		float4 Frag4(VaryingsDefault i) : SV_Target
		{
			float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
			return smoothstep(.1, .9, color);
		}

		float4 Frag5(VaryingsDefault i) : SV_Target
		{
			float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
			return min(color, 0.75);
		}

		float4 Frag6(VaryingsDefault i) : SV_Target
		{
			float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
			return 1 - color;
		}

	ENDHLSL

	SubShader
	{
		Cull Off ZWrite Off ZTest Always
		
		// 0 - Custom Sorting 1
		Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag1

			ENDHLSL
		}
		// 1 - Custom Sorting 2
		Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag2

			ENDHLSL
		}
		// 2 - Custom Sorting 3
		Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag3

			ENDHLSL
		}
		// 3 - Custom Sorting 4
		Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag4

			ENDHLSL
		}
		// 4 - Custom Sorting 5
		Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag5

			ENDHLSL
		}
		// 5 - Custom Sorting 6
		Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag6

			ENDHLSL
		}
	}
}