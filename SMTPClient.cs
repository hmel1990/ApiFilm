using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace ApiFilm
{
    internal class SendEmailByGmail
    {
        private static string senderEmail = "hmelforitstep@gmail.com"; // отправитель
        private static string senderPassword = "**** **** **** ****"; // пароль приложения https://github.com/sunmeat/secret_things/blob/main/app_code.txt
        public string receiverEmail = "hmel408757595@gmail.com"; // получатель
                                                                 // SMTP-клиент для Gmail
        private SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true
        };

        public void SendEmail(string receiverEmail, string textMessage)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(receiverEmail);
                mail.Subject = "Тестовое письмо";
                mail.Body = mail.Body = $@"
                <html>
                <head>
                    <style>
                        body {{ font-family: 'Segoe UI', Arial, sans-serif; color: #333; background-color: #f5f5f5; padding: 20px; }}
                        .container {{ max-width: 600px; margin: 0 auto; background-color: #fff; border-radius: 15px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); padding: 20px; }}
                        h2 {{ color: #1a73e8; font-size: 28px; margin-bottom: 10px; }}
                        p {{ font-size: 16px; line-height: 1.5; }}
                        .highlight {{ background-color: #e8f0fe; padding: 15px; border-left: 4px solid #1a73e8; border-radius: 5px; }}
                        .image-container {{ text-align: center; margin: 20px 0; }}
                        img {{ max-width: 100%; height: auto; border-radius: 10px; border: 2px solid #ddd; }}
                        .footer {{ font-size: 12px; color: #888; text-align: center; margin-top: 20px; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <h2>Привет!</h2>
                        <p>Это тестовое письмо из приложения .NET 9!</p>
                        <div class='highlight'>
                            <p>Смотри, какое красивое оформление!</p>
                            <p>{textMessage}</p>
                        </div>                       
                        <div class='footer'>
                            Отправлено: {DateTime.Now:dd.MM.yyyy HH:mm}
                        </div>
                    </div>
                </body>
                </html>";
                mail.IsBodyHtml = true; // выключить HTML-формат



                smtpClient.Send(mail);
                Console.WriteLine("Письмо успешно отправлено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка отправки письма: {ex.Message}");
            }
        }
    }
}
