using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wizzAppServer.Models
{
    [DataContract]
    public class PlayerSession
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Identifyer { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime StopTime { get; set; }
        [DataMember]
        public TimeSpan PlayTime { get; set; }
        [DataMember]
        public double ShotsFired { get; set; }
        [DataMember]
        public double ShotsHit { get; set; }
        [DataMember]
        public double Accuracy { get; set; }
        [DataMember]
        public double Kills { get; set; }
        [DataMember]
        public double Deaths { get; set; }
        [DataMember]
        public double Kdr { get; set; }

        public PlayerSession(int id, int userId, string identifyer, DateTime start, DateTime stop, int fired, int hit, int kills, int deaths)
        {
            Id = id;
            UserId = userId;
            Identifyer = identifyer;
            StartTime = start;
            StopTime = stop;
            ShotsFired = fired;
            ShotsHit = hit;
            Kills = kills;
            Deaths = deaths;
        }
    }
}
