using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PlayerSessions
/// </summary>
public class PlayerSession
{
    
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Identifyer { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime StopTime { get; set; }
    public TimeSpan PlayTime { get; set; }
    public double Shots { get; set; }
    public double Hits { get; set; }
    public double Accuracy { get; set; }
    public double Kills { get; set; }
    public double Deaths { get; set; }
    public double Kdr { get; set; }

    public PlayerSession()
    {
    }
}