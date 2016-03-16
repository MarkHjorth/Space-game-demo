using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wizzAppServer.DBmanager
{
    public class BaseDB
    {
        protected DBlinqDataContext context = null;

        public BaseDB()
        {
            context = new DBlinqDataContext();
        }
    }
}
