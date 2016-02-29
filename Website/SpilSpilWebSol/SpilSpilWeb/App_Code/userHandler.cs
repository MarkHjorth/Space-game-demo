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
    private IwizzService service = new IwizzServiceClient();
    
    public userHandler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string getUser(string email)
    {
        try
        {

            return null;
        }
        catch
        {

            return null;
        }
    }

    public string validateUser(string mail, string pass)
    {
        //try
        //{
        //    User curUser = getUser(mail);

        //    if(curUser.Password == pass)
        //    {
        //        return curUser.Name;
        //    }
        //}
        //catch
        //{
        //    return null;
        //}
        return null;
    }

    public string CreateUser(string name, string mail, string password)
    {
        return service.CreateUser(name, mail, password);
    }
}