using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wizzAppServer.DBmanager;

namespace wizzAppServer
{
    public class wizzServer : IwizzAppServer
    {
        private UserCtrl userCtrl = new UserCtrl();

        public User GetUser(string email)
        {
            return userCtrl.GetUser(email);
        }

        public string ValidateUser(string mail, string password)
        {
            return userCtrl.ValidateUser(mail, password);
        }
    }
}
