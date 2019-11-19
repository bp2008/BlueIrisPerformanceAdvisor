using BPUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlueIrisPerformanceAdvisor
{
	public class AdvisorSettings : SerializableObjectBase
	{
		public bool bi32OnWin64 = false;
		public string secret = "";
		public long lastUsageReportAt = 0;

		/// <summary>
		/// Returns the absolute path to the RegistryBackups folder, not including trailing Path.DirectorySeparatorChar.  This method will also create that directory if it does not exist.
		/// </summary>
		/// <returns></returns>
		public static string GetRegistryBackupLocation()
		{
			FileInfo fiExe = new FileInfo(Assembly.GetExecutingAssembly().Location);
			string path = fiExe.Directory.FullName.TrimEnd('\\', '/') + Path.DirectorySeparatorChar + "RegistryBackups";
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
			return path;
		}
	}
}
