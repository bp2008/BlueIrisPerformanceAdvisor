using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace BlueIrisPerformanceAdvisor.Configuration
{
	public class GpuInfo
	{
		public string Name;
		public string DriverVersion;

		/// <summary>
		/// True if the GPU name contained "Intel" (case insensitive)
		/// </summary>
		public bool Intel;
		/// <summary>
		/// True if the GPU name contained "Nvidia" (case insensitive)
		/// </summary>
		public bool Nvidia;
		public GpuInfo()
		{
		}
		public GpuInfo(ManagementObject obj)
		{
			Name = StringUtil.DeNullify(obj["Name"]);
			DriverVersion = StringUtil.DeNullify(obj["DriverVersion"]);
			string nameLower = Name.ToLower();
			Intel = nameLower.Contains("intel");
			Nvidia = nameLower.Contains("nvidia");
		}
		public static List<GpuInfo> GetGpuInfo()
		{
			using (ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
			{

				List<GpuInfo> gpus = new List<GpuInfo>();
				foreach (ManagementObject obj in objSearcher.Get())
					if (obj != null)
						gpus.Add(new GpuInfo(obj));
				return gpus;
			}
		}
	}
}
