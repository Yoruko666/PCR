namespace Cute.Cri
{
    public struct AudioPlayback
    {
        private CriAtomExPlayback criAtomExPlayback;

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

        public bool GetNumPlayedSamples(out long numSamples, out int samplingRate) { }

        public bool GetFormatInfo(out CriAtomEx.FormatInfo info) { }

        public float GetLoopLengthTime() { }

        public AudioPlayback(CriAtomExPlayback playback, bool isError, SoundGroup soundGroup, bool is3dSound, int atomSourceListIndex, string cueSheetName, string cueName, int cueId)
        {

        }

        public static AudioPlayback Error(SoundGroup soundGroup)
        {

        }
    }
}