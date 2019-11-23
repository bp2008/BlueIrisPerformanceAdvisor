using BPUtil;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace BlueIrisPerformanceAdvisor.Configuration
{
	public class BIActiveStats
	{
		public string BiVersion;
		public byte CpuUsage;
		public byte BiCpuUsage;
		public int MemMB;
		public int BiMemUsageMB;
		public int BiPeakVirtualMemUsageMB;
		public int MemFreeMB;
		public float RamGiB;
		public ushort RamChannels;
		public string DimmLocations;
		public ushort RamMHz;
		public bool ConsoleOpen;
		public short ConsoleWidth = -1;
		public short ConsoleHeight = -1;

		public void Load()
		{
			ComputerInfo computerInfo = new ComputerInfo();
			MemMB = (int)(computerInfo.TotalPhysicalMemory / 1000000);
			MemFreeMB = (int)(computerInfo.AvailablePhysicalMemory / 1000000);

			using (PerformanceCounter totalCpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
			{
				totalCpuCounter.NextValue();
				Stopwatch sw = new Stopwatch();
				sw.Start();
				List<Process> biProcs = Process.GetProcesses().Where(p => p.ProcessName.ToLower() == "blueiris").ToList();
				if (biProcs.Count < 1)
				{
					Logger.Info("Unable to calculate BI Active Stats because Blue Iris is not running.");
					return;
				}
				TimeSpan[] startTimes = new TimeSpan[biProcs.Count];
				for (int i = 0; i < biProcs.Count; i++)
				{
					startTimes[i] = biProcs[i].TotalProcessorTime;
				}

				// Wait for CPU usage to happen.
				Thread.Sleep(1000);

				// Take CPU usage measurements.
				CpuUsage = (byte)Math.Round(totalCpuCounter.NextValue());
				sw.Stop();
				TimeSpan totalTime = TimeSpan.Zero;
				for (int i = 0; i < biProcs.Count; i++)
				{
					biProcs[i].Refresh();
					if (biProcs[i].HasExited)
					{
						Logger.Info("Unable to calculate BI Active Stats Blue Iris exited while CPU usage was being measured.");
						return;
					}
					totalTime += biProcs[i].TotalProcessorTime - startTimes[i];
				}
				double fraction = totalTime.TotalMilliseconds / sw.Elapsed.TotalMilliseconds;
				BiCpuUsage = (byte)Math.Round((fraction / Environment.ProcessorCount) * 100);
				// Done with CPU usage

				long physicalMemUsage = 0;
				long virtualMemUsage = 0;
				foreach (Process p in biProcs)
				{
					if (BiVersion == null)
						BiVersion = p.MainModule.FileVersionInfo.FileVersion + " " + (Is64Bit(p) ? "x64" : "x86");
					physicalMemUsage += p.WorkingSet64;
					virtualMemUsage += p.VirtualMemorySize64;
				}
				BiMemUsageMB = (int)(physicalMemUsage / 1000000);
				BiPeakVirtualMemUsageMB = (int)(virtualMemUsage / 1000000);
				// Done with MEM usage

				foreach (Process p in biProcs)
				{
					IntPtr handle = p.MainWindowHandle;
					if (handle == IntPtr.Zero)
					{
						// This is the service.
					}
					else
					{
						// This is the console.
						ConsoleOpen = true;
						try
						{
							WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
							if (GetWindowPlacement(handle, ref placement))
							{
								if (placement.showCmd == 2)
								{
									// Minimized
									ConsoleWidth = -2;
									ConsoleHeight = -2;
								}
								else
								{
									// Not Minimized
									RECT Rect = new RECT();
									if (GetWindowRect(handle, ref Rect))
									{
										ConsoleWidth = (short)NumberUtil.Clamp(Rect.right - Rect.left, 0, short.MaxValue);
										ConsoleHeight = (short)NumberUtil.Clamp(Rect.bottom - Rect.top, 0, short.MaxValue);
									}
								}
							}
						}
						catch (Exception ex)
						{
							Logger.Debug(ex);
						}
					}
				}
				if (biProcs.Count > 1 && !ConsoleOpen)
					ConsoleOpen = true;
			}
		}
		public static bool Is64Bit(Process p)
		{
			if (!Environment.Is64BitOperatingSystem)
				return false;

			bool isWow64;
			if (!IsWow64Process(p.Handle, out isWow64))
				throw new Win32Exception("IsWow64Process call returned false");
			return !isWow64;
		}
		[DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

		private struct WINDOWPLACEMENT
		{
			public int length;
			public int flags;
			public int showCmd;
			public System.Drawing.Point ptMinPosition;
			public System.Drawing.Point ptMaxPosition;
			public System.Drawing.Rectangle rcNormalPosition;
		}
	}
}