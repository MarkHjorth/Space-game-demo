using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wizzAppServer.DBmanager;
using wizzAppServer.Models;

namespace wizzAppServer
{
    public class wizzServer : IwizzAppServer
    {
        private UserCtrl userCtrl = new UserCtrl();
        private StatsCtrl statsCtrl = new StatsCtrl();

        public UserModel GetUserByEmail(string email)
        {
            return userCtrl.GetUserByEmail(email);
        }

        public UserModel GetUserByName(string name)
        {
            return userCtrl.GetUserByName(name);
        }

        public string CreateUser(string name, string mail, string password)
        {
            try
            {
                return userCtrl.CreateUser(name, mail, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ValidateUser(string mail, string password)
        {
            try
            {
                return userCtrl.ValidateUser(mail, password);
            }
            catch (Exception ex) { throw ex; }
        }

        public bool IsUserNameFree(string name)
        {
            return userCtrl.IsUserNameFree(name);
        }

        public bool EmailFree(string mail)
        {
            return userCtrl.EmailFree(mail);
        }

        public bool SaveDevDescriptions(string mark, string dave)
        {
            try
            {
                userCtrl.SaveDevDescriptions(mark, dave);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDevDescription(string name)
        {
            return userCtrl.GetDevDescription(name);
        }

        public List<PlayerStats> GetAllStats()
        {
            List<PlayerStats> allStats = new List<PlayerStats>();

            try
            {
                allStats = statsCtrl.GetAllStats();
                return allStats;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public PlayerStats GetUserStats(string name)
        {
            try
            {
                return statsCtrl.GetUserStats(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
