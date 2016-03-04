using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using wizzAppServer;
using wizzAppServer.DBmanager;

namespace WCF_wizzGames
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class wizzService : IwizzService
    {
        private IwizzAppServer iws = new wizzServer();

        public wizzService()
        { }

        public User GetUserWeb(string email)
        {
            return iws.GetUser(email);
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
    }
}
