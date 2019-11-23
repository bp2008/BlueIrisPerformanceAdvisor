using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace BlueIrisPerformanceAdvisor.Configuration
{
	public class CpuInfo
	{
		public string clockSpeed, maxClockSpeed, procName, manufacturer, version;
		public int cpuThreads;
		/// <summary>
		/// Max clock speed in MHz.
		/// </summary>
		public int cpuMHz;
		public CpuInfo(ManagementObject obj)
		{
			maxClockSpeed = StringUtil.DeNullify(obj["MaxClockSpeed"]);
			clockSpeed = StringUtil.DeNullify(obj["CurrentClockSpeed"]);
			procName = StringUtil.DeNullify(obj["Name"]);
			manufacturer = StringUtil.DeNullify(obj["Manufacturer"]);
			version = StringUtil.DeNullify(obj["Version"]);

			cpuThreads = Environment.ProcessorCount;
			cpuMHz = NumberUtil.ParseInt(maxClockSpeed);
		}
		public string GetModel()
		{
			if (!string.IsNullOrWhiteSpace(procName))
				return procName;
			else if (!string.IsNullOrWhiteSpace("version"))
				return manufacturer + " " + version;
			else
				return manufacturer;
		}
		public override string ToString()
		{
			return GetModel() + " (" + maxClockSpeed + "MHz)";
		}
		public static CpuInfo GetCpuInfo()
		{
			// win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem")
			using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"))
			{
				foreach (ManagementObject obj in win32Proc.Get())
				{
					if (obj != null)
					{
						CpuInfo info = new CpuInfo(obj);
						return info;
					}
				}
			}
			return null;
		}
	}
}
