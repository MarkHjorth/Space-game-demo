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
    public Text errormessage;

    void Start()
    {
        service = new wizzService();
    }

    public void backToMain()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void newUser()
    {
        SceneManager.LoadScene("Scenes/NewUser");
    }

    public void login()
    {
        username = input_user.text;
        password = input_pass.text;
        string loginName = "No user found!";

        try
        {
            loginName = service.ValidateUser(username, password);

            if (loginName.Equals("No user found!"))
            {
                errormessage.text = "Email or password incorrect!";
                input_user.text = "";
                input_pass.text = "";
            }
            else
            {
                errormessage.text = ("Welcome " + loginName);
            }
        }
        catch (System.Exception ex)
        {
            errormessage.text = ("Error! - " + ex.StackTrace);
        }
    }
}
