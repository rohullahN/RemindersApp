using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ReminderApp
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

        public void InsertReminder(ReminderDetails reminderDetails)
        {
            string sql = "INSERT INTO Reminders (ReminderTime, Message, Email, IsActive, ThreeDayReminder, OneDayReminder, SameDayReminder) " +
                "VALUES (@ReminderTime, @Message, @Email, @IsActive, @ThreeDayReminder, @OneDayReminder, @SameDayReminder)";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ToString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Populate all arguments in the insert
                        cmd.Parameters.AddWithValue("@ReminderTime", reminderDetails.ReminderTime);
                        cmd.Parameters.AddWithValue("@Message", reminderDetails.Message);
                        cmd.Parameters.AddWithValue("@Email", reminderDetails.Email);
                        cmd.Parameters.AddWithValue("@IsActive", 1);
                        cmd.Parameters.AddWithValue("@ThreeDayReminder", reminderDetails.ThreeDayReminder);
                        cmd.Parameters.AddWithValue("@OneDayReminder", reminderDetails.OneDayReminder);
                        cmd.Parameters.AddWithValue("@SameDayReminder", reminderDetails.SameDayReminder);
                        // Execute the insertion and check the number of rows affected
                        // An exception will be thrown if the column is repeated
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ReminderDetails> GetAllReminders()
        {
            List<ReminderDetails> reminders = new List<ReminderDetails>();
            string sql = "SELECT * FROM Reminders WHERE IsActive=1";
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
            catch(Exception)
            {
                throw;
            }
            return reminders;
        }
    }


}
