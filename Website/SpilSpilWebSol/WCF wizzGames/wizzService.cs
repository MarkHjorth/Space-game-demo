using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using wizzAppServer;
using wizzAppServer.Models;

namespace WCF_wizzGames
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class wizzService : IwizzService
    {
        private IwizzAppServer iws = new wizzServer();

        public User GetUserWeb(string email)
        {
            return iws.GetUser(email);
        }

        public string ValidateUser(string email, string password)
        {
            return iws.ValidateUser(email, password);
        }
    }
}
