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
        //All methods described in implementation!

        UserModel GetUserByEmail(string email);
        UserModel GetUserByName(string name);
        string ValidateUser(string mail, string password);
        UserModel ValidateUserCred(string mail, string password);
        string CreateUser(string name, string mail, string password);
        bool IsUserNameFree(string name);
        bool EmailFree(string email);
        bool SaveDevDescriptions(string who, string desc);
        string GetDevDescription(string name);
        List<PlayerStats> GetAllStats();
        PlayerStats GetUserStats(string name);
        List<PlayerSession> GetUserSessions(string name);
        void SaveSession(int userId, string identifyer, DateTime startTime, DateTime endTime, int fired, int hits, int kills, int deaths);
    }
}
