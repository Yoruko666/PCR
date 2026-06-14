namespace Elements
{
    public class StaticSingletonTree<TOwnerClass> : SingletonTree<TOwnerClass> 
    {
        protected StaticSingletonTree() { }
        protected override void setupTree() { }
        public static StaticSingletonTree<TOwnerClass> Create() { }
        private void setupAcnTempdata(SingletonNode _rootNode, AcnTempData _acnTemp) { }
    }
}