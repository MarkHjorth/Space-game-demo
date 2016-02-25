using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for userHandler
/// </summary>
public class userHandler : BaseDB
{
    public userHandler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private User getUser(string email)
    {
        try
        {
            return context.Users.Where(x => x.Email == email).FirstOrDefault();
        }
        catch
        {

            return null;
        }
    }

    public string validateUser(string mail, string pass)
    {
        try
        {
            User curUser = getUser(mail);

            if(curUser.Password == pass)
            {
                return curUser.Name;
            }
        }
        catch
        {
            return null;
        }
        return null;
    }
}