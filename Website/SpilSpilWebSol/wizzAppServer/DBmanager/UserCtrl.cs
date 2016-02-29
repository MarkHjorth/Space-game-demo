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

        public string ValidateUser(string mail, string password)
        {
            return context.Users.Where(x => x.Email == mail).FirstOrDefault().Name;
        }

        public string CreateUser(string name, string mail, string password)
        {
            try
            {
                User user = new User();
                //user.Id = 0;
                user.Name = name;
                user.Email = mail;
                user.Password = Encrypt(password);
                user.DateCreated = DateTime.Now;
                context.Users.InsertOnSubmit(user);
                context.SubmitChanges();
                return user.Name;
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        private string Encrypt(string password)
        {
            //var sha = new SHA1CryptoServiceProvider();
            //byte[] data = Encoding.ASCII.GetBytes(password);
            //byte[] bytes = sha.ComputeHash(data);
            //string pass = bytes.ToString();
            return password;
        }
    }
}
