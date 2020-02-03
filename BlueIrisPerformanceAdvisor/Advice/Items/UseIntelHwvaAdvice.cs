using BlueIrisPerformanceAdvisor.Configuration;
using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueIrisPerformanceAdvisor.Advice.Items
{
	public class UseIntelHwvaAdvice : AdviceBase
	{
		public UseIntelHwvaAdvice(BlueIrisConfiguration c) : base(c, "Use Intel Quick Sync")
		{
		}
		public override string GetDescription()
		{
			return "An Intel GPU was detected in your system. It is recommended to use Intel hardware acceleration along with H.264 cameras for reduced CPU and energy usage.";
		}
		public override string LearnMore()
		{
			return GetDescription() + Environment.NewLine + Environment.NewLine + "To use Intel Quick Sync acceleration properly in Blue Iris, your IP cameras must encode their video streams using the H.264 codec.";
		}
		protected override void FixMe()
		{
			Logger.Info("Enabling Intel hardware acceleration globally.");
			RegistryUtil.SetHKLMValue(@"SOFTWARE\Perspective Software\Blue Iris\Options", "hwaccel", (int)HWAccel.Intel);
		}
	}
}
