using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceReference1;

/// <summary>
/// Summary description for userHandler
/// </summary>
public class userHandler
{
    //private static wizzService service = new wizzService();
    private IwizzService service = new IwizzServiceClient();

    public userHandler()
    {}

    private ServiceReference1.User GetUser(string email)
    {
        try
        {
            return service.GetUserWeb(email);
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public string validateUser(string mail, string pass)
    {
        try
        {
            return service.ValidateUser(mail, pass);
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public string CreateUser(string name, string mail, string password)
    {

        try
        {
            return service.CreateUser(name, mail, password);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}