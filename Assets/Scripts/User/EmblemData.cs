// Íæ¼Ò³ÆºÅ

namespace Elements
{
    public class EmblemData
    {
        public int EmblemId { get; set; }
        public int ExValue { get; set; }

        public void SetEmblemId(int _emblemId) => EmblemId = _emblemId;

        public void SetExValue(int _exValue) => ExValue = _exValue;

        private void initializeEmblemData() { }

        public EmblemData() { }

        //public EmblemData(JsonData _json) { }

        //public void ParseEmblemData(JsonData _json) { }
    }
}