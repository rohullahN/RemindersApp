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
using System.Collections.ObjectModel;

namespace ReminderApp
{
    /// <summary>
    /// Interaction logic for DeleteReminder.xaml
    /// </summary>
    public partial class DeleteReminder : Window
    {
       // public ObservableCollection<ReminderDetails> Reminders { get; set; } 
       private readonly Database db = new Database();
        public DeleteReminder()
        {
            InitializeComponent();
            PopulateRemindersList();
        }

        private void Reminders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RemoveButton.IsEnabled = true;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ReminderDetails selectedReminder = (ReminderDetails)Reminders.SelectedItem;
            db.RemoveReminder(selectedReminder);
            PopulateRemindersList();
        }

        public void PopulateRemindersList()
        {
            
            List<ReminderDetails> reminders = db.GetAllReminders();
            Reminders.ItemsSource = reminders;
        }
    }
}
