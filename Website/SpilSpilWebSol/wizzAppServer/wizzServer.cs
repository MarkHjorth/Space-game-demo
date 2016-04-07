using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wizzAppServer.Ctrls;
using wizzAppServer.DBmanager;
using wizzAppServer.Models;

namespace wizzAppServer
{
    public class wizzServer : IwizzAppServer
    {
        private UserCtrl userCtrl = new UserCtrl();
        private StatsCtrl statsCtrl = new StatsCtrl();
        private MailCtrl mc = new MailCtrl();

        //Gets the user with 'email'
        public UserModel GetUserByEmail(string email)
        {
            try
            {
                return userCtrl.GetUserByEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Gets the user with 'name'
        public UserModel GetUserByName(string name)
        {
            try
            {
                return userCtrl.GetUserByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Creates user with 'name', 'email' and 'password'
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

        //Validates the user credentials on login
        public string ValidateUser(string mail, string password)
        {
            try
            {
                return userCtrl.ValidateUser(mail, password);
            }
            catch (Exception ex) { throw ex; }
        }

        public UserModel ValidateUserCred(string mail, string password)
        {
            try
            {
                return userCtrl.ValidateUserCred(mail, password);
            }
            catch (Exception ex) { throw ex; }
        }

        //Checks if username is free
        public bool IsUserNameFree(string name)
        {
            try
            {
                return userCtrl.IsUserNameFree(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Checks if the email is free
        public bool EmailFree(string mail)
        {
            try
            {
                return userCtrl.EmailFree(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Saves description of Dev or the game
        public bool SaveDevDescriptions(string who, string desc)
        {
            try
            {
                userCtrl.SaveDevDescriptions(who, desc);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Gets description of dev or game
        public string GetDevDescription(string name)
        {
            try
            {
                return userCtrl.GetDevDescription(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Gets all the stats for the game. 
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

        //Gets the stats for a user
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

        //Gets all sessions for a user
        public List<PlayerSession> GetUserSessions(string name)
        {
            try
            {
                return statsCtrl.GetUserSessions(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveSession(int userId, string identifyer, DateTime startTime, DateTime endTime, int fired, int hits, int kills, int deaths)
        {
            statsCtrl.SaveSession(userId, identifyer, startTime, endTime, fired, hits, kills, deaths);
        }

        public bool AddNewsSubscriber(string mail)
        {
            return mc.AddNewsSubscriber(mail);
        }

        public bool ValidateEmail(string validation, string email)
        {
            return mc.ValidateEmail(validation, email);
        }
    }
}
