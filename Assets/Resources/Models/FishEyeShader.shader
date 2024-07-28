Shader "Unlit/FishEyeShader"
{ 
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" } // Ensure transparency
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Convert UV coordinates to centered coordinates (-1 to 1 range)
                float2 centeredUV = i.uv * 2.0 - 1.0;
                float distance = length(centeredUV);

                // Mask out pixels outside the circle
                if (distance > 1.0)
                {
                    return fixed4(0, 0, 0, 0); // Transparent
                }

                // Inside the circle, sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}