using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace FunctionalityLibrary
{
    public class EMailSender
    {
        /// <summary>
        ///  Функция отправки сообщения на почту.
        /// </summary>
        /// <param name="smtpServer">Имя SMTP-сервера</param>
        /// <param name="from">Адрес отправителя</param>
        /// <param name="password">пароль к почтовому ящику отправителя</param>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="caption">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFile">Присоединенный файл(ПУТЬ БЛЯТЬ)</param>
        public static void SendMessage(string smtpServer, string from, string password,
             string mailto, string caption, string message, List<string> attachFiles = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;

                if (attachFiles != null && attachFiles.Count > 0)
                    foreach (var attachFile in attachFiles)
                        mail.Attachments.Add(new Attachment(attachFile));

                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.SendCompleted += SendCompletedCallback;
                client.SendAsync(mail, mail);
            }
            catch (Exception e)
            {
                MessageBox.Show("Отправка Почты провалилась на начальном этапе: " + e.Message);
            }
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            var msg = (MailMessage)e.UserState;

            if (e.Cancelled)
                throw new Exception("Отправка почты отменена: " + msg);
            if (e.Error != null)
                throw new Exception(e.Error + " : " + msg);
            MessageBox.Show("Ваше сообщение отправлено!");

            if (msg != null)
                msg.Dispose();
        }

    }
}
