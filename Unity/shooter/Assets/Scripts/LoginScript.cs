using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoginScript : MonoBehaviour {

    public static wizzService service;
    private string username;
    private string password;
    public InputField input_user;
    public InputField input_pass;

    void Start()
    {
        service = new wizzService();
    }

    public void backToMain()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void login()
    {
        username = input_user.text;
        password = input_pass.text;

        service.ValidateUser(username, password);
    }
}
