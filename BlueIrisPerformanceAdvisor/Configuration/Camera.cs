using BPUtil;
using Microsoft.Win32;
using System;

namespace BlueIrisPerformanceAdvisor.Configuration
{
	public class Camera
	{
		public string name;
		public string shortname;
		public bool enabled;
		/// <summary>
		/// Max rate (max FPS)
		/// </summary>
		public double MaxRate;
		/// <summary>
		/// Applicable only if Type is Network.
		/// </summary>
		public HWAccelCamera Hwva;
		/// <summary>
		/// Type of ScreenCapture camera, applicable only if Type is ScreenCapture.
		/// </summary>
		public ScreenCapType CapType;
		/// <summary>
		/// Type of camera
		/// </summary>
		public CameraType Type;
		public bool LimitDecode;
		public int WidthPx;
		public int HeightPx;
		public int Pixels;

		/// <summary>
		/// An array of record tab settings for each profile (1-7).  Ignore the item at index 0.
		/// </summary>
		public RecordTabSettings[] recordSettings = new RecordTabSettings[8];
		/// <summary>
		/// An array of trigger tab settings for each profile (1-7).  Ignore the item at index 0.
		/// </summary>
		public TriggerTabSettings[] triggerSettings = new TriggerTabSettings[8];

		public Camera(string name, RegistryKey cameraKey)
		{
			this.name = name;

			RegEdit camera = new RegEdit(cameraKey);
			this.shortname = camera.String("shortname");
			this.enabled = camera.DWord("enabled") == 1;
			this.MaxRate = NumberUtil.Clamp(Math.Round(10000000.0 / camera.DWord("interval")), 0, 255);
			this.CapType = (ScreenCapType)camera.DWord("screencap");
			this.Hwva = (HWAccelCamera)camera.DWord("ip_hwaccel");
			this.LimitDecode = camera.DWord("smartdecode") == 1;
			this.WidthPx = camera.DWord("fullxres");
			this.HeightPx = camera.DWord("fullyres");
			this.Pixels = this.WidthPx * this.HeightPx;
			this.Type = (CameraType)camera.DWord("type");

			// Read profile-specific configurations
			for (int i = 1; i <= 7; i++)
			{
				recordSettings[i] = new RecordTabSettings(cameraKey, i);
				triggerSettings[i] = new TriggerTabSettings(cameraKey, i);
			}
		}
	}
	public enum CameraType : byte
	{
		ScreenCapture = 0,
		USBFirewireAnalog = 2,
		Network = 4,
		ClientBroadcast = 5
	}
	public enum ScreenCapType : byte
	{
		UScreenCapture = 0,
		DirectDrawBlits = 1,
		Blackness = 2
	}
	public enum HWAccelCamera : byte
	{
		Default = 0,
		Intel = 1,
		No = 2,
		IntelVPP = 3,
		NvidiaCUDA = 4
	}
}