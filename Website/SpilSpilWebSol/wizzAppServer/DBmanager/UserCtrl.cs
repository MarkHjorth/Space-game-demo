using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wizzAppServer.DBmanager
{
    class UserCtrl : BaseDB
    {
        public User GetUser(string email)
        {
            return context.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public string ValidateUser(string mail, string password)
        {
            return context.Users.Where(x => x.Email == mail).FirstOrDefault().Name;
        }
    }
}
