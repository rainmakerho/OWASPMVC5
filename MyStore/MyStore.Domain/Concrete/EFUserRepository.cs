using MyStore.Domain.Abstract;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        private EmailSettings emailSettings;
        public EFUserRepository(EmailSettings settings)
        {
            this.emailSettings = settings;
        }

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public User DeleteUser(int userID)
        {
            var dbEntity = context.Users.Find(userID);
            if (dbEntity != null)
            {
                context.Users.Remove(dbEntity);
                context.SaveChanges();
            }
            return dbEntity;
        }

        public void SaveUser(User user)
        {
            if (user.UserID == 0)
            {
                var dbEntity = context.Users.FirstOrDefault(u=> string.Compare(u.Email, user.Email, StringComparison.InvariantCultureIgnoreCase) == 0);
                if (dbEntity != null)
                {
                    throw  new Exception("Email already exists. Please enter a different address.");
                }
                context.Users.Add(user);
            }
            else
            {
                var dbEntity = context.Users.Find(user.UserID);
                if (dbEntity != null)
                {
                    dbEntity.Email = user.Email;
                    dbEntity.Password = user.Password;
                    dbEntity.FirstName = user.FirstName;
                    dbEntity.LastName = user.LastName;
                }
            }
            context.SaveChanges();
        }

        public User GetUserFromResetToken(string token)
        {
            var user = context.Users
                .FirstOrDefault(u => u.Token.Equals(token)
                );
            // add time duration check
            //&& (DateTime.Now - u.TokenCreTime.Value).TotalHours < 4
            return user;
        }

        public void NotifyUser(string email, string subject, string body)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSSL;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod =
                        SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                var mailMessage = new MailMessage(
                                emailSettings.MailFromAddress,
                                email,
                                subject,
                                body
                        );
                mailMessage.IsBodyHtml = true;
                smtpClient.Send(mailMessage);
            }
        }
        
    }
}
