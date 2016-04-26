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
    string[] exclude = { };

    public StatsHandler()
    {
    }

    public List<TableRow> GetAllStats()
    {
        List<PlayerStats> allStats = GetServiceStats();
        List<TableRow> tableList = new List<TableRow>();

        exclude = new string[] { "PlayerID" };
        List<TableHeaderCell> thcl = GetTableHeaderRow(allStats.First(), exclude);
        TableHeaderRow thr = new TableHeaderRow();

        thr.Cells.AddRange(thcl.ToArray());
        tableList.Add(thr);

        IEnumerable<PlayerStats> ordered = allStats.OrderByDescending(stat => stat.LvL);

        foreach (PlayerStats ps in ordered)
        {
            TableRow tr = new TableRow();
            foreach (PropertyInfo pi in ps.GetType().GetProperties())
            {
                if (!exclude.Contains(pi.Name))
                {
                    TableCell tc = new TableCell();
                    tc.Text = pi.GetValue(ps, null).ToString();
                    tr.Cells.Add(tc);
                }
            }
            tableList.Add(tr);
        }
        return tableList;
    }

    public List<TableRow> GetAllStats(string toSortBy)
    {
        List<PlayerStats> allStats = GetServiceStats();

        List<TableRow> tableList = new List<TableRow>();
        exclude = new string[] { "PlayerID"};
        List<TableHeaderCell> thcl = GetTableHeaderRow(allStats.First(), exclude);
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
            if (toSortBy == "PlayerID" || toSortBy == "Player")
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
            ordered = allStats.OrderByDescending(stat => stat.LvL);
        }

        foreach (PlayerStats ps in ordered)
        {
            TableRow tr = new TableRow();
            foreach (PropertyInfo pi in ps.GetType().GetProperties())
            {
                if (!exclude.Contains(pi.Name))
                {
                    TableCell tc = new TableCell();
                    tc.Text = pi.GetValue(ps, null).ToString();
                    tr.Cells.Add(tc);
                }
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
                    Player = s.PlayerName,
                    PlayTime = s.PlayTime,
                    LvL = s.LvLReached,
                    Shots = s.ShotsFired,
                    Hits = s.ShotsHit,
                    Accuracy = s.Accuracy,
                    Kills = s.Kills,
                    Deaths = s.Deaths,
                    Kdr = s.Kdr
                })
                .ToList();
        }
        catch
        {
            allStats.Add(new PlayerStats(0, "", new TimeSpan(0), 0, 0, 0, 0, 0, 0, 0));
        }
        return allStats;
    }

    private List<TableHeaderCell> GetTableHeaderRow(Object stat, string[] args)
    {
        List<TableHeaderCell> thcl = new List<TableHeaderCell>();

        foreach (PropertyInfo pi in stat.GetType().GetProperties())
        {
            if (!args.Contains(pi.Name))
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
        }
        return thcl;
    }

    public List<TableRow> GetPlayerStats(string name)
    {
        ServiceReference1.PlayerStats sps = service.GetUserStats(name);
        List<TableRow> tableList = new List<TableRow>();
        PlayerStats ps = ConvertToWeb(sps);
        exclude = new string[] { "PlayerID" };
        List<TableHeaderCell> thcl = GetTableHeaderRow(ps, exclude);
        TableHeaderRow thr = new TableHeaderRow();

        thr.Cells.AddRange(thcl.ToArray());
        tableList.Add(thr);

        TableRow tr = new TableRow();
        foreach (PropertyInfo pi in ps.GetType().GetProperties())
        {
            if (!exclude.Contains(pi.Name))
            {
                TableCell tc = new TableCell();
                tc.Text = pi.GetValue(ps, null).ToString();
                tr.Cells.Add(tc);
            }
        }
        tableList.Add(tr);

        return tableList;
    }

    public List<TableRow> GetUserSessions(string name)
    {
        List<PlayerSession> playerSessionList = GetServiceSessions(name);
        List<TableRow> tableList = new List<TableRow>();

        exclude = new string[] { "Id", "UserId", "Identifyer" };
        List<TableHeaderCell> thcl = GetTableHeaderRow(playerSessionList.First(), exclude);
        TableHeaderRow thr = new TableHeaderRow();

        thr.Cells.AddRange(thcl.ToArray());
        tableList.Add(thr);

        foreach (PlayerSession plSe in playerSessionList)
        {
            TableRow tr = new TableRow();
            foreach (PropertyInfo pi in plSe.GetType().GetProperties())
            {
                if (!exclude.Contains(pi.Name))
                {
                    TableCell tc = new TableCell();

                    tc.Text = pi.GetValue(plSe, null).ToString();
                    tr.Cells.Add(tc);
                }
            }
            tableList.Add(tr);
        }
        return tableList;
    }

    private List<PlayerSession> GetServiceSessions(string name)
    {
        List<PlayerSession> playerSessions = new List<PlayerSession>();
        try
        {
            playerSessions = service
                .GetUserSessions(name)
                .Select(s => new PlayerSession()
                {
                    Id = s.Id,
                    UserId = s.UserId,
                    Identifyer = s.Identifyer,
                    StartTime = s.StartTime,
                    StopTime = s.StopTime,
                    PlayTime = s.PlayTime,
                    Shots = s.ShotsFired,
                    Hits = s.ShotsHit,
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
        return playerSessions;
    }

    private PlayerStats ConvertToWeb(ServiceReference1.PlayerStats sps)
    {
        return new PlayerStats(sps.PlayerID, sps.PlayerName, sps.PlayTime, sps.LvLReached, sps.ShotsFired, sps.ShotsHit, sps.Accuracy, sps.Kills, sps.Deaths, sps.Kdr);
    }
}