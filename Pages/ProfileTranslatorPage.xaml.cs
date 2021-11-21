using EgyptianDictionary.Entities;
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

namespace EgyptianDictionary.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfileTranslatorPage : Page
    {
        List<Translation> translations = App.Context.Translation.ToList();
        List<Translator> translators = App.Context.Translator.ToList();
        List<Client> clients = App.Context.Client.ToList();
        List<Role> roles = App.Context.Role.ToList();
        public ProfileTranslatorPage()
        {
            InitializeComponent();
            for (int t = 0; t < translations.Count; t++)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    if (translations[t].clientId == clients[i].id)
                    {
                        translations[t].clientName = clients[i].name;
                    }
                }
            }
            int translatorCurrent = 0;
            int translatorCount = 0;
            string roleCurrent = "";
            for (int t = 0; t < translators.Count; t++)
            {
                if (translators[t].login == App.CurrentUser.login)
                {
                   translatorCurrent = translators[t].id;
                    translatorCount = t;
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
            TBName.Text = translators[translatorCount].name;
            if (translators[translatorCount].gender == "м") CBGender.SelectedItem = CBMale;
            else CBGender.SelectedItem = CBFemale;
            TBPhoto.Text = translators[translatorCount].avatar;
            TBEducation.Text = translators[translatorCount].education;
            TBExperience.Text = translators[translatorCount].experience;
            LViewNow.ItemsSource = translations.Where(p => p.translatorId == translatorCurrent && p.result == null).ToList();
            LViewDone.ItemsSource = translations.Where(p => p.translatorId == translatorCurrent && p.result != null).ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (440 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    GridNow.Visibility = Visibility.Visible;
                    GridDone.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    GridNow.Visibility = Visibility.Collapsed;
                    GridDone.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void BTranslation_Click(object sender, RoutedEventArgs e)
        {
            var currentTranslation = (sender as Button).DataContext as Entities.Translation;
            new TranslationWindow(currentTranslation).Show();

        }


        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            TBPassword.IsReadOnly = false;
            TBName.IsReadOnly = false;
            TBPhoto.IsReadOnly = false;
            TBEducation.IsReadOnly = false;
            TBExperience.IsReadOnly = false;
            CBGender.IsEnabled = true;
            BEdit.Visibility = Visibility.Collapsed;
            BSave.Visibility = Visibility.Visible;
        }
        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (TBPassword.Text == "" || TBName.Text == "" || CBGender.SelectedItem == null || TBEducation.Text == "" || TBExperience.Text == "")
            {
                MessageBox.Show("Не все данные были введены!");
                return;
            }
            int translatorCurrent = 0;
            for (int t = 0; t < translators.Count; t++)
            {
                if (translators[t].login == App.CurrentUser.login)
                {
                    translatorCurrent = t;
                }

            }
            App.CurrentUser.password = TBPassword.Text;
            translators[translatorCurrent].name = TBName.Text;
            translators[translatorCurrent].avatar = TBPhoto.Text;
            translators[translatorCurrent].education = TBEducation.Text;
            translators[translatorCurrent].experience = TBExperience.Text;
            App.Context.SaveChanges();
            MessageBox.Show("Информация о пользователе обновлена!");
            TBPassword.IsReadOnly = true;
            TBName.IsReadOnly = true;
            TBPhoto.IsReadOnly = true;
            CBGender.IsEnabled = false;
            TBEducation.IsReadOnly = true;
            TBExperience.IsReadOnly = true;
            BEdit.Visibility = Visibility.Visible;
            BSave.Visibility = Visibility.Collapsed;
        }
        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Вы действительно хотите удалить этот аккаунт и все связанные с ним переводы?", "Внимание!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                int translatorCount = 0;
                int translatorCurrent = 0;
                for (int t = 0; t < translators.Count; t++)
                {
                    if (translators[t].login == App.CurrentUser.login)
                    {
                        translatorCount = t;
                        translatorCurrent = translators[t].id;
                    }

                }
                for (int t = 0; t < translations.Count; t++)
                {
                    if (translations[t].translatorId == translatorCurrent)
                    {
                        App.Context.Translation.Remove(translations[t]);
                    }

                }
                App.Context.User.Remove(App.CurrentUser);
                App.Context.Translator.Remove(translators[translatorCount]);
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
