using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Scoreboards : System.Web.UI.Page
{
    StatsHandler sh = new StatsHandler();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["sortBy"] != null)
        {
            aspTable.Rows.AddRange(sh.GetAllStats(Request.QueryString["sortBy"]).ToArray());
        }
        else
        {
            aspTable.Rows.AddRange(sh.GetAllStats().ToArray());
        }
    }
}