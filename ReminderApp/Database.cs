using System;
using System.Collections.Generic;
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
            Server = "i0rgccmrx3at3wv3.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            User = "r4mqsn19147cbkp3";
            Port = "3306";
            Password = "slbef5y8np061xyy";
            DatabaseName = "rsm2e6oey297th9b";

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

                        cmd.Parameters.AddWithValue("@ReminderTime", reminderDetails.ReminderTime);
                        cmd.Parameters.AddWithValue("@Message", reminderDetails.Message);
                        cmd.Parameters.AddWithValue("@Email", reminderDetails.Email);
                        cmd.Parameters.AddWithValue("@IsActive", 1);
                        cmd.Parameters.AddWithValue("@ThreeDayReminder", reminderDetails.ThreeDayReminder);
                        cmd.Parameters.AddWithValue("@OneDayReminder", reminderDetails.OneDayReminder);
                        cmd.Parameters.AddWithValue("@SameDayReminder", reminderDetails.SameDayReminder);

                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
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
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
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
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }


}
