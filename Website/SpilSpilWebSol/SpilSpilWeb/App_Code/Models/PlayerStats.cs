using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PlayerStats
{
    public int PlayerID { get; set; }
    public string PlayerName { get; set; }
    public TimeSpan PlayTime { get; set; }
    public double LvLReached { get; set; }
    public double ShotsFired { get; set; }
    public double ShotsHit { get; set; }
    public double Accuracy { get; set; }
    public double Kills { get; set; }
    public double Deaths { get; set; }
    public double Kdr { get; set; }

    public PlayerStats(int id, string name, TimeSpan ts, double lvl, double shots, double hits, double acc, double kills, double deaths, double kdr)
    {
        PlayerID = id;
        PlayerName = name;
        PlayTime = ts;
        LvLReached = lvl;
        ShotsFired = shots;
        ShotsHit = hits;
        Accuracy = acc;
        Kills = kills;
        Deaths = deaths;
        Kdr = kdr;
    }

    public PlayerStats(int id)
    {
        PlayerID = id;
    }

    public PlayerStats()
    {
    }
}
