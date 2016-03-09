using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wizzAppServer.Models
{
    class PlayerStats
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int PlayTime { get; set; }
        public int LvLReached { get; set; }
        public int ShotsFired { get; set; }
        public int ShotsHit { get; set; }
        public int Accuracy { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Kdr { get; set; }
        public int SpareProp { get; set; }

        public PlayerStats(int id)
        {
            PlayerID = id;
        }
    }
}
