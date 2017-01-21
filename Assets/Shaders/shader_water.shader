Shader "Custom/shader_water" 
{
	Properties
	{
		_Amplitude("Amplitude", Float) = 0.5
		_Pulsation("Pulsation", Float) = 0.5
		_Phase("Phase", Float) = 0.0
	}

		SubShader
	{
		Tags
		{
			"LightMode" = "ForwardBase"
			"ShadowSupport" = "False"
			"Queue" = "Transparent" 
			"RenderType" = "Transparent"
		}

		Pass
		{
			Cull Off

			CGPROGRAM

			#pragma enable_d3d11_debug_symbols
			#pragma vertex   main_vert
			#pragma fragment main_frag

			#include "UnityCG.cginc"

			float _Amplitude;
			float _Pulsation;
			float _Phase;

			struct v2f
			{
				float4 pos : POSITION;
				float2 tc : TEXCOORD0;
			};

			v2f main_vert(appdata_base v)
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.tc = 1.0 - v.texcoord.xy;

				return o;
			}

			fixed4 main_frag(v2f i) : SV_Target
			{
				float4 scaleX = unity_ObjectToWorld[0][0];
				float4 scaleY = unity_ObjectToWorld[1][1];

				float X = i.tc.x * scaleX;
				float Y = ((_Amplitude * sin(_Pulsation * X  + _Phase)) + 0.5f);

				if(i.tc.y > Y)
					return float4(0.0f, 0.0f, 0.0f, 0.0);
				else
					return float4(0.0, 0.0f, 1.0f, 0.5);
			}

			ENDCG
		}
	}

	FallBack "Diffuse"
}
