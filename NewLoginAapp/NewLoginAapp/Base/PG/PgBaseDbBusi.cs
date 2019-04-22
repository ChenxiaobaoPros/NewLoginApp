using Hsj;
using Hsj.Data;
using NewLoginAapp.Base.PG;

namespace NewLoginAapp.Base.PG
{
    public class PgBaseDbBusi<T> : BaseDbBusi<T> where T : BaseModel, new()
    {
        public PgBaseDbBusi()
        {
        }

        private DbHelper _dbaHelper = null;
        protected override DbHelper DbaHelper
        {
            get
            {
                if (_dbaHelper == null)
                    _dbaHelper = new PgDbConnetFactory().GetDbHelper();
                return _dbaHelper;
            }
            set
            {
                _dbaHelper = value;
            }
        }
    }

}
