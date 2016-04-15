using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using wizzAppServer.DBmanager;
using wizzAppServer.Models;
using SendGrid;
using System.IO;

namespace wizzAppServer.Ctrls
{
    class MailCtrl : BaseDB
    {
        Web transportWeb = new Web("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");

        public MailCtrl()
        { }

        public bool AddNewsSubscriber(string mail)
        {
            EmailSubscriber sub = new EmailSubscriber();
            UserCtrl uc = new UserCtrl();
            UserModel um = null;

            try
            {
                um = uc.GetUserByEmail(mail);
                if (um != null)
                {
                    sub.userId = um.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sub.emailAddress = mail;
            sub.validationCode = GenerateValidationCode();
            sub.addressValidated = false;
            sub.dateSubscribed = DateTime.Now;

            try
            {
                EmailSubscriber es = GetSubscriber(mail);

                if (es != null)
                {
                    return false;
                }
                context.EmailSubscribers.InsertOnSubmit(sub);
                context.SubmitChanges();
                string linkExtention = sub.validationCode;

                SendValidationEmail(linkExtention, mail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool NewUserSubscriber(string mail)
        {
            EmailSubscriber sub = new EmailSubscriber();
            UserCtrl uc = new UserCtrl();
            UserModel um = null;

            try
            {
                um = uc.GetUserByEmail(mail);
                if (um != null)
                {
                    sub.userId = um.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sub.emailAddress = mail;
            sub.validationCode = GenerateValidationCode();
            sub.addressValidated = false;
            sub.dateSubscribed = DateTime.Now;

            try
            {
                EmailSubscriber es = GetSubscriber(mail);

                if (es != null)
                {
                    return false;
                }
                context.EmailSubscribers.InsertOnSubmit(sub);
                context.SubmitChanges();
                string linkExtention = sub.validationCode;

                SendValidateUserEmail(linkExtention, mail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateEmail(string validation, string email)
        {
            bool match = false;
            EmailSubscriber sub = null;

            try
            {
                sub = context.EmailSubscribers.Where(mail => mail.emailAddress == email).FirstOrDefault();
                match = (sub.validationCode == validation);
            }
            catch (Exception)
            {

                throw;
            }

            if (match)
            {
                try
                {
                    User u = context.Users.Where(user => user.Email == email).FirstOrDefault();
                    u.validated = true;
                }
                catch (Exception)
                { }


                try
                {
                    sub.addressValidated = true;
                    context.SubmitChanges();

                    string[] param = { "wizzGames - validated email", "You email has been validated!" };

                    SendMailParam(param, email);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            return false;
        }

        private string GenerateValidationCode()
        {
            try
            {
                string code = null;

                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var random = new Random();
                code = new string(Enumerable.Repeat(chars, 10)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

                return code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Sends email to everyone on the mailing list
        public void SendNewsMail()
        {
            List<EmailSubscriber> subList = context.EmailSubscribers.ToList(); ;

            SendGridMessage mail = new SendGridMessage();

            foreach (EmailSubscriber sub in subList)
            {
                mail.AddTo(sub.emailAddress);
            }
            mail.From = new MailAddress("info@wizzgames.me", "wizzGames News");
            mail.Subject = "wizzGames info";
            mail.Text = "wizzGames";

            //TODO Add body generation

            mail.EnableTemplateEngine("d2dee1f3-b0ef-4f27-9148-47c3304d5986");

            transportWeb.DeliverAsync(mail);
        }

        internal bool SendContactMail(string uName, string uEmail, string uSubject, string uMessage)
        {
            SendGridMessage mail = new SendGridMessage();

            mail.AddTo("info@wizzgames.me");
            mail.From = new MailAddress("info@wizzgames.me", "Contact form");
            mail.Subject = "From: " + uName + ". Sub.: " + uSubject;
            mail.Text = "Message: " + uMessage;

            mail.EnableTemplateEngine("a7b4f395-65ed-4d63-98cc-663d2900db06");

            try
            {
                transportWeb.DeliverAsync(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Send an email to the spicified email address, with the parameters. 
        /// First param is the subject, second param is the email body
        /// </summary>
        public void SendMailParam(string[] param, string email)
        {
            try
            {
                SendGridMessage mail = new SendGridMessage();

                string subject = null;
                string body = null;

                if (param.Length < 1)
                {
                    subject = "wizzGames info";
                }
                else if (param.Length == 1)
                {
                    subject = param[0];
                    body = " This message seems to be empty :O";
                }
                else if (param.Length == 2)
                {
                    subject = param[0];
                    body = param[1];
                }

                mail.Subject = subject;
                mail.AddTo(email);
                mail.From = new MailAddress("info@wizzgames.me", "wizzGames News");
                mail.Text = "Hello Friend! \n\n" + body + "\n\n Best regards \nwizzGames";

                transportWeb.DeliverAsync(mail);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not send email: " + ex.Message);
            }
        }

        private void SendValidationEmail(string linkExt, string email)
        {
            try
            {
                SendGridMessage mail = new SendGridMessage();
                string link = "http://wizzgames.me/Subscribe.aspx?code=" + linkExt + "&email=" + email;
                mail.Subject = "wizzGames subscribtion";

                mail.AddTo(email);
                mail.From = new MailAddress("info@wizzgames.me", "wizzGames News");
                mail.Text = link;

                mail.EnableTemplateEngine("d2dee1f3-b0ef-4f27-9148-47c3304d5986");

                transportWeb.DeliverAsync(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SendValidateUserEmail(string linkExt, string email)
        {
            try
            {
                SendGridMessage mail = new SendGridMessage();
                string link = "http://wizzgames.me/ValidateNewUser.aspx?code=" + linkExt + "&email=" + email;
                mail.Subject = "wizzGames sign up";

                mail.AddTo(email);
                mail.From = new MailAddress("info@wizzgames.me", "wizzGames News");
                mail.Text = link;

                mail.EnableTemplateEngine("d2dee1f3-b0ef-4f27-9148-47c3304d5986");

                transportWeb.DeliverAsync(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendForgotPassEmail(string email)
        {
            string subject = "Forgotten Password - wizzgames";

            string bodyIntro = "You are trying to change your password. Please click the link to do so: ";
            string linkWizz = "http://wizzgames.me/ChangePassword.aspx?code=";
            string code = GenerateValidationCode();
            string link = linkWizz + code + "&email=" + email;

            string body = bodyIntro + link;

            string[] param = { subject, body };

            try
            {
                SendMailParam(param, email);
            }
            catch
            {
                throw new Exception("It is the email sending that is the problem.");
            }

            User u = null;

            try
            {
                u = context.Users.Where(x => x.Email == email).FirstOrDefault();
                u.ValidationCode = code;
                u.VCUpdated = DateTime.Now.AddDays(1);
            }
            catch (Exception)
            {
                throw new Exception("It is the creation of the validationcode that dosent work..");
            }

            try
            {
                //context.Users.InsertOnSubmit(u);
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("The database will not take the user with the edits: " + ex.Message);
            }
        }



        private EmailSubscriber GetSubscriber(string mail)
        {
            EmailSubscriber sub = null;
            try
            {
                sub = context.EmailSubscribers.Where(x => x.emailAddress == mail).FirstOrDefault();
                return sub;
            }
            catch
            {
                return null;
            }
        }
    }
}
