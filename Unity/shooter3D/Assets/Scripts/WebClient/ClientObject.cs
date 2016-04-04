using UnityEngine;
using System;
using System.Collections;

public class ClientObject : MonoBehaviour
{
    public static wizzService service;

    void Start()
    {
        service = new wizzService();

        string mail = "mark@mark.dk";
        string password = "daveIsAWizard";

        string debug = service.ValidateUser(mail, password);

        Debug.Log(debug);
    }
}