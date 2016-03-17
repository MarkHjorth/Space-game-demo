using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using wizzAppServer.Models;

namespace wizzAppServer.DBmanager
{
    class UserCtrl : BaseDB
    {
        public UserModel GetUserByName(string name)
        {
            User u = context.Users.Where(x => x.Name == name).FirstOrDefault();
            UserModel um = new UserModel(u.Id, u.Name, u.Email, u.Password, u.DateCreated, u.Sessions);
            return um;
        }

        public UserModel GetUserByEmail(string email)
        {
            User u = context.Users.Where(x => x.Email == email).FirstOrDefault();
            UserModel um = new UserModel(u.Id, u.Name, u.Email, u.Password, u.DateCreated, u.Sessions);
            return um;
        }

        public List<UserModel> GetAllUsers()
        {
            try
            {
                List<User> users = context.Users.ToList();
                List<UserModel> allUsers = new List<UserModel>();
                foreach (User u in users)
                {
                    allUsers.Add(new UserModel(u.Id, u.Name, u.Email, u.Password, u.DateCreated, u.Sessions));
                }
                return allUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreateUser(string name, string mail, string password)
        {
            try
            {
                User user = new User();
                user.Name = name;
                user.Email = mail;
                user.Password = Encrypt(password);
                user.DateCreated = DateTime.Now;
                context.Users.InsertOnSubmit(user);
                context.SubmitChanges();
                return user.Name;
            }
            catch (Exception ex) { throw ex; }
        }

        public string ValidateUser(string mail, string password)
        {
            try
            {
                UserModel u = GetUserByEmail(mail);
                bool validUser = ComparePass(password, u);

                if (validUser)
                {
                    return u.Name;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool ComparePass(string pass, UserModel us)
        {
            try
            {
                string cryptPass = Encrypt(pass);

                if (us.Password == cryptPass)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        private string Encrypt(string p)
        {
            try
            {
                string crypted;
                crypted = p.GetHashCode().ToString();
                return crypted;
            }
            catch (Exception ex){throw ex;}
        }

        public bool IsUserNameFree(string name)
        {
            return (GetUserByName(name) == null);
        }

        public bool EmailFree(string mail)
        {
            return (GetUserByEmail(mail) == null);
        }

        public bool SaveDevDescriptions(string mark, string dave)
        {
            try
            {
                Description descMark = context.Descriptions.Where(x => x.Name == "Mark").FirstOrDefault();
                descMark.Description1 = mark;
                descMark.LastUpdated = DateTime.Now;

                Description descDave = context.Descriptions.Where(x => x.Name == "David").FirstOrDefault();
                descDave.Description1 = dave;
                descDave.LastUpdated = DateTime.Now;

                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDevDescription(string name)
        {
            try
            {
                Description des = context.Descriptions.Where(x => x.Name == name).FirstOrDefault();
                return des.Description1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
