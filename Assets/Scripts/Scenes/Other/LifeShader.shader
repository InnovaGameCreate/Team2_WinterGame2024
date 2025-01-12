Shader "Unlit/LifeShader" {
    Properties {
        _MainTex ("Base Texture", 2D) = "white" {}
        _DissolveTex ("Dissolve Texture", 2D) = "white" {}
        _CutOff ("Cut Off", Range(0.0, 1.0)) = 0.5
        _Width ("Dissolve Width", Float) = 0.01
        _Color ("Main Color", Color) = (1, 1, 1, 1)
    }

    SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Transparent" }
        LOD 200

        Pass {
            Name "Dissolve"
            Cull Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _DissolveTex;
            float4 _DissolveTex_ST;

            float _CutOff;
            float _Width;
            float4 _Color;

            struct appdata {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f {
                float2 texcoord : TEXCOORD0;
                float2 dissolvecoord : TEXCOORD1;
                float4 vertex : SV_POSITION;
                UNITY_FOG_COORDS(2)
            };

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.dissolvecoord = TRANSFORM_TEX(v.texcoord, _DissolveTex);
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 baseColor = tex2D(_MainTex, i.texcoord) * _Color;
                fixed dissolveValue = Luminance(tex2D(_DissolveTex, i.dissolvecoord).rgb);

                if (dissolveValue < _CutOff) {
                    discard;
                }

                fixed alpha = smoothstep(_CutOff - _Width, _CutOff, dissolveValue);
                baseColor.a *= alpha;

                UNITY_APPLY_FOG(i.fogCoord, baseColor);
                return baseColor;
            }
            ENDCG
        }
    }

    Fallback "Diffuse"
}
