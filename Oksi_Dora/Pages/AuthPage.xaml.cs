using Oksi_Dora.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Auth1BTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("Регистрация", new RegistrPage()));
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();

            var userA = DbConnect.db.User.ToList().Find(x => x.Login == login && x.Password == password);
            if (userA == null)
            {
                MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Navigation.isAuth = true;
                Navigation.NextPage(new Nav("Список услуг", new ServiceListPage()));
            }
        }
    }
}
