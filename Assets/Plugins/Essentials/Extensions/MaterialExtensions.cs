using UnityEngine;

using BlendMode = UnityEngine.Rendering.BlendMode;
using RenderQueue = UnityEngine.Rendering.RenderQueue;

namespace Essentials {

	public enum StandartMaterialRenderMode {
		Opaque,
		Cutout,
		Fade,
		Transparent
	}

	public static class MaterialExtensions {

		private readonly static string ModeKey = "_Mode";
		private readonly static string SrcBlendKey = "_SrcBlend";
		private readonly static string DstBlendKey = "_DstBlend";
		private readonly static string ZWriteKey = "_ZWrite";
		private readonly static string AlphatestKey = "_ALPHATEST_ON";
		private readonly static string AlphablendKey = "_ALPHABLEND_ON";
		private readonly static string AlphapremultiplyKey = "_ALPHAPREMULTIPLY_ON";

		private readonly static int[] RenderQueues = new int[] {
			(int) RenderQueue.Geometry, (int) RenderQueue.AlphaTest,
			(int) RenderQueue.Transparent, (int) RenderQueue.Transparent
		};

		public static void SetStandartMaterialMode(this Material origin, StandartMaterialRenderMode mode) {
			bool opaqueOrCutout = mode == StandartMaterialRenderMode.Opaque || mode == StandartMaterialRenderMode.Cutout;

			origin.SetFloat(ModeKey, (int) mode);
			origin.SetInt(SrcBlendKey, opaqueOrCutout ? (int) BlendMode.One : (int) BlendMode.SrcAlpha);
			origin.SetInt(DstBlendKey, opaqueOrCutout ? (int) BlendMode.Zero : (int) BlendMode.OneMinusSrcAlpha);
			origin.SetInt(ZWriteKey, opaqueOrCutout ? 1 : 0);

			if (mode == StandartMaterialRenderMode.Cutout)
				origin.EnableKeyword(AlphatestKey);
			else
				origin.DisableKeyword(AlphatestKey);

			if (opaqueOrCutout)
				origin.DisableKeyword(AlphablendKey);
			else
				origin.EnableKeyword(AlphablendKey);

			origin.DisableKeyword(AlphapremultiplyKey);

			origin.renderQueue = RenderQueues[(int) mode];
		}
	}
}