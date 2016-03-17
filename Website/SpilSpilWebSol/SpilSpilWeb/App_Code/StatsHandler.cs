using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for StatsHandler
/// </summary>
public class StatsHandler
{
    private IwizzServiceClient service = new IwizzServiceClient();

    public StatsHandler()
    {
    }

    public List<TableRow> GetAllStats()
    {
        List<PlayerStats> allStats = GetServiceStats();
        List<TableRow> tableList = new List<TableRow>();
        List<TableHeaderCell> thcl = GetTableHeaderRow(allStats);
        TableHeaderRow thr = new TableHeaderRow();

        thr.Cells.AddRange(thcl.ToArray());
        tableList.Add(thr);

        IEnumerable<PlayerStats> ordered = allStats.OrderByDescending(stat => stat.LvLReached);

        foreach (PlayerStats ps in ordered)
        {
            TableRow tr = new TableRow();
            foreach (PropertyInfo pi in ps.GetType().GetProperties())
            {
                TableCell tc = new TableCell();
                tc.Text = pi.GetValue(ps, null).ToString();
                tr.Cells.Add(tc);
            }
            tableList.Add(tr);
        }
        return tableList;
    }

    public List<TableRow> GetAllStats(string toSortBy)
    {
        List<PlayerStats> allStats = GetServiceStats();

        List<TableRow> tableList = new List<TableRow>();
        List<TableHeaderCell> thcl = GetTableHeaderRow(allStats);
        TableHeaderRow thr = new TableHeaderRow();

        thr.Cells.AddRange(thcl.ToArray());
        tableList.Add(thr);
        IEnumerable<PlayerStats> ordered = null;

        Object testX = null;
        try
        {
            testX = allStats.First().GetType().GetProperty(toSortBy).GetValue(allStats.First(), null);
        }
        catch (Exception) { }

        if (testX != null)
        {
            if (toSortBy == "PlayerID" || toSortBy == "PlayerName")
            {
                ordered = allStats.OrderBy(stat => stat.GetType().GetProperty(toSortBy).GetValue(stat, null));
            }
            else
            {
                ordered = allStats.OrderByDescending(stat => stat.GetType().GetProperty(toSortBy).GetValue(stat, null));
            }
        }
        else
        {
            ordered = allStats.OrderByDescending(stat => stat.LvLReached);
        }

        foreach (PlayerStats ps in ordered)
        {
            TableRow tr = new TableRow();
            foreach (PropertyInfo pi in ps.GetType().GetProperties())
            {
                TableCell tc = new TableCell();
                tc.Text = pi.GetValue(ps, null).ToString();
                tr.Cells.Add(tc);
            }
            tableList.Add(tr);
        }
        return tableList;
    }

    private List<PlayerStats> GetServiceStats()
    {
        List<PlayerStats> allStats = new List<PlayerStats>();
        try
        {
            allStats = service
                .GetAllStats()
                .Select(s => new PlayerStats()
                {
                    PlayerID = s.PlayerID,
                    PlayerName = s.PlayerName,
                    PlayTime = s.PlayTime,
                    LvLReached = s.LvLReached,
                    ShotsFired = s.ShotsFired,
                    ShotsHit = s.ShotsHit,
                    Accuracy = s.Accuracy,
                    Kills = s.Kills,
                    Deaths = s.Deaths,
                    Kdr = s.Kdr
                })
                .ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return allStats;
    }
    
    private List<TableHeaderCell> GetTableHeaderRow(List<PlayerStats> allStats)
    {
        List<TableHeaderCell> thcl = new List<TableHeaderCell>();

        foreach (PropertyInfo pi in allStats.First().GetType().GetProperties())
        {
            TableHeaderCell thc = new TableHeaderCell();

            HyperLink hl = new HyperLink()
            {
                Text = pi.Name,
                NavigateUrl = "?sortBy=" + pi.Name,
                CssClass = "thickbox",
                ToolTip = "Sort by " + pi.Name
            };
            thc.Controls.Add(hl);
            thcl.Add(thc);
        }
        return thcl;
    }

    public List<TableRow> GetPlayerStats(string name)
    {
        ServiceReference1.PlayerStats ps = service.GetUserStats(name);
        List<TableRow> tableList = new List<TableRow>();

        List<TableHeaderCell> thcl = new List<TableHeaderCell>();
        TableHeaderRow thr = new TableHeaderRow();
        foreach (PropertyInfo pi in ps.GetType().GetProperties())
        {
            TableHeaderCell thc = new TableHeaderCell();
            thc.Text = pi.Name;
            thcl.Add(thc);
        }
        thr.Cells.AddRange(thcl.ToArray());
        tableList.Add(thr);

        TableRow tr = new TableRow();
        foreach (PropertyInfo pi in ps.GetType().GetProperties())
        {
            TableCell tc = new TableCell();
            tc.Text = pi.GetValue(ps, null).ToString();
            tr.Cells.Add(tc);
        }
        tableList.Add(tr);

        return tableList;
    }

    private PlayerStats ConvertToWeb(ServiceReference1.PlayerStats sps)
    {
        return new PlayerStats(sps.PlayerID, sps.PlayerName, sps.PlayTime, sps.LvLReached, sps.ShotsFired, sps.ShotsHit, sps.Accuracy, sps.Kills, sps.Deaths, sps.Kdr);
    }
}