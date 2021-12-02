using EgyptianDictionary.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EgyptianDictionary.Pages
{
    /// <summary>
    /// Логика взаимодействия для GodsPage.xaml
    /// </summary>
    public partial class GodsPage : Page
    {
        readonly List<God> gods = App.Context.God.ToList();
        public GodsPage()
        {
            InitializeComponent();
            LViewGods.ItemsSource = gods;
        }
        private void BSearh_Click(object sender, RoutedEventArgs e)
        {
            var modified = App.Context.God.ToList();
            if (TBSearchGardiner.Text == "" && TBSearchName.Text == "" && TBSearchTransliteration.Text == "" && TBSearchUnicode.Text == "" && TBSearchWords.Text == "")
            {
                LViewGods.ItemsSource = gods;
            }
            if (TBSearchGardiner.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.GardinerCode) && p.GardinerCode.ToLower().Contains(TBSearchGardiner.Text.ToLower())).ToList();
            }
            if (TBSearchName.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(TBSearchName.Text.ToLower())).ToList();
            }
            if (TBSearchTransliteration.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.Transliteration) && p.Transliteration.ToLower().Contains(TBSearchTransliteration.Text.ToLower())).ToList();
            }
            if (TBSearchUnicode.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.Hieroglyphic) && p.Hieroglyphic.ToLower().Contains(TBSearchUnicode.Text.ToLower())).ToList();
            }
            if (TBSearchWords.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.Description) && p.Description.ToLower().Contains(TBSearchWords.Text.ToLower()) 
                || !string.IsNullOrEmpty(p.Type) && p.Type.ToLower().Contains(TBSearchWords.Text.ToLower()) 
                || !string.IsNullOrEmpty(p.View) && p.View.ToLower().Contains(TBSearchWords.Text.ToLower())).ToList();
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
