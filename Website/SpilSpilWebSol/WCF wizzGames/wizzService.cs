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
                return iws.GetUserByEmail(email);
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
                return iws.GetUserByName(name);
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
                return iws.CreateUser(name, mail, password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Validates user credentials
        public string ValidateUser(string email, string password)
        {
            try
            {
                return iws.ValidateUser(email, password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
    }
}
