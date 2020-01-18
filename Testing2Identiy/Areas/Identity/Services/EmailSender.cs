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
            host = "smtp.google.com";
            port = 465;
            enableSSL = true;
            userName = "ppbholu511@gmail.com";
            password = "nikhil1212";
        }
       

     

        public async Task SendEmailAsync(string email,string subject,string message)
        {

            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };
            await client.SendMailAsync(userName,email,subject,message);
            //return client.SendMailAsync(
            //    new MailMessage( userName, email, subject, message) { IsBodyHtml = true }
            //);
          
        }
    }
}
