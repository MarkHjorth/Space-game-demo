using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewUserScript : MonoBehaviour {

    public static wizzService service;
    private string uname;
    private string mail;
    private string password;
    public InputField input_name;
    public InputField input_mail;
    public InputField input_pass;
    public Text errormessage;

    void Start()
    {
        service = new wizzService();
    }

    public void createUser()
    {
        uname = input_name.text;
        mail = input_mail.text;
        password = input_pass.text;
        string user = "";
        if (uname != "" && mail != "" && password != "")
        {

            try
            {
                user = service.CreateUser(uname, mail, password);
            }
            catch (System.Exception ex)
            {
                errormessage.text = ("Error! - " + ex.StackTrace);
            }
            if (user.Equals(uname))
            {
                errormessage.text = "User created successfully!";
                input_name.text = "";
                input_mail.text = "";
                input_pass.text = "";
            }
            else
            {
                errormessage.text = "An unknown error occurred! Please try again later.";
            }
        }
        else
        {
            errormessage.text = "Please fill out all fields.";
        }
    }

    public void backToLogin()
    {
        SceneManager.LoadScene("Scenes/Login");
    }
    
}
