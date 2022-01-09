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

namespace ReminderApp
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        private string time;
        public AddEvent()
        {
            InitializeComponent();
        }

        public AddEvent(string date)
        {
            InitializeComponent();
            EventDateText.Text = date;
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dtPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           // EventDateText.Text = dtPicker.SelectedDate.ToString();
        }
    }
}
