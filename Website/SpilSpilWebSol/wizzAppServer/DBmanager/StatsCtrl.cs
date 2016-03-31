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
        {}

        //Gets all the statistiks from all players, and returns a list of stats
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

        //Gets all sessions from the user 'name' and creates one PlayerStats object, with the gathered information
        public PlayerStats GetUserStats(string name)
        {
            List<Session> userSessions = new List<Session>();
            PlayerStats stats = new PlayerStats(name);
            stats.PlayerName = name;
            stats.PlayerID = uctrl.GetUserByName(name).Id;
            try
            {
                userSessions = context.Sessions.Where(x => x.userId == stats.PlayerID).ToList();

                foreach (Session s in userSessions)
                {
                    stats.PlayTime += (TimeSpan)(s.stopTime - s.startTime);
                    stats.ShotsFired += s.shotsFired;
                    stats.ShotsHit += s.shotsHit;
                    stats.Kills += s.kills;
                    stats.Deaths += s.deaths;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            stats.Accuracy = GetAccuracy(stats.ShotsFired, stats.ShotsHit);
            stats.Kdr = GetKillDeathRatio(stats.Kills, stats.Deaths);
            stats.LvLReached = GetLevelReached(stats.Accuracy, stats.Kdr);

            return stats;
        }

        //Gets all the sessions for the user 'name', and returns a list of the sessions
        public List<PlayerSession> GetUserSessions(string name)
        {
            List<PlayerSession> plSesList = new List<PlayerSession>();
            try
            {
                User u = context.Users.Where(user => user.Name == name).FirstOrDefault();
                List<Session> sesList = context.Sessions.Where(x => x.userId == u.Id).ToList();
                plSesList = new List<PlayerSession>();

                foreach (Session s in sesList)
                {
                    PlayerSession ps = new PlayerSession(s.id, s.userId, s.identifyer, s.startTime, s.stopTime, s.shotsFired, s.shotsHit, s.kills, s.deaths);
                    ps.PlayTime = (ps.StopTime - ps.StartTime);
                    ps.Accuracy = GetAccuracy(ps.ShotsFired, ps.ShotsHit);
                    ps.Kdr = GetKillDeathRatio(ps.Kills, ps.Deaths);
                    plSesList.Add(ps);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return plSesList;
        }

        //Calculates the accuracy, based on the shots fired and shots hit
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

        //Calculates Kill / Death ratio based on kills and deaths (KDR is kills pr. death)
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

        //Calculates and returns the level reached (the accuracy multiplied with the KDR)
        private double GetLevelReached(double accuracy, double kdr)
        {
            double lvl = (accuracy * kdr);
            lvl = Math.Round(lvl);
            return lvl;
        }
    }
}
