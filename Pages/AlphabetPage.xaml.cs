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
    /// Логика взаимодействия для AlphabetPage.xaml
    /// </summary>
    public partial class AlphabetPage : Page
    {
       readonly List<Phonogram> phonograms = App.Context.Phonogram.ToList();
        public AlphabetPage()
        {
            InitializeComponent();
            LViewPhonogram.ItemsSource = phonograms.Where(p => p.Type == "alphabet").ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(40 + (284 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    LViewPhonogram.ItemsSource = phonograms.Where(p => p.Type == "alphabet").ToList();
                    break;
                case 1:
                    LViewPhonogram.ItemsSource = phonograms.Where(p => p.Type == "biliteral").ToList();
                    break;
                case 2:
                    LViewPhonogram.ItemsSource = phonograms.Where(p => p.Type == "triliteral").ToList();
                    break;
            }
        }
        private void BSearh_Click(object sender, RoutedEventArgs e)
        {
            var _phonograms = App.Context.Phonogram.ToList();

                if (TBSearchGardiner.Text == "" && TBSearchTransliteration.Text == "" && TBSearchUnicode.Text == "")
                {
                _phonograms = App.Context.Phonogram.ToList();
                }
                if (TBSearchGardiner.Text != "")
                {
                _phonograms = _phonograms.Where(p => !string.IsNullOrEmpty(p.GardinerCode) && p.GardinerCode.ToLower().Contains(TBSearchGardiner.Text.ToLower())).ToList();
                }
                if (TBSearchTransliteration.Text != "")
                {
                _phonograms = _phonograms.Where(p => !string.IsNullOrEmpty(p.Transliteration) && p.Transliteration.ToLower().Contains(TBSearchTransliteration.Text.ToLower())).ToList();
                }
                if (TBSearchUnicode.Text != "")
                {
                _phonograms = _phonograms.Where(p => !string.IsNullOrEmpty(p.Glyph) && p.Glyph.ToLower().Contains(TBSearchUnicode.Text.ToLower())).ToList();
                }
                LViewPhonogram.ItemsSource = _phonograms;
           
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
