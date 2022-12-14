using Oksi_Dora.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Oksi_Dora.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrPage.xaml
    /// </summary>
    public partial class RegistrPage : Page
    {
        public RegistrPage()
        {
            InitializeComponent();
        }

        private void AuthBTN_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();
            if (login.Length > 0 && password.Length > 0)
            {
                try
                {
                    User user = new User()
                    {
                        Login = login,
                        Password = password,
                        RoleId = 2
                    };
                    DbConnect.db.User.Add(user);
                    DbConnect.db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Navigation.BackPage();
                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Заполните поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CleanBTN_Click(object sender, RoutedEventArgs e)
        {
            LoginTb.Text = "";
            PasswordTb.Password = "";
        }
    }
}
