using Hsj;
using Hsj.Data;
using NewLoginAapp.Base.SQLite;

namespace NewLoginAapp.Base.SQLite
{
    public class SQLiteBaseDbBusi<T> : BaseDbBusi<T> where T : BaseModel, new()
    {
        public SQLiteBaseDbBusi()
        {
        }

        private DbHelper _dbaHelper = null;
        protected override DbHelper DbaHelper
        {
            get
            {
                if (_dbaHelper == null)
                    _dbaHelper = new SQLiteDbConnetFactory().GetDbHelper();
                return _dbaHelper;
            }
            set
            {
                _dbaHelper = value;
            }
        }
    }

}
