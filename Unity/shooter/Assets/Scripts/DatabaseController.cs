using UnityEngine;
using System.Collections;

public class DatabaseController : MonoBehaviour {

	// Use this for initialization
    DatabaseConnection dbCon;
	void Start ()
    {
        dbCon = gameObject.AddComponent<DatabaseConnection>() as DatabaseConnection;
	}

    public void SaveStats(Session session, Stats stats)
    {
        System.DateTime startTime = session.startTime;
        System.DateTime stopTime = session.stopTime;
        string identifyer = session.identifyer;
        int userID = session.userID;
        int shotsFired = stats.ShotsFired;
        int shotsHit = stats.ShotsHit;
        int kills = stats.Kills;
        int deaths = stats.Deaths;

        string command;

        command = string.Format("INSERT INTO dmaa0914_Spec14Games_1.dbo.Sessions" +
            "(userId, identifyer, startTime, stopTime, shotsFired, shotsHit, kills, deaths)" +
            "VALUES({0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, {7});",
            userID, identifyer, startTime, stopTime, shotsFired, shotsHit, kills, deaths);

        dbCon.ExecuteStringPut(command);
    }
}
