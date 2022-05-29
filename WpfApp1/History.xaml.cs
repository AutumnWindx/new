using Microsoft.EntityFrameworkCore;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Window
    {
        public History()
        {
            InitializeComponent();
            User history = new User();
            history = Help.userSession;
            DataContext = history;
            LoadChangedDate();
        }

        private void LoadChangedDate()
        {
            ReadyTask.ItemsSource = Help.db.Tasks.Where(t => t.IdAccepted == Help.userSession.Id && t.IdStatusTask == 2).Include(s => s.IdStatusTaskNavigation).ToList();//
        }

        private void ReadyTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task task = ReadyTask.SelectedItem as Task;
            if (task != null)
            {
                task.IdStatusTask = 2;
                Help.db.SaveChanges();
                LoadChangedDate();
            }
            ReadyTask.SelectedItem = null;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new Private().Show();
            this.Close();
        }

    }
}
