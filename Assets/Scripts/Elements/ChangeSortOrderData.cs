using System;

namespace Elements
{ 
    [Serializable]
    public class ChangeSortOrderData 
    {
        public eSortType SortType; 
        public float Time; 

        public enum eSortType 
        {
            Default = 0,
            Front = 1,
            Back = 2
        }
    }
}