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

        private string ReminderTime { get; set; }
        private string ReminderDate { get; set; }
        private string Email { get; set; }
        private string Message { get; set; }


        public Database(string rDate, string rTime, string email, string message)
        {
            Server = ConfigurationManager.AppSettings.Get("Server");
            User = ConfigurationManager.AppSettings.Get("User");
            Port = ConfigurationManager.AppSettings.Get("Port");
            Password = ConfigurationManager.AppSettings.Get("Password");
            DatabaseName = ConfigurationManager.AppSettings.Get("DatabaseName");
            ReminderTime = rTime;
            ReminderDate = rDate;
            Email = email;
            Message = message;
        }

        public override string ToString()
        {
            return $"server={Server};user={User};database={DatabaseName};port={Port};password={Password}; convert zero datetime=True";
        }

        public void InsertReminder()
        {
            string sql = "INSERT INTO Reminders (ReminderTime, Message, Email, ReminderDate) " +
                "VALUES (@ReminderTime, @Message, @Email, @ReminderDate)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ToString()))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Populate all arguments in the insert
                        cmd.Parameters.AddWithValue("@ReminderTime", ReminderTime);
                        cmd.Parameters.AddWithValue("@Message", Message);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@ReminderDate", ReminderDate);
                        cmd.Parameters.AddWithValue("@IsActive", 1);


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
    }


}
