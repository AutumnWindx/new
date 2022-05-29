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
    /// Логика взаимодействия для ViewingTask.xaml
    /// </summary>
    public partial class ViewingTask : Window
    {
        public ViewingTask()
        {
            InitializeComponent();
            
            LoadData();
        }
        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            new Distributor().Show();
            this.Close();
        }
        private void LoadData()
        {
            TaskDGrid.ItemsSource = Help.db.Tasks.ToList();
        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = Help.db.Users.FirstOrDefault(q => q.Login == LoginBox.Text);
            if (user != null)
            {
                Task task = Help.db.Tasks.FirstOrDefault(t => t.IdCreator == user.Id);
                new SearchUser(task).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
        private void TaskDGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Task select = TaskDGrid.SelectedItem as Task;
            Help.task = select;
            new TaskWindow(select).Show();
            this.Close();
        }
        
    }
}
