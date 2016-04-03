using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    
    private GameSession GameSession;
    private Stats stats;
    private PauseController pauseController;
    public GameObject PauseMenuPrefab;

	// Use this for initialization
	void Start ()
    {
        stats = gameObject.AddComponent<Stats>() as Stats;
        pauseController = gameObject.AddComponent<PauseController>() as PauseController;
        pauseController.SetPauseMenu(PauseMenuPrefab);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void ShotsHit()
    {
        stats.ShotsHit++;
    }
    public void Kills()
    {
        stats.Kills++;
    }
    public void ShotsFired()
    {
        stats.ShotsFired++;
    }
    public void saveStats()
    {
        stats.SaveStats();
    }
}
