using BlueIrisPerformanceAdvisor.Configuration;
using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueIrisPerformanceAdvisor.Advice.Items
{
	public class DontUseVPPAdvice : AdviceBase
	{
		public DontUseVPPAdvice(BlueIrisConfiguration c) : base(c, "Don't use VideoPostProc")
		{
		}
		public override string GetDescription()
		{
			return "Hardware acceleration mode Intel+VideoPostProc may harm performance compared to regular Intel hardware acceleration.";
		}
		public override string LearnMore()
		{
			return GetDescription() + Environment.NewLine + Environment.NewLine + "This message was shown because you have more than a few cameras and have VideoPostProc enabled by default";
		}
		public override void FixMe()
		{
			RegistryUtil.SetHKLMValue(@"SOFTWARE\Perspective Software\Blue Iris\Options", "hwaccel", (int)HWAccel.Intel);
		}
	}
}
