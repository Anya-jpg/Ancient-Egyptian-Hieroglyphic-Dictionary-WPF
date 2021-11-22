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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EgyptianDictionary.Pages
{
    /// <summary>
    /// Логика взаимодействия для GodsPage.xaml
    /// </summary>
    public partial class GodsPage : Page
    {
        readonly List<God_ru> gods = App.Context.God_ru.ToList();
        public GodsPage()
        {
            InitializeComponent();
            LViewGods.ItemsSource = gods;
        }
        private void BSearh_Click(object sender, RoutedEventArgs e)
        {
            var modified = App.Context.God_ru.ToList();
            if (TBSearchGardiner.Text == "" && TBSearchName.Text == "" && TBSearchTransliteration.Text == "" && TBSearchUnicode.Text == "" && TBSearchWords.Text == "")
            {
                LViewGods.ItemsSource = gods;
            }
            if (TBSearchGardiner.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.gardiner_code) && p.gardiner_code.ToLower().Contains(TBSearchGardiner.Text.ToLower())).ToList();
            }
            if (TBSearchName.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.name) && p.name.ToLower().Contains(TBSearchName.Text.ToLower())).ToList();
            }
            if (TBSearchTransliteration.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.transliteration) && p.transliteration.ToLower().Contains(TBSearchTransliteration.Text.ToLower())).ToList();
            }
            if (TBSearchUnicode.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.hieroglyphic) && p.hieroglyphic.ToLower().Contains(TBSearchUnicode.Text.ToLower())).ToList();
            }
            if (TBSearchWords.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.description) && p.description.ToLower().Contains(TBSearchWords.Text.ToLower()) 
                || !string.IsNullOrEmpty(p.type) && p.type.ToLower().Contains(TBSearchWords.Text.ToLower()) 
                || !string.IsNullOrEmpty(p.view) && p.view.ToLower().Contains(TBSearchWords.Text.ToLower())).ToList();
            }
            LViewGods.ItemsSource = modified;
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            BSave.Visibility = Visibility.Visible;
            BEdit.Visibility = Visibility.Collapsed;

        }
        private void BSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
