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
        public User GetUser(string email)
        {
            return context.Users.Where(x => x.Email == email).FirstOrDefault();
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
                User u = GetUser(mail);
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
    }
}
