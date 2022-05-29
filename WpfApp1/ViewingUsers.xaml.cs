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
    /// Логика взаимодействия для ViewingUsers.xaml
    /// </summary>
    public partial class ViewingUsers : Window
    {
        public ViewingUsers()
        {
            InitializeComponent();
            LoadData();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new Distributor().Show();
            this.Close();
        }
        private void LoadData()
        {
            OrdersDGrid.ItemsSource = Help.db.Users.ToList();
        }

        private void OrdersDGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = OrdersDGrid.SelectedItem as User;

            if (user != null)
            {
                Help.db.SaveChanges();
                LoadData();
            }
        }
    }
}
