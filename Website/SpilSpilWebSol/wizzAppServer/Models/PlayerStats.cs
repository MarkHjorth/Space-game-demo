using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace wizzAppServer.Models
{
    [DataContract]
    public class PlayerStats
    {
        [DataMember]
        public int PlayerID { get; set; }

        [DataMember]
        public string PlayerName { get; set; }

        [DataMember]
        public TimeSpan PlayTime { get; set; }

        [DataMember]
        public double LvLReached { get; set; }

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

        public PlayerStats()
        {}

        public PlayerStats(int id)
        {
            PlayerID = id;
        }

        public PlayerStats(string name)
        {
            PlayerName = name;
        }

        public PlayerStats(int id, string name)
        {
            PlayerID = id;
            PlayerName = name;
        }
    }
}
