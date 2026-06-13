public struct AudioPlayback // TypeDefIndex: 19122
{
	// Fields
	private CriAtomExPlayback criAtomExPlayback; 

	// Properties
	public uint PlaybackId { get; }
	public CriAtomExPlayback.Status Status { get; }
	public long Time { get; }
	public bool IsError { get; set; }
	public SoundGroup SoundGroup { get; set; }
	public bool Is3dSound { get; set; }
	public int AtomSourceListIndex { get; set; }
	public string CueSheetName { get; set; }
	public string CueName { get; set; }
	public int CueId { get; set; }

	// RVA: 0x3993E94 Offset: 0x3993E94 VA: 0x3993E94
	public bool GetNumPlayedSamples(out long numSamples, out int samplingRate) { }

	// RVA: 0x3993E9C Offset: 0x3993E9C VA: 0x3993E9C
	public bool GetFormatInfo(out CriAtomEx.FormatInfo info) { }

	// RVA: 0x3993EA4 Offset: 0x3993EA4 VA: 0x3993EA4
	public float GetLoopLengthTime() { }

	// RVA: 0x398E31C Offset: 0x398E31C VA: 0x398E31C
	public AudioPlayback(CriAtomExPlayback playback, bool isError, SoundGroup soundGroup, bool is3dSound, int atomSourceListIndex, string cueSheetName, string cueName, int cueId) { }

	// RVA: 0x398DF84 Offset: 0x398DF84 VA: 0x398DF84
	public static AudioPlayback Error(SoundGroup soundGroup) { }
}