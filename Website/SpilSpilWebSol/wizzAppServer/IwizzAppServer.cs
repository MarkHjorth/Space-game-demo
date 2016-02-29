using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wizzAppServer.DBmanager;

namespace wizzAppServer
{
    public interface IwizzAppServer
    {
        User GetUser(string email);
        string ValidateUser(string mail, string password);
        string CreateUser(string name, string mail, string password);
    }
}
