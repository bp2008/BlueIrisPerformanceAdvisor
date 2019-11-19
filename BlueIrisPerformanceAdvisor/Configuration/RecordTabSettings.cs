using BPUtil;
using Microsoft.Win32;

namespace BlueIrisPerformanceAdvisor.Configuration
{
	public class RecordTabSettings
	{
		/// <summary>
		/// If not null or empty, these settings come from another camera.  In that case, advice related to settings in this tab should not be shown, and fixes should not be performed on these settings.
		/// </summary>
		public string camsync;
		public bool DirectToDisc;
		public RecordingFormat recordingFormat;
		/// <summary>
		/// Codec used for video clips.  May be inaccurate or unset if DirectToDisc is true.
		/// </summary>
		public string VCodec;
		public RecordTabSettings(RegistryKey cameraKey, int profile)
		{
			RegistryKey clipsKey = cameraKey.OpenSubKey("Clips");
			// Read settings from record tab.
			RegEdit record = new RegEdit(clipsKey.OpenSubKey(profile.ToString()));

			// See if we're reading from this key or from a different one.
			int sync = record.DWord("sync");
			if (sync > 0)
				record = new RegEdit(clipsKey.OpenSubKey(sync.ToString()));

			this.camsync = record.String("camsync");
			this.DirectToDisc = record.DWord("transcode") == 0;
			this.recordingFormat = (RecordingFormat)record.DWord("movieformat");
			this.VCodec = record.String("VCodec");
		}
	}
	public enum RecordingFormat : byte
	{
		AVI = 0,
		BVR = 1,
		WMV = 2,
		MP4 = 3
	}
}