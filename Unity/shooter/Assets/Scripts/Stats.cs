using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
    Session session;
    DatabaseController dbController;

    public int ShotsFired
    {
        get;
        set;
    }

    public int ShotsHit
    {
        get;
        set;
    }

    public int Kills
    {
        get;
        set;
    }

    public int Deaths
    {
        get;
        set;
    }
       
    // Use this for initialization
	void Start()
    {
        ShotsFired = 0;
        ShotsHit = 0;
        Kills = 0;
        Deaths = 0;
        session = gameObject.AddComponent<Session>() as Session;
        dbController = gameObject.AddComponent<DatabaseController>() as DatabaseController;
        session.SetUserID(1000);
	}

    void OnApplicationQuit()
    {
        session.Stop();
        SaveStats();
    }

    void SaveStats()
    {
        dbController.SaveStats(session, this);
    }
}
