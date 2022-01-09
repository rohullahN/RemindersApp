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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WelcomeText.Text = "Welcome " + Environment.UserName;
           // myTextblock.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

            //var date = DateTime.Parse(Calendar.SelectedDate.ToString());
           // DateTime dt = new DateTime(date.Year, date.Month, date.Day, 13, 20, 0);
           //date.Add(new TimeSpan(4, 30, 0));

           // myTextblock.Text = dt.ToString();
        }

        private void EditButton1_Click(object sender, RoutedEventArgs e)
        {
            //string date = datePicker.Text;
            //string time = TimePicker.Text;
            //DateTime dt = DateTime.Parse(date + " " + time);
            //myTextblock.Text = dt.ToString();
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            myTextblock.Text = datePicker.SelectedDate.ToString();
        }

        private DateTime GetDateTime()
        {
            DateTime dt = new DateTime();
            if (datePicker.Text != null)
            {
                string date = datePicker.Text;
                string time = TimePicker.Text + AmPmPicker.Text;
                dt = DateTime.Parse(date + " " + time);
                // myTextblock.Text = dt.ToString();
                
            }
            else
            {
                MessageBox.Show("You must pick a date first for your reminder.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }

        private void TimePicker_DropDownClosed(object sender, EventArgs e)
        {
            myTextblock.Text = GetDateTime().ToString();
        }

        private void TimePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            myTextblock.Text = GetDateTime().ToString();
        }

        private void AmPmPicker_LostFocus(object sender, RoutedEventArgs e)
        {
            myTextblock.Text = GetDateTime().ToString();
        }
    }
}
