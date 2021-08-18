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
    public class EmailSettings
    {
        public string MailToAddress = "orders@gss.com.tw";
        public string MailFromAddress = "mystore@gss.com.tw";
        public bool UseSSL = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "mail.gss.com.tw";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"d:\temps";
    }
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            this.emailSettings = settings;
        }
        public Order ProcessOrder(User user, Cart cart, ShippingDetails shippingDetails)
        {
            var order = new Order(user.Email, cart.Lines.ToList(), shippingDetails);
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

                var body = new StringBuilder()
                    .AppendLine($"User:{user.Email}")
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items");
                foreach(var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} X {1} (subtotal:{2:c}", line.Quantity,
                        line.Product.Name,
                        subtotal);
                }

                body.AppendFormat("Total order value:{0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingDetails.Name)
                    .AppendLine(shippingDetails.Address)
                    
                    .AppendLine("---")
                    .AppendFormat("Gitft wrap:{0}",
                        shippingDetails.GiftWrap ? "Yes" : "No");


                var mailMessage = new MailMessage(
                                emailSettings.MailFromAddress,
                                emailSettings.MailToAddress,
                                "New Order submitted",
                                body.ToString()
                        );

                
                smtpClient.Send(mailMessage);
            }
            return order;
        }

        public IEnumerable<Order> SearchOrders(string email, string productName)
        {
            throw new NotImplementedException();
        }
    }
}
