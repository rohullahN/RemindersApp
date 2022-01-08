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
            myTextblock.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var date = DateTime.Parse(Calendar.SelectedDate.ToString());
            myTextblock.Text = date.ToString("yyyy-MM-dd");
        }

        private void EditButton1_Click(object sender, RoutedEventArgs e)
        {
            AddEvent addEvent = new AddEvent(myTextblock.Text);
            addEvent.Show();
        }
    }
}
