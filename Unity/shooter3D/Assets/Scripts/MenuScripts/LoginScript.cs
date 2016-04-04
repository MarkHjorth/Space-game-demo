using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Web.Security;

public class LoginScript : MonoBehaviour {

    public static wizzService service;
    private UserModel userModel = null;
    private string username;
    private string password;
    public InputField input_user;
    public InputField input_pass;
    public Button newUserButton;
    public Text errormessage;
    public Text loginText;

    void Start()
    {
        service = new wizzService();
        if(PlayerPrefs.HasKey("Username"))
        {
            errormessage.text = "Logged in as " + PlayerPrefs.GetString("Username", "robot overlord");
            isSignedIn(true);
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
        
        if(!PlayerPrefs.HasKey("Username"))
        {
            try
            {
                userModel = service.ValidateUserCred(username, password);

                if (userModel == null)
                {
                    errormessage.text = "Email or password incorrect!";
                    input_pass.text = "";
                }
                else
                {
                    setUserData(userModel);
                    errormessage.text = ("Welcome " + PlayerPrefs.GetString("Username", "robot overlord"));
                    isSignedIn(true);
                }
            }
            catch (System.Exception ex)
            {
                errormessage.text = ("Error! - " + ex.StackTrace);
            }
        }
        else
        {
            deleteUserData();
            isSignedIn(false);
            errormessage.text = "Successfully signed out";
        }
    }
    void isSignedIn(bool signedIn)
    {
        input_user.interactable = !signedIn;
        input_pass.interactable = !signedIn;
        newUserButton.interactable = !signedIn;
        if(signedIn)
        {
            loginText.text = "Sign out";
        } 
        else
        {
            loginText.text = "Sign in";
        }
    }
    
    void deleteUserData()
    {
        PlayerPrefs.DeleteKey("Username");
        PlayerPrefs.DeleteKey("Usermail");
        PlayerPrefs.DeleteKey("Userid");
    }
    void setUserData(UserModel userModel)
    {
        
        PlayerPrefs.SetString("Username", userModel.Name);
        PlayerPrefs.SetString("Usermail", userModel.Email);
        PlayerPrefs.SetInt("Userid", userModel.Id);
    }
    
}
