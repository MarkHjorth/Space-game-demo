using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    
    public Button loadButton;
    
    void Start()
    {
        if(PlayerPrefs.HasKey("SavedGame"))
        {
            loadButton.interactable = true;
        }
        else
        {
            loadButton.interactable = false;
        }
    }
    
    public void quitApp()
    {
        PlayerPrefs.Save();
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
