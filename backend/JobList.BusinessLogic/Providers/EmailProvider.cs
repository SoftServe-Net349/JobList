using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Providers
{
    public class EmailProvider : IEmailSender
    {
        private string _host;
        private int _port;
        private bool _enableSSL;
        private string _userName;
        private string _password;

        public EmailProvider(string host, int port, bool enableSSL, string userName, string password)
        {
            this._host = host;
            this._port = port;
            this._enableSSL = enableSSL;
            this._userName = userName;
            this._password = password;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_userName, _password),
                EnableSsl = _enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(_userName, email, subject, message)
            );
        }
    }
}
