using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BaseDB
/// </summary>
public class BaseDB
{
    protected DBLinqDataContext context = null;
    public BaseDB()
    {
        context = new DBLinqDataContext();
    }
}