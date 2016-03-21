using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {

    private PauseController pauseController;

	void Start ()
    {
        pauseController = (PauseController)GetComponentInParent<PauseController>();
	
	}

    public void exitToMain()
    {
        Time.timeScale = 1f;
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
