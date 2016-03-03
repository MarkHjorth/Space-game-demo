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

    void Start()
    {
        service = new wizzService();
    }

    public void createUser()
    {
        uname = input_name.text;
        mail = input_mail.text;
        password = input_pass.text;
        if (uname != "" && mail != "" && password != "")
        {
            Debug.Log(service.CreateUser(uname, mail, password));
        }
    }

    public void backToLogin()
    {
        SceneManager.LoadScene("Scenes/Login");
    }
}
