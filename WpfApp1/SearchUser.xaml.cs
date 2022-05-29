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
    /// Логика взаимодействия для SearchUser.xaml
    /// </summary>
    public partial class SearchUser : Window
    {
        public SearchUser(Task selectedTask)
        {
            InitializeComponent();
            LoadData(selectedTask);
            Task currentTask = selectedTask;
            DataContext = currentTask;
        }
        private void LoadData(Task selectedTask)
        {
            Search.ItemsSource = Help.db.Tasks.Where(t => t.IdCreator == Help.userSession.Id).Include(s => s.IdStatusTaskNavigation).ToList();//
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new ViewingTask().Show();
            this.Close();
        }
    }
}
