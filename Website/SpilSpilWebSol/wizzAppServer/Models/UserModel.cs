using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wizzAppServer.DBmanager;
using System.Runtime.Serialization;

namespace wizzAppServer.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public DateTime DateCreated { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public List<PlayerSession> Sessions { get; set; }
        [DataMember]
        public bool Validated { get; set; }

        public UserModel(int id, string name, string email, string password, DateTime dateCreated, List<Session> sessions, bool Validated)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.DateCreated = dateCreated;
            this.Sessions = sessions.ToPlayerSession();
            this.Validated = Validated;
        }
    }
}
