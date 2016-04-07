using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using wizzAppServer.DBmanager;
using wizzAppServer.Models;

namespace WCF_wizzGames
{
    // All methods commented in implementation

    [ServiceContract]
    public interface IwizzService
    {
        [OperationContract]
        UserModel GetUserByEmail(string email);

        [OperationContract]
        UserModel GetUserByName(string name);

        [OperationContract]
        string CreateUser(string name, string mail, string password);

        [OperationContract]
        string ValidateUser(string mail, string password);

        [OperationContract]
        UserModel ValidateUserCred(string email, string password);

        [OperationContract]
        bool IsUserNameFree(string name);

        [OperationContract]
        bool EmailFree(string mail);

        [OperationContract]
        bool SaveDevDescriptions(string who, string desc);

        [OperationContract]
        string GetDevDescription(string name);

        [OperationContract]
        List<PlayerStats> GetAllStats();

        [OperationContract]
        PlayerStats GetUserStats(string name);

        [OperationContract]
        List<PlayerSession> GetUserSessions(string name);

        [OperationContract]
        void SaveSession(int userId, string identifyer, DateTime startTime, DateTime endTime, int fired, int hits, int kills, int deaths);

        [OperationContract]
        bool AddNewsSubscriber(string mail);

        [OperationContract]
        bool ValidateEmail(string validation, string email);
    }
}
