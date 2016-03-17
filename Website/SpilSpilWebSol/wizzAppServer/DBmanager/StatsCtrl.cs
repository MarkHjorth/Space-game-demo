using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wizzAppServer.Models;

namespace wizzAppServer.DBmanager
{
    public class StatsCtrl : BaseDB
    {
        UserCtrl uctrl = new UserCtrl();

        public StatsCtrl()
        {

        }

        public List<PlayerStats> GetAllStats()
        {
            try
            {
                List<PlayerStats> allStats = new List<PlayerStats>();
                List<UserModel> users = new List<UserModel>();
                PlayerStats ps = new PlayerStats();

                users = uctrl.GetAllUsers();

                foreach (UserModel um in users)
                {
                    ps = GetUserStats(um.Name);
                    allStats.Add(ps);
                }
                allStats.OrderByDescending(stat => stat.LvLReached);
                return allStats;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PlayerStats GetUserStats(string name)
        {
            List<Session> userSessions = new List<Session>();
            PlayerStats stats = new PlayerStats(name);
            stats.PlayerName = name;
            stats.PlayerID = uctrl.GetUserByName(name).Id;
            userSessions = context.Sessions.Where(x => x.userId == stats.PlayerID).ToList();

            foreach (Session s in userSessions)
            {
                stats.PlayTime += (TimeSpan)(s.stopTime - s.startTime);
                stats.ShotsFired += s.shotsFired;
                stats.ShotsHit += s.shotsHit;
                stats.Kills += s.kills;
                stats.Deaths += s.deaths;
            }
            stats.Accuracy = GetAccuracy(stats.ShotsFired, stats.ShotsHit);
            stats.Kdr = GetKillDeathRatio(stats.Kills, stats.Deaths);
            stats.LvLReached = GetLevelReached(stats.Accuracy, stats.Kdr);

            return stats;
        }

        private double GetAccuracy(double fired, double hit)
        {
            if(fired == 0)
            {
                fired = 1;
            }

            double acc = (hit / fired * 100);
            acc = Math.Round(acc, 2);
            return acc;
        }

        private double GetKillDeathRatio(double kills, double deaths)
        {
            if(deaths == 0)
            {
                deaths = 1;
            }

            if (kills == 0)
            {
                kills = 1;
            }

            double kdr = (kills / deaths);
            kdr = Math.Round(kdr, 2);
            return kdr;
        }

        private double GetLevelReached(double accuracy, double kdr)
        {
            double lvl = (accuracy * kdr);
            lvl = Math.Round(lvl);
            return lvl;
        }
    }
}
