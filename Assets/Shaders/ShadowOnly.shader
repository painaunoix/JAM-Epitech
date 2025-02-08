Shader "Custom/ShadowOnly"
{
    SubShader
    {
        Tags {"Queue"="Geometry"}
        Pass
        {
            ColorMask 0
            ZWrite On
        }
    }
}
