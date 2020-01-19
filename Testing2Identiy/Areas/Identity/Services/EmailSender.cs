using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Testing2Identiy.Areas.Identity.Services
{
    public class EmailSender : IEmailSender
    {
        public string host="smtp.gmail.com";
        public int port=587;
        public bool enableSSL=true;
        public string userName;
        public string password;

        public EmailSender()
        {
            host = "smtp.live.com";
            port = 587;
            enableSSL = true;
            userName = "n_gondaliya@live.com";
            password = "nikhil1212";
        }
       
        public Task SendEmailAsync(string email,string subject,string message)
        {

            NetworkCredential networkCredential = new NetworkCredential(userName,password);
            var client = new SmtpClient(host, port)
            {               
                EnableSsl = enableSSL,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };
            client.Credentials = networkCredential;
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, message) { IsBodyHtml = true }
            );

        }
    }
}
