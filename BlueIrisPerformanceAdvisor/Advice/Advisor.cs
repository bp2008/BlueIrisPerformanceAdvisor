using BlueIrisPerformanceAdvisor.Advice.Items;
using BlueIrisPerformanceAdvisor.Configuration;
using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueIrisPerformanceAdvisor.Advice
{
	public class Advisor
	{
		Thread thrAdviceGenerator = null;

		public event EventHandler<List<AdviceBase>> AdviceReady = delegate { };

		public Advisor()
		{
		}

		/// <summary>
		/// Begins generating advice for how to improve Blue Iris configuration.  The AdviceReady event will be raised when this is done, so you should listen to that event before generating advice.
		/// </summary>
		public void GenerateAdvice()
		{
			if (thrAdviceGenerator != null)
				return;

			thrAdviceGenerator = new Thread(AdviceThread);
			thrAdviceGenerator.Name = "Advice Generator";
			thrAdviceGenerator.IsBackground = true;
			thrAdviceGenerator.Start();
		}

		private void AdviceThread()
		{
			try
			{
				BlueIrisConfiguration c = new BlueIrisConfiguration();
				c.Load();

				List<AdviceBase> listAdvice = new List<AdviceBase>();

				foreach (Camera cam in c.cameras.Values)
				{
					if (cam.Type == CameraType.Network)
					{
						List<int> profilesWithDirectToDiscDisabled = new List<int>();
						for (int profile = 1; profile < cam.recordSettings.Length; profile++)
						{
							RecordTabSettings recordSettings = cam.recordSettings[profile];
							if (string.IsNullOrEmpty(recordSettings.camsync))
							{
								// We only care about settings that are not automatically copied from another camera.
								if (!recordSettings.DirectToDisc)
									profilesWithDirectToDiscDisabled.Add(profile);
							}
						}

						if (profilesWithDirectToDiscDisabled.Count > 0)
						{
							listAdvice.Add(new EnableDirectToDiscAdvice(c, cam.name, profilesWithDirectToDiscDisabled.ToArray()));
						}
					}
				}

				bool hasIntelGPU = c.gpus.Any(gpu => gpu.Intel);
				bool hasNvidiaGPU = c.gpus.Any(gpu => gpu.Nvidia);
				if (hasIntelGPU)
				{
					if (c.global.HardwareAcceleration == HWAccel.Intel)
					{
						// Good!
					}
					else if (c.global.HardwareAcceleration == HWAccel.IntelVPP && c.cameras.Count > 4)
						listAdvice.Add(new DontUseVPPAdvice(c));
					else
						listAdvice.Add(new UseIntelHwvaAdvice(c));
				}
				else if (hasNvidiaGPU)
				{
					if (c.global.HardwareAcceleration == HWAccel.Intel || c.global.HardwareAcceleration == HWAccel.IntelVPP)
						listAdvice.Add(new UseNvidiaHwvaAdvice(c));
					else if (c.global.HardwareAcceleration == HWAccel.No && c.activeStats.BiCpuUsage > 50)
						listAdvice.Add(new UseNvidiaHwvaAdvice(c));
				}
				else
				{
					if (c.global.HardwareAcceleration != HWAccel.No)
						listAdvice.Add(new UseNoHwvaAdvice(c));
				}

				AdviceReady(this, listAdvice);
			}
			catch (ThreadAbortException) { }
			catch (Exception ex)
			{
				Logger.Debug(ex);
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
