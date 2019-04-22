using Hsj;
using Hsj.Data;


namespace NewLoginAapp.Base.MySql
{
    public class MySqlBaseDbBusi<T> : BaseDbBusi<T> where T : BaseModel, new()
    {
        public MySqlBaseDbBusi()
        {
        }

        private DbHelper _dbaHelper = null;
        protected override DbHelper DbaHelper
        {
            get
            {
                if (_dbaHelper == null)
                    _dbaHelper = new MySqlDbConnetFactory().GetDbHelper();
                return _dbaHelper;
            }
            set
            {
                _dbaHelper = value;
            }
        }
    }

}
