using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using wizzAppServer;
using wizzAppServer.DBmanager;
using wizzAppServer.Models;

namespace WCF_wizzGames
{
    public class wizzService : IwizzService
    {
        private IwizzAppServer iws = new wizzServer();

        public wizzService()
        { }

        //Gets the user with 'email'
        public UserModel GetUserByEmail(string email)
        {
            try
            {
                UserModel um = iws.GetUserByEmail(email);
                um.Password = "This is not a password";
                return um;
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
                UserModel um = iws.GetUserByName(name);
                um.Password = "This is not a password";
                return um;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Creates a user with 'name', 'mail' and 'password'
        public string CreateUser(string name, string mail, string password)
        {
            try
            {
                if(iws.CreateUser(name, mail, password) != null)
                {
                    return iws.CreateUser(name, mail, password);
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Validates user credentials, return user name
        public string ValidateUser(string email, string password)
        {
            try
            {
                return iws.ValidateUser(email, password);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //Validates user credentials, return user
        public UserModel ValidateUserCred(string email, string password)
        {
            try
            {
                return iws.ValidateUserCred(email, password);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //Checks if username if free
        public bool IsUserNameFree(string name)
        {
            try
            {
                return iws.IsUserNameFree(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Checks if email if free
        public bool EmailFree(string mail)
        {
            try
            {
                return iws.EmailFree(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Saves description of Dev or game
        public bool SaveDevDescriptions(string who, string desc)
        {
            try
            {
                iws.SaveDevDescriptions(who, desc);
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
                return iws.GetDevDescription(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Gets all game stats
        public List<PlayerStats> GetAllStats()
        {
            try
            {
                return iws.GetAllStats();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get user stats
        public PlayerStats GetUserStats(string name)
        {
            try
            {
                return iws.GetUserStats(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Gets all users sessions
        public List<PlayerSession> GetUserSessions(string name)
        {
            try
            {
                return iws.GetUserSessions(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveSession(int userId, string identifyer, DateTime startTime, DateTime endTime, int fired, int hits, int kills, int deaths)
        {
            iws.SaveSession(userId, identifyer, startTime, endTime, fired, hits, kills, deaths);
        }
    }
}
