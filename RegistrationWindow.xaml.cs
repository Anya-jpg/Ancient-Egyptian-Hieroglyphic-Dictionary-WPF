using EgyptianDictionary.Entities;
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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void BRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (TBLogin.Text == "" || TBPassword.Password == "" || TBName.Text == "" || CBRole.SelectedItem == null || CBGender.SelectedItem == null)
            {
                MessageBox.Show("Не все данные заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (App.Context.User.Select(Item => Item.Login).Contains(TBLogin.Text))
            {
                MessageBox.Show("Такой логин уже существует в системе!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string g = "м";
            byte role = 1;
            if (CBGender.SelectedItem == CBMale) g ="м";
            if (CBGender.SelectedItem == CBFemale) g = "ж";
            if (CBRole.SelectedItem == CBUser) role = 1;
            if (CBRole.SelectedItem == CBTranslator) role = 2;
            string photo = "𓁛";
            if (TBPhoto.Text != "") photo = TBPhoto.Text;
            User newUser = new User()
            {
                Login = TBLogin.Text,
                Password = TBPassword.Password,
                RoleId = role,
            };
            App.Context.User.Add(newUser);
            if (CBRole.SelectedItem == CBUser)
            {
                Client newClient = new Client()
                {
                    Login = TBLogin.Text,
                    Name = TBName.Text,
                    Gender = g,
                    Avatar = photo,
                };
                App.Context.Client.Add(newClient);
            }
            if (CBRole.SelectedItem == CBTranslator)
            {
                Translator newTranslator = new Translator()
                {
                    Login = TBLogin.Text,
                    Name = TBName.Text,
                    Gender = g,
                    Avatar = photo,
                    Education = TBEducation.Text,
                    Experience = TBExperience.Text,
                };
                App.Context.Translator.Add(newTranslator);
            }
            App.Context.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрированы!");
            new LoginWindow().Show();
            this.Close();
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }

        private void CBRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBRole.SelectedItem == CBTranslator)
            {
                TBEducation.IsEnabled = true;
                TBExperience.IsEnabled = true;
            }
            if (CBRole.SelectedItem == CBUser)
            {
                TBEducation.IsEnabled = false;
                TBExperience.IsEnabled = false;
            }
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
