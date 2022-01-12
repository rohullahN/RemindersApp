using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp
{
    class ReminderDetails
    {
        public int ReminderID { get; set; }
        public DateTime ReminderTime { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
       public int ThreeDayReminder { get; set; }
       public int OneDayReminder { get; set; }
       public int SameDayReminder { get; set; }

       public ReminderDetails(DateTime rTime, string message, string email, int threeDay, int oneDay, int sameDay )
        {
            ReminderTime = rTime;
            Message = message;
            Email = email;
            ThreeDayReminder = threeDay;
            OneDayReminder = oneDay;
            SameDayReminder = sameDay;
        }

        public ReminderDetails()
        {

        }
    }
}
