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
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class DictionaryPage : Page
    {
        readonly List<Dictionary> dictionary = App.Context.Dictionary.ToList();
        public DictionaryPage()
        {
            InitializeComponent();
            LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "A").ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(15 + (32 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "A").ToList();
                    break;
                case 1:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "B").ToList();
                    break;
                case 2:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "C").ToList();
                    break;
                case 3:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "D").ToList();
                    break;
                case 4:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "E").ToList();
                    break;
                case 5:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "F").ToList();
                    break;
                case 6:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "G").ToList();
                    break;
                case 7:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "H").ToList();
                    break;
                case 8:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "I").ToList();
                    break;
                case 9:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "K").ToList();
                    break;
                case 10:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "L").ToList();
                    break;
                case 11:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "M").ToList();
                    break;
                case 12:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "N").ToList();
                    break;
                case 13:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "NU").ToList();
                    break;
                case 14:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "NL").ToList();
                    break;
                case 15:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "O").ToList();
                    break;
                case 16:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "P").ToList();
                    break;
                case 17:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "Q").ToList();
                    break;
                case 18:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "R").ToList();
                    break;
                case 19:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "S").ToList();
                    break;
                case 20:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "T").ToList();
                    break;
                case 21:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "U").ToList();
                    break;
                case 22:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "V").ToList();
                    break;
                case 23:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "W").ToList();
                    break;
                case 24:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "X").ToList();
                    break;
                case 25:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "Y").ToList();
                    break;
                case 26:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "Z").ToList();
                    break;
                case 27:
                    LViewDictionary.ItemsSource = dictionary.Where(p => p.Categoria == "Aa").ToList();
                    break;
            }
            
        }

        private void BSearh_Click(object sender, RoutedEventArgs e)
        {
            var modified = App.Context.Dictionary.ToList();
            if (TBSearchGardiner.Text == "" && TBSearchTransliteration.Text == "" && TBSearchUnicode.Text == "" && TBSearchWords.Text == "")
            {
                LViewDictionary.ItemsSource = dictionary;
            }
            if (TBSearchGardiner.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.GardinerCode) && p.GardinerCode.ToLower().Contains(TBSearchGardiner.Text.ToLower())).ToList();
            }
            if (TBSearchTransliteration.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.Transliteration) && p.Transliteration.ToLower().Contains(TBSearchTransliteration.Text.ToLower())).ToList();
            }
            if (TBSearchUnicode.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.Glyph) && p.Glyph.ToLower().Contains(TBSearchUnicode.Text.ToLower())).ToList();
            }
            if (TBSearchWords.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.Description) && p.Description.ToLower().Contains(TBSearchWords.Text.ToLower())
                || !string.IsNullOrEmpty(p.Notes) && p.Notes.ToLower().Contains(TBSearchWords.Text.ToLower())
                || !string.IsNullOrEmpty(p.Phonogram) && p.Phonogram.ToLower().Contains(TBSearchWords.Text.ToLower())).ToList();
            }
            LViewDictionary.ItemsSource = modified;
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
