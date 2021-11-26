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

namespace EgyptianDictionary
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = App.Context.User.FirstOrDefault(p => p.Login == TBLogin.Text && p.Password == PBPassword.Password);
            if (TBLogin.Text == "" || PBPassword.Password == "")
            {
                MessageBox.Show("Пустые поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (currentUser != null)
            {
                App.CurrentUser = currentUser;
                MessageBox.Show("Вы успешно авторизованы!");
                new MainWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь с такими данными не найден.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BRegistration_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            this.Close();
        }

        private void BMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
