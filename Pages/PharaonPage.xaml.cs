using EgyptianDictionary.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EgyptianDictionary.Pages
{
    /// <summary>
    /// Логика взаимодействия для PharaonPage.xaml
    /// </summary>
    public partial class PharaonPage : Page
    {
        readonly List<Pharaoh> pharaohs = App.Context.Pharaoh.ToList();
        public PharaonPage()
        {
            InitializeComponent();
            LViewPharaohs.ItemsSource = pharaohs;
        }
        private void BSearh_Click(object sender, RoutedEventArgs e)
        {
            var modified = App.Context.Pharaoh.ToList();
            if (TBSearchName.Text == "" && TBSearchName.Text == "" && TBSearchWords.Text == "")
            {
                LViewPharaohs.ItemsSource = pharaohs;
            }
            if (TBSearchName.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(TBSearchName.Text.ToLower())).ToList();
            }
            if (TBSearchWords.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.BirthDescription) && p.BirthDescription.ToLower().Contains(TBSearchWords.Text.ToLower())
                || !string.IsNullOrEmpty(p.ThroneDescription) && p.ThroneDescription.ToLower().Contains(TBSearchWords.Text.ToLower())
                || !string.IsNullOrEmpty(p.Dynasty) && p.Dynasty.ToLower().Contains(TBSearchWords.Text.ToLower())).ToList();
            }
            LViewPharaohs.ItemsSource = modified;
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
