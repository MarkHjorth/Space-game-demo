using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace wizzAppServer.DBmanager
{
    class UserCtrl : BaseDB
    {
        public User GetUserByName(string name)
        {
            return context.Users.Where(x => x.Name == name).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public List<User> GetAllUsers()
        {
            try
            {
                List<User> allUsers = context.Users.ToList();
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
                User u = GetUserByEmail(mail);
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

        private bool ComparePass(string pass, User us)
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
