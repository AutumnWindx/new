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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = FirstTBox.Text.Trim();
            string SecondName = SecondTBox.Text.Trim();
            string LastName = LastTBox.Text.Trim();
            string Phone = PhoneTBox.Text.Trim();
            string Login = LoginTBox.Text.Trim();
            string Password = PasswordPBox.Password.Trim();

            if (Login.Length < 3)
            {
                LoginTBox.ToolTip = "Логин введен не правильно!";
                LoginTBox.Background = Brushes.DarkGoldenrod;
            }
            else if (Password.Length < 3)
            {
                PasswordPBox.ToolTip = "Пароль введен не правильно!";
                PasswordPBox.Background = Brushes.DarkGoldenrod;
            }
            else if (FirstName.Length < 3)
            {
                FirstTBox.ToolTip = "Имя введено не правильно!";
                FirstTBox.Background = Brushes.DarkGoldenrod;
            }
            else if (SecondName.Length < 3)
            {
                SecondTBox.ToolTip = "Фамилия введена не правильно!";
                SecondTBox.Background = Brushes.DarkGoldenrod;
            }
            else if (LastName.Length < 3)
            {
                LastTBox.ToolTip = "Отчество введено не правильно!";
                LastTBox.Background = Brushes.DarkGoldenrod;
            }
            else if (Phone.Length < 5)
            {
                PhoneTBox.ToolTip = "Телефон введен не правильно!";
                PhoneTBox.Background = Brushes.DarkGoldenrod;
            }

            else
            {
                FirstTBox.ToolTip = "";
                FirstTBox.Background = Brushes.Transparent;

                SecondTBox.ToolTip = "";
                SecondTBox.Background = Brushes.Transparent;

                LastTBox.ToolTip = "";
                LastTBox.Background = Brushes.Transparent;

                PhoneTBox.ToolTip = "";
                PhoneTBox.Background = Brushes.Transparent;

                LoginTBox.ToolTip = "";
                LoginTBox.Background = Brushes.Transparent;

                PasswordPBox.ToolTip = "";
                PasswordPBox.Background = Brushes.Transparent;


                MessageBox.Show("Регистрация прошла успешно!");

                User user = new User()
                {
                    Login = Login,
                    Password = Password,
                    FirstName = FirstName,
                    SecondName = SecondName,
                    LastName = LastName,
                    Phone = Phone,

                };

                Help.db.Users.Add(user);
                Help.db.SaveChanges();

                MainWindow cool = new MainWindow();
                cool.Show();
                this.Close();
            }
        }
    }
}
