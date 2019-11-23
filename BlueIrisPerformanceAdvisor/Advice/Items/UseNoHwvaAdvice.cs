using BlueIrisPerformanceAdvisor.Configuration;
using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueIrisPerformanceAdvisor.Advice.Items
{
	public class UseNoHwvaAdvice : AdviceBase
	{
		public UseNoHwvaAdvice(BlueIrisConfiguration c) : base(c, "Don't enable Hardware Acceleration")
		{
		}
		public override string GetDescription()
		{
			return "No Intel or Nvidia GPUs were detected in your system, but your hardware acceleration mode was not \"None\".";
		}
		public override string LearnMore()
		{
			return "Attempting to use hardware acceleration without appropriate hardware is sloppy and may result in unexpected behavior.";
		}
		public override void FixMe()
		{
			RegistryUtil.SetHKLMValue(@"SOFTWARE\Perspective Software\Blue Iris\Options", "hwaccel", (int)HWAccel.No);
		}
	}
}
