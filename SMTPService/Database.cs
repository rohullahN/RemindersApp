using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SMTPService
{
    class Database
    {
        private string Server { get; set; }

        private string User { get; set; }

        private string Port { get; set; }

        private string Password { get; set; }

        private string DatabaseName { get; set; }

        public Database()
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

        public List<ReminderDetails> GetReminders(int state)
        {
            List<ReminderDetails> reminders = new List<ReminderDetails>();
            string statestr;
            int diff;
            switch(state)
            {
                case 0:
                    statestr = "SameDayReminder";
                    diff = 0;
                    break;
                case 1:
                    statestr = "OneDayReminder";
                    diff = 1;
                    break;
                case 2:
                    statestr = "ThreeDayReminder";
                    diff = 3;
                    break;
                default:
                    statestr = "";
                    diff = 0;
                    break;
            }
            string sql = $"select * from reminders where IsActive=1 AND {statestr}=1 AND datediff(ReminderTime, @CurrentDatetime)={diff}";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ToString()))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CurrentDatetime", DateTime.Now);
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
                            reminderDetails.ThreeDayReminder = int.Parse(rdr["ThreeDayReminder"].ToString());
                            reminderDetails.OneDayReminder = int.Parse(rdr["OneDayReminder"].ToString());
                            reminderDetails.SameDayReminder = int.Parse(rdr["SameDayReminder"].ToString());
                            reminders.Add(reminderDetails);
                        }
                    }
                    cmd.Dispose();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return reminders;
        }

        public void RemoveReminder(ReminderDetails reminder)
        {
            string sql = "UPDATE Reminders SET IsActive=0 WHERE ReminderTime=@ReminderTime AND Message=@Message AND Email=@Email";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ToString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Populate all arguments in the insert
                        cmd.Parameters.AddWithValue("@ReminderTime", reminder.ReminderTime);
                        cmd.Parameters.AddWithValue("@Message", reminder.Message);
                        cmd.Parameters.AddWithValue("@Email", reminder.Email);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateReminder(ReminderDetails reminder, int state)
        {
            string statestr;
            switch (state)
            {
                case 0:
                    statestr = "SameDayReminder";
                    break;
                case 1:
                    statestr = "OneDayReminder";
                    break;
                case 2:
                    statestr = "ThreeDayReminder";
                    break;
                default:
                    statestr = "";
                    break;
            }
            string sql = $"UPDATE Reminders SET {statestr}=0 WHERE ReminderTime=@ReminderTime AND Message=@Message AND Email=@Email";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ToString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Populate all arguments in the insert
                        cmd.Parameters.AddWithValue("@ReminderTime", reminder.ReminderTime);
                        cmd.Parameters.AddWithValue("@Message", reminder.Message);
                        cmd.Parameters.AddWithValue("@Email", reminder.Email);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
