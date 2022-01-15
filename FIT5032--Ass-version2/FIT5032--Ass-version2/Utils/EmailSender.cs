using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.IO;
using System.Threading.Tasks;


namespace FIT5032__Ass_version2.Utils
{
    public class EmailSender
    {
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("anqihu0508@gmail.com", "Best Coffee Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        public void SendWithAttachment(String toEmail, String subject, String contents, string path, string filename)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("anqihu0508@gmail.com", "Best Coffee Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var attach = File.ReadAllBytes(path);
            msg.AddAttachment(filename, Convert.ToBase64String(attach));
            var response = client.SendEmailAsync(msg);
        }

    }
}