using BPUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueIrisPerformanceAdvisor
{
	static class Program
	{
		public static AdvisorSettings settings;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			Globals.Initialize(exePath);
			PrivateAccessor.SetStaticFieldValue(typeof(Globals), "errorFilePath", Globals.WritableDirectoryBase + "Advisor_Log.txt");

			FileInfo fiExe = new FileInfo(exePath);
			Environment.CurrentDirectory = fiExe.Directory.FullName;

			settings = new AdvisorSettings();
			settings.Load();
			if (string.IsNullOrWhiteSpace(settings.secret))
			{
				settings.secret = Hash.GetSHA256Hex(Guid.NewGuid().ToString());
				settings.Save();
			}
			settings.SaveIfNoExist();

			RegistryUtil.Force32BitRegistryAccess = settings.bi32OnWin64;

			AutoFixBad32BitSetting();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		private static void AutoFixBad32BitSetting()
		{
			if (Environment.Is64BitOperatingSystem)
			{
				// This is a 64 bit OS, so it is possible that our bi32OnWin64 setting is wrong.
				if (RegistryUtil.GetHKLMKey(@"SOFTWARE\Perspective Software\Blue Iris") == null)
				{
					// No BI detected. Try the opposite setting.
					RegistryUtil.Force32BitRegistryAccess = !RegistryUtil.Force32BitRegistryAccess;
					if (RegistryUtil.GetHKLMKey(@"SOFTWARE\Perspective Software\Blue Iris") == null)
						RegistryUtil.Force32BitRegistryAccess = !RegistryUtil.Force32BitRegistryAccess; // No BI detected. Revert setting.
					else
					{
						// Found BI using the opposite setting.  Save the setting.
						settings.bi32OnWin64 = RegistryUtil.Force32BitRegistryAccess;
						settings.Save();
					}
				}
			}
		}
	}
}
