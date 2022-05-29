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
    /// Логика взаимодействия для Distributor.xaml
    /// </summary>
    public partial class Distributor : Window
    {
        public Distributor()
        {
            InitializeComponent();
            
            
        }
        
        private void List_Click(object sender, RoutedEventArgs e)
        {
            new ViewingUsers().Show();
            this.Close();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            new Private().Show();
            this.Close();
        }

        

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            new ViewingTask().Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
