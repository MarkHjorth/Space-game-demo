using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    public bool gameIsPaused = false;
    private GameObject PauseMenu;

	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp("escape"))
        {
            pauseGame();
        }
	
	}
    
    public void SetPauseMenu(GameObject pauseMenu)
    {
        PauseMenu = pauseMenu;
    }

    public void pauseGame()
    {
        gameIsPaused = !gameIsPaused;

        if (gameIsPaused == false)
        {
            DestroyObject(gameObject.transform.FindChild("pauseMenu(Clone)").gameObject);
            Time.timeScale = 1f;
        }
        else if (gameIsPaused == true)
        {
            GameObject pauseMenu = Instantiate(PauseMenu) as GameObject;
            pauseMenu.transform.parent = gameObject.transform;
            Time.timeScale = 0f;
        }
    }

    public void exitToMain()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void continueGame()
    {
        pauseGame();
    }

    public void saveGame()
    {
    }

    public void loadGame()
    {
    }
}
