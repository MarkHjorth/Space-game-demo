using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using wizzAppServer.DBmanager;
using wizzAppServer.Models;

namespace wizzAppServer.Ctrls
{
    class MailCtrl : BaseDB
    {
        SmtpClient client = new SmtpClient();

        public MailCtrl()
        {
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.privateemail.com";
        }

        public bool AddNewsSubscriber(string mail)
        {
            EmailSubscriber sub = new EmailSubscriber();
            UserCtrl uc = new UserCtrl();
            UserModel um = null;
            int userId = 0;

            //try
            //{
            //    um = uc.GetUserByEmail(mail);
            //    userId = um.Id;
            //}
            //catch(Exception ex)
            //{
            //    throw ex;
            //}

            if(um != null)
            {
                sub.userId = userId;
            }
            
            sub.emailAddress = mail;
            sub.validationCode = GenerateValidationCode();
            sub.addressValidated = false;
            sub.dateSubscribed = DateTime.Now;

            context.EmailSubscribers.InsertOnSubmit(sub);
            string[] param = { sub.validationCode };
            try
            {
                SendMailParam(param, mail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateEmail(string validation, string email)
        {
            EmailSubscriber sub = context.EmailSubscribers.Where(mail => mail.emailAddress == email).FirstOrDefault();
            bool match = (sub.validationCode == validation);

            if(match)
            {
                try
                {
                    sub.addressValidated = true;

                    string[] param = { "Welcome to the newsletter", "You email has been validated! You will now recieve news from wizzGames, regularly" };

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
        public void SendMail()
        {
            //TODO: Implement sending mails:
            //WARNING: Code below is conceptual!
            List<EmailSubscriber> subList = context.EmailSubscribers.ToList(); ;

            foreach(EmailSubscriber sub in subList)
            {
                MailMessage mail = new MailMessage("info@wizzgames.me", sub.emailAddress);
                
                mail.Subject = "";
                mail.Body = "";
                client.Send(mail);
            }
        }

        /// <summary>
        /// Send an email to the spicified email address, with the parameters. 
        /// First param is the subject, second param is the email body
        /// </summary>
        private void SendMailParam(string[] param, string email)
        {
            try
            {
                MailMessage mail = new MailMessage("info@wizzgames.me", email);

                string subject = null;
                string body = null;

                if(param.Length < 1)
                {
                    subject = "wizzGames info";
                }
                else if(param.Length == 1)
                {
                    subject = param[0];
                    body = "Hello Friend! \n\n" + "This message seems to be empty :O" + "\n\n Best regards \nwizzGames";
                }
                else if(param.Length > 1)
                {
                    subject = param[0];
                    body = "Hello Friend! \n\n" + param[1] + "\n\n Best regards \nwizzGames";
                }

                mail.Subject = subject;
                mail.Body = body;

                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
