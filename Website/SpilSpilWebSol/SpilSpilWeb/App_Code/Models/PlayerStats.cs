using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PlayerStats
{
    public int PlayerID { get; set; }
    public string Player { get; set; }
    public TimeSpan PlayTime { get; set; }
    public double LvL { get; set; }
    public double Shots { get; set; }
    public double Hits { get; set; }
    public double Accuracy { get; set; }
    public double Kills { get; set; }
    public double Deaths { get; set; }
    public double Kdr { get; set; }

    public PlayerStats(int id, string name, TimeSpan ts, double lvl, double shots, double hits, double acc, double kills, double deaths, double kdr)
    {
        PlayerID = id;
        Player = name;
        PlayTime = ts;
        LvL = lvl;
        Shots = shots;
        Hits = hits;
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
