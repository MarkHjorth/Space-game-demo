using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void quitApp()
    {
        Application.Quit();
    }

    public void newGame()
    {
        SceneManager.LoadScene("Scenes/FirstLevel");
    }

    public void loadGame()
    {

    }

    public void loginScreen()
    {
        SceneManager.LoadScene("Scenes/Login");
    }
}
