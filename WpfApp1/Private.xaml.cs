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
    /// Логика взаимодействия для Private.xaml
    /// </summary>
    public partial class Private : Window
    {
        public Private()
        {
            InitializeComponent();
            User currentUser = new User();
            currentUser = Help.userSession;
            DataContext = currentUser;
            LoadData(currentUser);
        }

        private void LoadData(User currentUser)
        {
            UserAndTask.ItemsSource = Help.db.Tasks.Where(t => t.IdAccepted == currentUser.Id).Include(s => s.IdStatusTaskNavigation).ToList();//
        }
        private void LoadChangedDate()
        {
            UserAndTask.ItemsSource = Help.db.Tasks.Where(t => t.IdAccepted == Help.userSession.Id).Include(s => s.IdStatusTaskNavigation).ToList();//
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new Distributor().Show();
            this.Close();
        }

        private void UserAndTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task task = UserAndTask.SelectedItem as Task;
            if (task != null)
            {
                if (task.IdStatusTask == 1)
                {
                    task.IdStatusTask = 2;
                }
                else if (task.IdStatusTask == 2)
                {
                    task.IdStatusTask = 3;
                }
                else if (task.IdStatusTask == 3)
                {
                    task.IdStatusTask = 1;
                }
                Help.db.SaveChanges();
                LoadChangedDate();
            }
            UserAndTask.SelectedItem = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new History().Show();
            this.Close();
        }
    }
}
