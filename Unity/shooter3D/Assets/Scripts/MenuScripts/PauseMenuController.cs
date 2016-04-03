using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {

    private PauseController pauseController;
    private GameController gameController;

	void Start ()
    {
        pauseController = (PauseController)GetComponentInParent<PauseController>();
        gameController = (GameController) GameObject.FindGameObjectWithTag("GameController").GetComponent(typeof(GameController));
	
	}

    public void exitToMain()
    {
        Time.timeScale = 1f;
        gameController.saveStats();
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void continueGame()
    {
        pauseController.pauseGame();
        Destroy(gameObject);
    }

    public void saveGame()
    {
        //Time.timeScale = 1f;
    }

    public void loadGame()
    {
        //Time.timeScale = 1f;
    }
}
