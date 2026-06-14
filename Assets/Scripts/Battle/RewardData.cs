namespace Elements
{
    public class RewardData 
    {
        public int Id;
        public int Type; 
        public int Count; 
        public bool IsRare; 
        public void RewardData(int _id, int _type, int _count, bool _isRare = false)
        {
            Id = _id;
            Type = _type;
            Count = _count;
            IsRare = _isRare;
        }
    }
}