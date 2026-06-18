using Sqlite3Plugin;

namespace Elements.Data 
{
    public abstract class AbstractMasterDatabase 
    {
        public abstract void Unload();

        public abstract Query Query(string sql);

        protected AbstractMasterDatabase() { }
    }
}