using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net.Mail;
using System.Net;


namespace SMTPService
{
    class EmailService
    {
        private readonly Timer timer;
        private readonly TimeSpan timeSpan = new TimeSpan(0, 1, 0, 0);
        private readonly Database db = new Database();

        public EmailService()
        {

            timer = new Timer(60000) { AutoReset = true };
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            List<ReminderDetails> reminders = db.GetOneDayReminders();
            foreach (ReminderDetails reminder in reminders)
            {
                SendEmailToOneDayReminders(reminder);
                //if (reminder.ThreeDayReminder != 1 && reminder.OneDayReminder != 1)
                //{
                //    db.RemoveReminder(reminder);
                //}
                //else
                //{
                //    db.UpdateOneDay(reminder);
                //}
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
                    UserName = "KoolReminders@gmail.com",
                    Password = "yvvxwjfawanjpyvx"
                }
            };
            MailAddress FromEmail = new MailAddress("KoolReminders@mail.com", "KoolReminders");
            MailAddress ToEmail = new MailAddress(reminder.Email);
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Reminder from KoolReminders!",
                Body = "You have an event coming up! \n\n" + reminder.Message + " at: " + reminder.ReminderTime.ToString(),
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
