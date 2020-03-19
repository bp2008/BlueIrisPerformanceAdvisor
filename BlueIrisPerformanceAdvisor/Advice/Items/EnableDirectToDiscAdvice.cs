using BlueIrisRegistryReader;
using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueIrisPerformanceAdvisor.Advice.Items
{
	public class EnableDirectToDiscAdvice : AdviceBase
	{
		public string cameraName;
		public int[] profiles;
		public EnableDirectToDiscAdvice(BlueIrisConfiguration c, string cameraName, int[] profiles) : base(c, "Enable Direct-to-disc")
		{
			this.cameraName = cameraName;
			this.profiles = profiles;
		}
		public override string GetDescription()
		{
			return "Direct-to-disc is not enabled in profile" + Util.s(profiles.Length) + " [" + string.Join(", ", profiles) + "] of \"" + cameraName + "\".";
		}
		public override string LearnMore()
		{
			return "Direct-to-disc is highly recommended for efficiency reasons. When using Direct-to-disc, you should make sure your camera embeds its own accurate timestamp.";
		}
		protected override void FixMe()
		{
			foreach (int profile in profiles)
			{
				Logger.Info("Enabling Direct-to-disc for \"" + cameraName + "\" profile " + profile);
				RegistryUtil.SetHKLMValue(@"SOFTWARE\Perspective Software\Blue Iris\Cameras\" + cameraName + @"\Clips\" + profile, "transcode", 0);
			}
		}
	}
}
