using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Web.Security;

public class LoginScript : MonoBehaviour {

    public static wizzService service;
    private string username;
    private string password;
    public InputField input_user;
    public InputField input_pass;
    public Text errormessage;
    public Text loginText;

    void Start()
    {
        service = new wizzService();
        if(PlayerPrefs.HasKey("Username"))
        {
            errormessage.text = "Logged in as " + PlayerPrefs.GetString("Username", "N/A");
            input_user.interactable = false;
            input_pass.interactable = false;
            loginText.text = "Sign out";
        }
        else
        {
            loginText.text = "Sign in";
        }
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
        
        if(!PlayerPrefs.HasKey("Username"))
        {
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
                    PlayerPrefs.SetString("Username", loginName);
                    errormessage.text = ("Welcome " + loginName);
                    loginText.text = "Sign out";
                    input_user.interactable = false;
                    input_pass.interactable = false;
                }
            }
            catch (System.Exception ex)
            {
                errormessage.text = ("Error! - " + ex.StackTrace);
            }
        }
        else
        {
            PlayerPrefs.DeleteKey("Username");
            errormessage.text = "";
            input_user.interactable = true;
            input_pass.interactable = true;
        }
    }
}
