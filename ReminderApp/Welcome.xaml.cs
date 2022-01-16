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
using System.Windows.Shapes;
using System.Globalization;

namespace ReminderApp
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
            welcomeText.Text= "Welcome " + Environment.UserName;

        }

        private void SetAReminder_Click(object sender, RoutedEventArgs e)
        {
            SetReminder setReminder = new SetReminder();
            setReminder.Show();
        }

        private void DeleteAReminder_Click(object sender, RoutedEventArgs e)
        {
            DeleteReminder deleteReminder = new DeleteReminder();
            deleteReminder.Show();
        }
    }
}
