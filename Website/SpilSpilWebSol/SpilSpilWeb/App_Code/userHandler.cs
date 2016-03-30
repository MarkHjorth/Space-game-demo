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
    {}

    private WebUser GetUserByEmail(string email)
    {
        WebUser wu = new WebUser();
        try
        {
            UserModel um = service.GetUserByName(email);

            wu.Id = um.Id;
            wu.Name = um.Name;
            wu.Email = um.Email;
            wu.Password = um.Password;
            wu.DateCreated = um.DateCreated;

            return wu;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public WebUser GetUserByName(string name)
    {
        WebUser wu = new WebUser();
        try
        {
            UserModel um;
            using (IwizzServiceClient cl = new IwizzServiceClient())
            {
                um = cl.GetUserByName(name);
            }

            //UserModel um2 = service.GetUserByName(name);
            wu.Id = um.Id;
            wu.Name = um.Name;
            wu.Email = um.Email;
            wu.Password = um.Password;
            wu.DateCreated = um.DateCreated;

            return wu;
        }
        catch (Exception ex)
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

    public bool IsUserNameFree(string name)
    {
        return service.IsUserNameFree(name);
    }

    public bool EmailFree(string mail)
    {
        return service.EmailFree(mail);
    }
}