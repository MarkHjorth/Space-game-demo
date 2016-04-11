using UnityEngine;
using System.Collections;

public class ServiceController : MonoBehaviour {
    
    private static wizzService service;

	void Start ()
    {
        service = new wizzService();
	}

    public void SaveStats(GameSession GameSession, Stats stats)
    {
        System.DateTime startTime = GameSession.startTime;
        System.DateTime stopTime = GameSession.stopTime;
        string identifyer = GameSession.identifyer;
        int userID = GameSession.userID;
        int shotsFired = stats.ShotsFired;
        int shotsHit = stats.ShotsHit;
        int kills = stats.Kills;
        int deaths = stats.Deaths;

        service.SaveSessionAsync(userID, true, identifyer, startTime, true, stopTime, true, shotsFired, true, shotsHit, true, kills, true, deaths, true);
    }
}
