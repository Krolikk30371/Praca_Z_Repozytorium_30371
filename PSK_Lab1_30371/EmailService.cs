using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace PSK_Lab1_30371
{
    public class EmailService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;
        private readonly string _fromAddress;

        public EmailService(string smtpHost, int smtpPort, string smtpUser, string smtpPass, string fromAddress)
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _smtpUser = smtpUser;
            _smtpPass = smtpPass;
            _fromAddress = fromAddress;
        }

        public async Task SendTwoFactorCodeAsync(string toEmail, string code)
        {
            var msg = new MimeMessage();
            msg.From.Add(MailboxAddress.Parse(_fromAddress));
            msg.To.Add(MailboxAddress.Parse(toEmail));
            msg.Subject = "Twój kod weryfikacyjny";
            msg.Body = new TextPart("plain")
            {
                Text = $"Twój jednorazowy kod weryfikacyjny: {code}\nKod jest ważny 5 minut."
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(_smtpHost, _smtpPort, SecureSocketOptions.StartTls);
            if (!string.IsNullOrEmpty(_smtpUser))
                await client.AuthenticateAsync(_smtpUser, _smtpPass);
            await client.SendAsync(msg);
            await client.DisconnectAsync(true);
        }
    }
}
