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
            if (App.Context.User.Select(Item => Item.login).Contains(TBLogin.Text))
            {
                MessageBox.Show("Такой логин уже существует в системе!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string g = "м";
            int role = 1;
            if (CBGender.SelectedItem == CBMale) g ="м";
            if (CBGender.SelectedItem == CBFemale) g = "ж";
            if (CBRole.SelectedItem == CBUser) role = 1;
            if (CBRole.SelectedItem == CBTranslator) role = 2;
            User newUser = new User()
            {
                login = TBLogin.Text,
                password = TBPassword.Password,
                roleId = role,
            };
            App.Context.User.Add(newUser);
            if (CBRole.SelectedItem == CBUser)
            {
                Client newClient = new Client()
                {
                    login = TBLogin.Text,
                    name = TBName.Text,
                    gender = g,
                };
                App.Context.Client.Add(newClient);
            }
            if (CBRole.SelectedItem == CBTranslator)
            {
                Translator newTranslator = new Translator()
                {
                    login = TBLogin.Text,
                    name = TBName.Text,
                    gender = g,
                    education = TBEducation.Text,
                    experience = TBExperience.Text,
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
    }
}
