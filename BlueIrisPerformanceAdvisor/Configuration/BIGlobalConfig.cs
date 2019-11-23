using BPUtil;
using System;
using System.Text;

namespace BlueIrisPerformanceAdvisor.Configuration
{
	public class BIGlobalConfig
	{
		public HWAccel HardwareAcceleration;
		public bool ServiceMode;
		/// <summary>
		/// Live preview frame rate. -1 if unknown. -2 if not limited.
		/// </summary>
		public int LivePreviewFPS = -1;

		public void Load()
		{
			RegEdit options = new RegEdit(RegistryUtil.GetHKLMKey(@"SOFTWARE\Perspective Software\Blue Iris\Options"));
			HardwareAcceleration = (HWAccel)options.DWord("hwaccel");
			ServiceMode = options.DWord("service") == 1;
			if (options.DWord("limitlive") == 0)
				LivePreviewFPS = -2;
			else
				LivePreviewFPS = RegistryUtil.GetHKLMValue<int>(@"SOFTWARE\Perspective Software\Blue Iris\Options", "livefps", -1);
		}
	}
	public enum HWAccel : byte
	{
		No = 0,
		Intel = 1,
		IntelVPP = 2,
		NvidiaCUDA = 3
	}
}