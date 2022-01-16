using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace SMTPService
{
    class EmailService
    {
       private readonly Timer timer;
        private readonly TimeSpan timeSpan = new TimeSpan(0, 0, 1, 0);
        private readonly Database db = new Database();


        public EmailService()
        {
            
            timer = new Timer(timeSpan.TotalMilliseconds) { AutoReset = true };
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            List<ReminderDetails> SameDayReminders = db.GetReminders(0);
            foreach (ReminderDetails SameReminder in SameDayReminders)
            {
                SendEmailToOneDayReminders(SameReminder);
                if (SameReminder.ThreeDayReminder != 1 && SameReminder.OneDayReminder != 1)
                {
                    db.RemoveReminder(SameReminder);
                }
                else
                {
                    db.UpdateReminder(SameReminder, 0);
                }
            }

            List<ReminderDetails> OneDayReminders = db.GetReminders(1);
            foreach (ReminderDetails OneReminder in OneDayReminders)
            {
                SendEmailToOneDayReminders(OneReminder);
                if (OneReminder.ThreeDayReminder != 1 && OneReminder.SameDayReminder != 1)
                {
                    db.RemoveReminder(OneReminder);
                }
                else
                {
                    db.UpdateReminder(OneReminder, 1);
                }
            }

            List<ReminderDetails> ThreeDayReminders = db.GetReminders(2);
            foreach (ReminderDetails ThreeReminder in ThreeDayReminders)
            {
                SendEmailToOneDayReminders(ThreeReminder);
                if (ThreeReminder.OneDayReminder != 1 && ThreeReminder.SameDayReminder != 1)
                {
                    db.RemoveReminder(ThreeReminder);
                }
                else
                {
                    db.UpdateReminder(ThreeReminder, 2);
                }
            }
        }

        public void SendEmailToOneDayReminders(ReminderDetails reminder)
        {
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = ConfigurationManager.AppSettings.Get("AccountEmail"),
                    Password = ConfigurationManager.AppSettings.Get("AccountPassword")
        }
            };
            MailAddress FromEmail = new MailAddress("KoolReminders@mail.com", "KoolReminders");
            MailAddress ToEmail = new MailAddress(reminder.Email);
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Reminder from KoolReminders!",
                Body = "You have an event coming up! \n\n" + reminder.Message + " on: " + reminder.ReminderTime.Date.ToString("yyyy-MM-dd")+ " at: "+reminder.ReminderTime.ToString("t"),
            };
            Message.To.Add(ToEmail);

            try
            {
                smtpClient.SendMailAsync(Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
