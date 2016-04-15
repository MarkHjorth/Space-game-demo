using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using wizzAppServer.Models;
using wizzAppServer.Ctrls;

namespace wizzAppServer.DBmanager
{
    class UserCtrl : BaseDB
    {
        //Gets the user with 'name' from DB and returns a 'UserModel', based on the info
        public UserModel GetUserByName(string name)
        {
            User u = null;
            try
            {
                u = context.Users.Where(x => x.Name == name).FirstOrDefault();
            }
            catch (Exception)
            { }

            UserModel um = null;
            try
            {
                if (u != null)
                {
                    um = u.ToUserModel();
                }

                return um;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Gets the user with 'email' from DB and returns a 'UserModel', based on the info
        public UserModel GetUserByEmail(string email)
        {
            try
            {
                string lowEmail = email.ToLower();
                User u = context.Users.Where(x => x.Email == lowEmail).FirstOrDefault();
                UserModel um = u.ToUserModel();
                return um;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        //Gets all users from DB and returns a list of 'UserModel' based on the info
        public List<UserModel> GetAllUsers()
        {
            try
            {
                List<User> users = context.Users.ToList();
                List<UserModel> allUsers = new List<UserModel>();
                foreach (User u in users)
                {
                    allUsers.Add(u.ToUserModel());
                }
                return allUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Creates a 'User' with 'name', 'mail' and 'password'. Saves to DB and returns users name
        public string CreateUser(string name, string mail, string password)
        {
            string lowMail = mail.ToLower();
            try
            {
                User user = new User();
                user.Name = name;
                user.Email = lowMail;
                user.Password = Encrypt(password);
                user.DateCreated = DateTime.Now.Trim(TimeSpan.TicksPerSecond);

                if(IsUserNameFree(name) && EmailFree(lowMail))
                {
                    context.Users.InsertOnSubmit(user);
                    context.SubmitChanges();
                    MailCtrl mc = new MailCtrl();
                    mc.NewUserSubscriber(lowMail);
                    return user.Name;
                }
                else
                {
                    user = null;

                    return null;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        //Checks if the user with 'mail' and 'password' is valid. Returns user name
        public string ValidateUser(string mail, string password)
        {
            string lowMail = mail.ToLower();
            try
            {
                UserModel u = GetUserByEmail(lowMail);
                bool passFif = ComparePass(password, u);
                bool validUser = u.Validated;

                if (passFif && validUser)
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

        //Checks if the user with 'mail' and 'password' is valid. Returns user
        public UserModel ValidateUserCred(string mail, string password)
        {
            string lowMail = mail.ToLower();
            try
            {
                UserModel u = GetUserByEmail(lowMail);
                bool validUser = ComparePass(password, u);

                if (validUser)
                {
                    return u;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        //Compares the given password, 'pass' and the password from the 'UserModel', 'us'. Returns bool
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

        //Encrypts the given password 'p' with 'HetHash'. Returns encrypted password
        private string Encrypt(string p)
        {
            try
            {
                string crypted;
                crypted = p.GetHashCode().ToString();
                return crypted;
            }
            catch (Exception ex) { throw ex; }
        }

        internal bool UpdatePassword(string emailAdd, string oldPass, string newPass)
        {
            bool worked = false;
            User u = new User();

            try
            {
                u = context.Users.Where(x => x.Email == emailAdd).FirstOrDefault();

                if (oldPass.GetHashCode().ToString() == u.Password)
                {
                    u.Password = newPass.GetHashCode().ToString();
                    context.SubmitChanges();
                    worked = true;
                }
                else if(oldPass == u.ValidationCode && DateTime.Now < u.VCUpdated)
                {
                    u.Password = newPass.GetHashCode().ToString();
                    u.ValidationCode = "Code used";
                    context.SubmitChanges();
                    worked = true;
                }
                else
                {
                    u.ValidationCode = "Code expired";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return worked;
        }

        //Checks if the username 'name' exists in the database. Returns true if username is FREE
        public bool IsUserNameFree(string name)
        {
            return (GetUserByName(name) == null);
        }

        //Checks if the email 'mail' exists in the database. Returns true if email is FREE
        public bool EmailFree(string mail)
        {
            return (GetUserByEmail(mail) == null);
        }

        //Saves a description, 'desc', of a person og the game, 'who' to DB. Returns true if works
        public bool SaveDevDescriptions(string who, string desc)
        {
            try
            {
                Description description = context.Descriptions.Where(x => x.Name == who).FirstOrDefault();
                description.Description1 = desc;
                description.LastUpdated = DateTime.Now.Trim(TimeSpan.TicksPerSecond);
                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Gets and returns the description of 'name', from DB
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
