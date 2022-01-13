using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReminderApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SetReminder : Window
    {
        private int Three { get; set; }
        private int One { get; set; }
        private int Same { get; set; }
        public SetReminder()
        {
            InitializeComponent();
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePicker.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Reminder date must not be in the past. Please select a valid date for your reminder.", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                myTextblock.Text = datePicker.SelectedDate.ToString();
            }
            
        }

        private DateTime GetDateTime()
        {
            DateTime dt = new DateTime();

                string date = datePicker.Text;
                string time = TimePicker.Text + AmPmPicker.Text;
                dt = DateTime.Parse(date + " " + time);
                
            
            return dt;
        }

        private void TimePicker_DropDownClosed(object sender, EventArgs e)
        {
            
            myTextblock.Text = GetDateTime().ToString();
        }


        private void AmPmPicker_LostFocus(object sender, RoutedEventArgs e)
        {
            myTextblock.Text = GetDateTime().ToString();
        }

        private void AmPmPicker_DropDownClosed(object sender, EventArgs e)
        {
            if (GetDateTime()<DateTime.Now)
            {
                MessageBox.Show("Reminder date and time must not be in the past. Please select a valid time for your reminder.", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                myTextblock.Text = GetDateTime().ToString();
            }
     
        }

        private void TimePicker_DropDownOpened(object sender, EventArgs e)
        {
            if (datePicker.Text != "")
            {
                myTextblock.Text = GetDateTime().ToString();
            }
            else
            {
                MessageBox.Show("You must first pick a date for your reminder.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AmPmPicker_DropDownOpened(object sender, EventArgs e)
        {
            if (TimePicker.Text != "" &&  datePicker.Text!="")
            {
                myTextblock.Text = GetDateTime().ToString();
            }
            else
            {
                MessageBox.Show("You must first pick a date and time for your reminder.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            if(Three==0 && One==0 && Same==0)
            {
                MessageBox.Show("You must check at least one of the three options. Three day reminder, One day reminder, Same day reminder.", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                DateTime rTime = Convert.ToDateTime(myTextblock.Text);
                ReminderDetails reminderDetails = new ReminderDetails(rTime, EventText.Text, EmailText.Text, Three, One, Same);
                Database db = new Database();
                db.InsertReminder(reminderDetails);
                MessageBox.Show("Reminder set.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void ThreeDay_Click(object sender, RoutedEventArgs e)
        {
            if((bool)ThreeDay.IsChecked)
            {
                Three = 1;
            }
            else
            {
                Three = 0;
            }
        }

        private void OneDay_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)OneDay.IsChecked)
            {
                One = 1;
            }
            else
            {
                One = 0;
            }
        }

        private void SameDay_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)SameDay.IsChecked)
            {
                Same = 1;
            }
            else
            {
                Same = 0;
            }
        }
    }
}
