Shader "Hidden/TwoSidedSignNode"
{
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#include "UnityCG.cginc"
			#include "Preview.cginc"
			#pragma vertex vert_img
			#pragma fragment frag

			float4 frag( v2f_img i, half ase_vface : VFACE ) : SV_Target
			{
				return ase_vface != 0 ? +1 : -1;
			}
			ENDCG
		}
	}
}
