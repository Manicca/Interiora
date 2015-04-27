using System;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
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
          /// <param name="attachFile">Присоединенный файл</param>
          public static void SendMessage(string smtpServer, string from, string password,
               string mailto, string caption, string message, string attachFile = null)
          {
               try
               {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from);
                    mail.To.Add(new MailAddress(mailto));
                    mail.Subject = caption;
                    mail.Body = message;
                    if (!string.IsNullOrEmpty(attachFile))
                         mail.Attachments.Add(new Attachment(attachFile));
                    SmtpClient client = new SmtpClient();
                    client.Host = smtpServer;
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                    client.SendAsync(mail, mail);
               }
               catch (Exception e)
               {
                    throw new Exception("Отправка Почты провалилась на начальном этапе: " + e.Message);
               }
          }

          private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
          {
               // Get the unique identifier for this asynchronous operation.
               var msg = (MailMessage)e.UserState;

               if (e.Cancelled)
                    throw new Exception("Отправка почты отменена: " + msg.ToString());
               else if (e.Error != null)
                    throw new Exception(e.Error.ToString() + " : " + msg.ToString());
               else
                    MessageBox.Show("Ваше сообщение отправлено!");

               if (msg != null)
                    msg.Dispose();
          }

     }
}
