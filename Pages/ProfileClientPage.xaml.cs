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
using EgyptianDictionary.Entities;

namespace EgyptianDictionary.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfileClientPage.xaml
    /// </summary>
    public partial class ProfileClientPage : Page
    {
        List<Translation> translations = App.Context.Translation.ToList();
        List<Translator> translators = App.Context.Translator.ToList();
        List<Client> clients = App.Context.Client.ToList();
        List<Role> roles = App.Context.Role.ToList();
        public ProfileClientPage()
        {
            InitializeComponent();
            for (int t = 0; t < translations.Count; t++)
            {
                for (int i = 0; i < translators.Count; i++)
                {
                    if (translations[t].translatorId == translators[i].id)
                    {
                        translations[t].translatorName = translators[i].name;
                    }
                }
            }
            int clientCurrent =0;
            int clientCount = 0;
            string roleCurrent = "";
            for (int c = 0; c < clients.Count; c++)
            {
                if (clients[c].login == App.CurrentUser.login)
                {
                    clientCurrent = clients[c].id;
                    clientCount = c;
                }

            }
            for (int r = 0; r < roles.Count; r++)
            {
                if (roles[r].id == App.CurrentUser.roleId)
                {
                    roleCurrent = roles[r].name;
                }
            }
            TBType.Text = roleCurrent;
            TBLogin.Text = App.CurrentUser.login;
            TBPassword.Text = App.CurrentUser.password;
            TBName.Text = clients[clientCount].name;
            if (clients[clientCount].gender == "м") CBGender.SelectedItem = CBMale;
            else CBGender.SelectedItem = CBFemale;
            CBTranslator.ItemsSource = translators;
            LViewSend.ItemsSource = translations.Where(p => p.clientId == clientCurrent && p.result == null).ToList();
            LViewResult.ItemsSource = translations.Where(p => p.clientId == clientCurrent && p.result != null).ToList();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (295 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    GridCreate.Visibility = Visibility.Visible;
                    GridSend.Visibility = Visibility.Collapsed;
                    GridResult.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    GridCreate.Visibility = Visibility.Collapsed;
                    GridSend.Visibility = Visibility.Visible;
                    GridResult.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    GridCreate.Visibility = Visibility.Collapsed;
                    GridSend.Visibility = Visibility.Collapsed;
                    GridResult.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void BCreate_Click(object sender, RoutedEventArgs e)
        {
            if (TBText.Text == "" || TBTask.Text =="" || CBTranslator.SelectedItem == null)
            {
                MessageBox.Show("Не все данные были введены!");
                return;
            }
            int translator=0;
            for (int i = 0; i < translators.Count; i++)
            {
                if (CBTranslator.SelectedItem == translators[i])
                {
                    translator = translators[i].id;
                }
            }
            int clientCurrent = 0;
            for (int c = 0; c < clients.Count; c++)
            {
                if (clients[c].login == App.CurrentUser.login)
                {
                    clientCurrent = clients[c].id;
                }
            }
            Translation newTranslation = new Translation()
            {
                originalText = TBText.Text,
                task = TBTask.Text,
                translatorId = (short?)translator,
                clientId = (short?)clientCurrent,
            };
            App.Context.Translation.Add(newTranslation);
            App.Context.SaveChanges();
            MessageBox.Show("Заявка успешно отправлена!");
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            TBPassword.IsReadOnly = false;
            TBName.IsReadOnly = false;
            TBPhoto.IsReadOnly = false;
            CBGender.IsEnabled = true;
            BEdit.Visibility = Visibility.Collapsed;
            BSave.Visibility = Visibility.Visible;
        }
        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (TBPassword.Text == "" || TBName.Text == "" || CBGender.SelectedItem == null)
            {
                MessageBox.Show("Не все данные были введены!");
                return;
            }
            int clientCurrent = 0;
            for (int c = 0; c < clients.Count; c++)
            {
                if (clients[c].login == App.CurrentUser.login)
                {
                    clientCurrent = c;
                }

            }
            App.CurrentUser.password = TBPassword.Text;
            clients[clientCurrent].name = TBName.Text;
            App.Context.SaveChanges();
            MessageBox.Show("Информация о пользователе обновлена!");
            TBPassword.IsReadOnly = true;
            TBName.IsReadOnly = true;
            TBPhoto.IsReadOnly = true;
            CBGender.IsEnabled = false;
            BEdit.Visibility = Visibility.Visible;
            BSave.Visibility = Visibility.Collapsed;
        }
        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Вы действительно хотите удалить этот аккаунт и все связанные с ним переводы?","Внимание!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                int clientCount = 0;
               int  clientCurrent = 0;
                for (int c = 0; c < clients.Count; c++)
                {
                    if (clients[c].login == App.CurrentUser.login)
                    {
                        clientCount = c;
                        clientCurrent = clients[c].id;
                    }

                }
                for (int t = 0; t < translations.Count; t++)
                {
                    if (translations[t].clientId == clientCurrent)
                    {
                        App.Context.Translation.Remove(translations[t]);
                    }

                }
                App.Context.User.Remove(App.CurrentUser);
                App.Context.Client.Remove(clients[clientCount]);
                App.Context.SaveChanges();
                MessageBox.Show("Аккаунт удален");
                var exe = Process.GetCurrentProcess().MainModule.FileName;
                Process.Start(exe);
                Application.Current.Shutdown();
            }
            else if (dialogResult == MessageBoxResult.No)
            {
                return;
            }    
        }
    }
}
