using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Administration
/// </summary>
public class Administration
{
    private IwizzService service = new IwizzServiceClient();

    public Administration()
    {
    }

    public bool SaveChanges(string name, string desc)
    {
        try
        {
            service.SaveDevDescriptions(name, desc);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string GetDevDescription(string name)
    {
        return service.GetDevDescription(name);
    }
}