using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
    public GameSession GameSession;
    public ServiceController serviceController;

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
        GameSession = gameObject.AddComponent<GameSession>() as GameSession;
        serviceController = gameObject.AddComponent<ServiceController>() as ServiceController;
	}

    void OnApplicationQuit()
    {
        SaveStats();
    }

    public void SaveStats()
    {
        GameSession.Stop();
        if(PlayerPrefs.HasKey("Userid"))
        {
            serviceController.SaveStats(GameSession, this);
        }
    }
}
