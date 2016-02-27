using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using wizzAppServer.Models;

namespace WCF_wizzGames
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IwizzService
    {
        [OperationContract]
        User GetUserWeb(string email);

        [OperationContract]
        string ValidateUser(string mail, string password);

        // TODO: Add your service operations here
    }
}
