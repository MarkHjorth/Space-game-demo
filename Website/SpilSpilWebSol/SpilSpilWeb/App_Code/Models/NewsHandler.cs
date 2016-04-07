using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceReference1;

/// <summary>
/// Summary description for NewsHandler
/// </summary>
public class NewsHandler
{
    IwizzService service = new IwizzServiceClient();

    public NewsHandler()
    {
        
    }

    public bool RegisterEmail(string mail)
    {
        try
        {
            service.AddNewsSubscriber(mail);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool ValidateEmail(string validation, string email)
    {
        try
        {
            return service.ValidateEmail(validation, email);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}