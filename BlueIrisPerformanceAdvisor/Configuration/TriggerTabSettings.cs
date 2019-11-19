using BPUtil;
using Microsoft.Win32;

namespace BlueIrisPerformanceAdvisor.Configuration
{
	public class TriggerTabSettings
	{
		/// <summary>
		/// If not null or empty, these settings come from another camera.  In that case, advice related to settings in this tab should not be shown, and fixes should not be performed on these settings.
		/// </summary>
		public string camsync;
		public bool motionDetectionEnabled;
		public RecordingTriggerType triggerType;

		public TriggerTabSettings(RegistryKey cameraKey, int profile)
		{
			RegistryKey motionKey = cameraKey.OpenSubKey("Motion");

			// Read settings from trigger tab.
			RegEdit trigger = new RegEdit(motionKey.OpenSubKey(profile.ToString()));

			// See if we're reading from this key or from a different one.
			int sync = trigger.DWord("sync");
			if (sync > 0)
				trigger = new RegEdit(motionKey.OpenSubKey(sync.ToString()));

			this.camsync = trigger.String("camsync");
			this.motionDetectionEnabled = trigger.DWord("enabled") == 1;
			this.triggerType = (RecordingTriggerType)trigger.DWord("continuous");
		}
	}
	public enum RecordingTriggerType : byte
	{
		Motion = 0,
		Continuous = 1,
		Periodic = 3,
		TriggeredAndPeriodic = 4,
		TriggeredAndContinuous = 5
	}
}