using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wizzAppServer.DBmanager;
using wizzAppServer.Models;

namespace wizzAppServer
{
    public interface IwizzAppServer
    {
        User GetUser(string email);
        string ValidateUser(string mail, string password);
        string CreateUser(string name, string mail, string password);
        bool IsUserNameFree(string name);
        bool EmailFree(string email);
        bool SaveDevDescriptions(string mark, string dave);
        string GetDevDescription(string name);
        List<PlayerStats> GetAllStats();
        PlayerStats GetUserStats(string name);
    }
}
