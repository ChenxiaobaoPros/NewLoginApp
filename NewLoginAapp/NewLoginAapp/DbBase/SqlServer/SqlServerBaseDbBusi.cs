using Hsj;
using Hsj.Data;
using NewLoginAapp.Base.SqlServer;

namespace NewLoginAapp.Base.SqlServer
{
    public class SqlServerBaseDbBusi<T> : BaseDbBusi<T> where T : BaseModel, new()
    {
        public SqlServerBaseDbBusi()
        {
        }

        private DbHelper _dbaHelper = null;
        protected override DbHelper DbaHelper
        {
            get
            {
                if (_dbaHelper == null)
                    _dbaHelper = new SqlServerDbConnetFactory().GetDbHelper();
                return _dbaHelper;
            }
            set
            {
                _dbaHelper = value;
            }
        }
    }

}
