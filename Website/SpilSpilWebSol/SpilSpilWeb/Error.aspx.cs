using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Application_Error(object sender, EventArgs e)
    {
        // Get the error details
        HttpException lastErrorWrapper = Server.GetLastError() as HttpException;

        Exception lastError = lastErrorWrapper;
        if (lastErrorWrapper.InnerException != null)
            lastError = lastErrorWrapper.InnerException;

        string lastErrorTypeName = lastError.GetType().ToString();
        string lastErrorMessage = lastError.Message;
        string lastErrorStackTrace = lastError.StackTrace;

        stack.InnerHtml = lastErrorMessage;
    }
}