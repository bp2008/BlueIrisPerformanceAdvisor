using BlueIrisPerformanceAdvisor.Configuration;
using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueIrisPerformanceAdvisor.Advice.Items
{
	public class UseNvidiaHwvaAdvice : AdviceBase
	{
		public UseNvidiaHwvaAdvice(BlueIrisConfiguration c) : base(c, "Use Nvidia NVDEC")
		{
		}
		public override string GetDescription()
		{
			return "Nvidia NVDEC hardware acceleration may reduce your system's CPU usage. Be aware that power consumption may increase when using Nvidia NVDEC.";
		}
		public override string LearnMore()
		{
			return "An Nvidia GPU was detected in your system.  If it is NVDEC-compatible, you could reduce your CPU usage by utilizing the GPU for hardware acceleration.";
		}
		protected override void FixMe()
		{
			Logger.Info("Enabling Nvidia hardware acceleration globally.");
			RegistryUtil.SetHKLMValue(@"SOFTWARE\Perspective Software\Blue Iris\Options", "hwaccel", (int)HWAccel.NvidiaCUDA);
		}
	}
}
