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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class wizzService : IwizzService
    {
        private IwizzAppServer iws = new wizzServer();

        public wizzService()
        { }

        public UserModel GetUserByEmail(string email)
        {
            return iws.GetUserByEmail(email);
        }

        public UserModel GetUserByName(string name)
        {
            return iws.GetUserByName(name);
        }

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

        public bool IsUserNameFree(string name)
        {
            return iws.IsUserNameFree(name);
        }

        public bool EmailFree(string mail)
        {
            return iws.EmailFree(mail);
        }

        public bool SaveDevDescriptions(string mark, string dave)
        {
            try
            {
                iws.SaveDevDescriptions(mark, dave);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
    }
}
