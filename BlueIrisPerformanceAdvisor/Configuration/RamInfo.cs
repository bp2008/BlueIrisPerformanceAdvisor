using BPUtil;
using System.Collections.Generic;
using System.Management;
using System.Text.RegularExpressions;

namespace BlueIrisPerformanceAdvisor.Configuration
{
	public class RamInfo
	{
		public float GiB;
		public ushort Channels;
		public ushort MHz;
		public string DimmLocations;
		public RamInfo() { }
		public RamInfo(float GiB, ushort Channels, ushort MHz, string DimmLocations)
		{
			this.GiB = GiB;
			this.Channels = Channels;
			this.MHz = MHz;
			this.DimmLocations = DimmLocations;
		}

		private static Regex rxGetChannel = new Regex("Channel(.+)-", RegexOptions.Compiled);
		public static RamInfo GetRamInfo()
		{
			List<RamInfo_Internal> dimms = new List<RamInfo_Internal>();
			using (ManagementObjectSearcher win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
			{
				foreach (ManagementObject obj in win32Memory.Get())
					if (obj != null)
						dimms.Add(new RamInfo_Internal(obj));
			}
			HashSet<string> channels = new HashSet<string>();
			long capacity = 0;
			int speed = 0;
			List<string> DimmLocations = new List<string>();
			foreach (RamInfo_Internal dimm in dimms)
			{
				DimmLocations.Add(dimm.DeviceLocator);
				Match m = rxGetChannel.Match(dimm.DeviceLocator);
				if (m.Success)
					channels.Add(m.Groups[1].Value);
				capacity += dimm.Capacity;
				if (speed == 0)
					speed = dimm.Speed;
			}
			return new RamInfo((float)NumberUtil.BytesToGiB(capacity), (ushort)channels.Count, (ushort)speed, string.Join(";", DimmLocations));
		}
	}
	class RamInfo_Internal
	{
		public long Capacity;
		public string DeviceLocator;
		public int Speed;
		public RamInfo_Internal() { }
		public RamInfo_Internal(ManagementObject obj)
		{
			Capacity = NumberUtil.ParseLong(StringUtil.DeNullify(obj["Capacity"]));
			DeviceLocator = StringUtil.DeNullify(obj["DeviceLocator"]);
			Speed = NumberUtil.ParseInt(StringUtil.DeNullify(obj["Speed"]));
			//sb.AppendLine("Bank Label: " + obj["BankLabel"]);
			//sb.AppendLine("Capacity: " + obj["Capacity"]);
			//sb.AppendLine("Data Width: " + obj["DataWidth"]);
			//sb.AppendLine("Description: " + obj["Description"]);
			//sb.AppendLine("Device Locator: " + obj["DeviceLocator"]);
			//sb.AppendLine("Form Factor: " + obj["FormFactor"]);
			//sb.AppendLine("Hot Swappable: " + obj["HotSwappable"]);
			//sb.AppendLine("Manufacturer: " + obj["Manufacturer"]);
			//sb.AppendLine("Memory Type: " + obj["MemoryType"]);
			//sb.AppendLine("Name: " + obj["Name"]);
			//sb.AppendLine("Part Number: " + obj["PartNumber"]);
			//sb.AppendLine("Position In Row: " + obj["PositionInRow"]);
			//sb.AppendLine("Speed: " + obj["Speed"]);
			//sb.AppendLine("Tag: " + obj["Tag"]);
			//sb.AppendLine("Type Detail: " + obj["TypeDetail"]);
		}
	}
}