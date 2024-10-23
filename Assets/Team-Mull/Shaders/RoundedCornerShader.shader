Shader "Unlit/RoundedCornerShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _CornerRadius ("Corner Radius", Range(0.0,1.0)) = 0.2
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Back
            ZWrite Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _CornerRadius;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float2 uv = i.uv * 2.0 - 1.0; // Transform UV to [-1, 1]
                float r = _CornerRadius;

                // Calculate distance from corners
                float2 dist = max(abs(uv) - (1.0 - r), 0.0);
                float alpha = 1.0 - step(0.0, dist.x) * step(0.0, dist.y);
                col.a *= alpha; // Modify alpha based on distance to corners

                return col;
            }
            ENDCG
        }
    }
}
