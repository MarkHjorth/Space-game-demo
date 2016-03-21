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
}
