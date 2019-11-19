using BlueIrisPerformanceAdvisor.Configuration;
using BPUtil;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace BlueIrisPerformanceAdvisor.Configuration
{
	public class BlueIrisConfiguration
	{
		public SortedList<string, Camera> cameras = new SortedList<string, Camera>();
		public BlueIrisConfiguration()
		{
		}

		public void Load()
		{
			RegistryKey camerasKey = RegistryUtil.GetHKLMKey(@"SOFTWARE\Perspective Software\Blue Iris\Cameras");
			foreach (string camName in camerasKey.GetSubKeyNames())
				cameras.Add(camName, new Camera(camName, camerasKey.OpenSubKey(camName)));
		}
	}
}