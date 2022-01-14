using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPService
{
    class DAL
    {
        private string Server { get; set; }

        private string User { get; set; }

        private string Port { get; set; }

        private string Password { get; set; }

        private string DatabaseName { get; set; }

        public DAL()
        {
            Server = ConfigurationManager.AppSettings.Get("Server");
            User = ConfigurationManager.AppSettings.Get("User");
            Port = ConfigurationManager.AppSettings.Get("Port");
            Password = ConfigurationManager.AppSettings.Get("Password");
            DatabaseName = ConfigurationManager.AppSettings.Get("DatabaseName");
        }

        public override string ToString()
        {
            return $"server={Server};user={User};database={DatabaseName};port={Port};password={Password}; convert zero datetime=True";
        }

        public List<ReminderDetails> GetAllReminders()
        {
            List<ReminderDetails> reminders = new List<ReminderDetails>();
            string sql = "select * from reminders where IsActive=1 AND SameDayReminder=1 AND datediff(ReminderTime, now())=-1";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ToString()))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            ReminderDetails reminderDetails = new ReminderDetails();
                            reminderDetails.ReminderTime = DateTime.Parse(rdr["ReminderTime"].ToString());
                            reminderDetails.Message = rdr["Message"].ToString();
                            reminderDetails.Email = rdr["Email"].ToString();
                            reminders.Add(reminderDetails);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return reminders;
        }

    }
}
