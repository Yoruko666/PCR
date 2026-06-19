namespace Elements.Battle.Core
{
    public abstract class UnitComponentBase 
    {
        protected readonly UnitCtrl unitController;

        public UnitComponentBase(UnitCtrl _unitController)
        {
            unitController = _unitController;
        }
    }
}