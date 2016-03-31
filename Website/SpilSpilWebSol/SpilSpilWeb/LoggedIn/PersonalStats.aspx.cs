using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoggedIn_PersonalStats : System.Web.UI.Page
{
    StatsHandler sh = new StatsHandler();

    protected void Page_Load(object sender, EventArgs e)
    {
        string playerName = HttpContext.Current.User.Identity.Name;
        stats.Rows.AddRange(sh.GetPlayerStats(playerName).ToArray());

        sessions.Rows.AddRange(sh.GetUserSessions(playerName).ToArray());
    }
}