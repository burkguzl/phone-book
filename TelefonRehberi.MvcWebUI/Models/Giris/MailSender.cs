using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Mail;

namespace TelefonRehberi.MvcWebUI.Models.Giris
{
    public class MailSender
    {

        public void MailGonder(string body)
        {
            var fromAddress= new MailAddress("hesapproje@gmail.com");
            var toAddress = new MailAddress("burakguzel@outlook.com");
            string subject = "Telefon Rehberi - Sifremi Unuttum".ToString();
            
            using (var smtp= new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAddress.Address,"Aa_123456")
            })
            {
                using (var message = new MailMessage(fromAddress,toAddress){Subject = subject, Body = body})
                {
                    smtp.Send(message);
                }

            }
        }

    }
}