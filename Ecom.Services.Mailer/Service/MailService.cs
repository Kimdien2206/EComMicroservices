using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Ecom.Services.Mailer.Service
{
    public class MailService
    {
        static public int GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        static public void SendVerificationEmail(string recipientEmail, int code)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("20520453@gm.uit.edu.vn");
                mail.To.Add(recipientEmail);
                mail.Subject = "Email Verification";
                mail.Body = "Your verification code is: " + code;
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("20520453@gm.uit.edu.vn", "kcce hxkn ohmv bguo");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                Console.WriteLine("Verification email sent.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending verification email: " + ex.Message);
            }
        }
    }
}
