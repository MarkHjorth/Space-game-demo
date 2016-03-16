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
        aspTable.Rows.AddRange(sh.GetAllStats().ToArray());
        //aspTable.Visible = true;
    }
}