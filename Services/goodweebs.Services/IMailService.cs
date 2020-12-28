using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodWeebs.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string to, string subject, string content);
    }

    public class SendGridMailService : IMailService
    {
        private IConfiguration configuration;
       
        public SendGridMailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
      
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = this.configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("gunexon@gmail.com", "GoodWeebds");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
