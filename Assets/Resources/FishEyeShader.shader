Shader "Unlit/FishEyeShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Theta ("Theta", Range(0, 6.28319)) = 3.14159 // 0 to 2*PI
        _Radius ("Radius", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            float _Theta; // ÉùÃ÷ _Theta
            float _Radius; // ÉùÃ÷ _Radius

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Convert UV coordinates to cylindrical projection using public properties
                float theta = (i.uv.x - 0.5) * _Theta; // use _Theta for scaling
                float radius = i.uv.y * _Radius; // use _Radius for scaling

                float x = radius * cos(theta);
                float y = radius * sin(theta);

                float2 cylindricalUV = float2(x, y);

                // If the coordinates are outside the range [0,1], make them transparent
                //if (cylindricalUV.x < 0 || cylindricalUV.x > 1 || cylindricalUV.y < 0 || cylindricalUV.y > 1)
                //{
                //    return fixed4(0, 0, 0, 0);
                //}

                fixed4 col = tex2D(_MainTex, cylindricalUV);
                return col;
            }
            ENDCG
        }
    }
}
