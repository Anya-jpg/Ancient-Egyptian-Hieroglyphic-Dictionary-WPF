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
        readonly List<Dictionary_ru> dictionary_ru = App.Context.Dictionary_ru.ToList();
        public DictionaryPage()
        {
            InitializeComponent();
            LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "A").ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(15 + (32 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "A").ToList();
                    break;
                case 1:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "B").ToList();
                    break;
                case 2:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "C").ToList();
                    break;
                case 3:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "D").ToList();
                    break;
                case 4:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "E").ToList();
                    break;
                case 5:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "F").ToList();
                    break;
                case 6:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "G").ToList();
                    break;
                case 7:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "H").ToList();
                    break;
                case 8:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "I").ToList();
                    break;
                case 9:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "K").ToList();
                    break;
                case 10:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "L").ToList();
                    break;
                case 11:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "M").ToList();
                    break;
                case 12:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "N").ToList();
                    break;
                case 13:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "NU").ToList();
                    break;
                case 14:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "NL").ToList();
                    break;
                case 15:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "O").ToList();
                    break;
                case 16:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "P").ToList();
                    break;
                case 17:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "Q").ToList();
                    break;
                case 18:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "R").ToList();
                    break;
                case 19:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "S").ToList();
                    break;
                case 20:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "T").ToList();
                    break;
                case 21:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "U").ToList();
                    break;
                case 22:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "V").ToList();
                    break;
                case 23:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "W").ToList();
                    break;
                case 24:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "X").ToList();
                    break;
                case 25:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "Y").ToList();
                    break;
                case 26:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "Z").ToList();
                    break;
                case 27:
                    LViewDictionary.ItemsSource = dictionary_ru.Where(p => p.categoria == "Aa").ToList();
                    break;
            }
            
        }

        private void BSearh_Click(object sender, RoutedEventArgs e)
        {
            var modified = App.Context.Dictionary_ru.ToList();
            if (TBSearchGardiner.Text == "" && TBSearchTransliteration.Text == "" && TBSearchUnicode.Text == "" && TBSearchWords.Text == "")
            {
                LViewDictionary.ItemsSource = dictionary_ru;
            }
            if (TBSearchGardiner.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.gardiner_code) && p.gardiner_code.ToLower().Contains(TBSearchGardiner.Text.ToLower())).ToList();
            }
            if (TBSearchTransliteration.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.transliteration) && p.transliteration.ToLower().Contains(TBSearchTransliteration.Text.ToLower())).ToList();
            }
            if (TBSearchUnicode.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.glyph) && p.glyph.ToLower().Contains(TBSearchUnicode.Text.ToLower())).ToList();
            }
            if (TBSearchWords.Text != "")
            {
                modified = modified.Where(p => !string.IsNullOrEmpty(p.description) && p.description.ToLower().Contains(TBSearchWords.Text.ToLower())
                || !string.IsNullOrEmpty(p.notes) && p.notes.ToLower().Contains(TBSearchWords.Text.ToLower())
                || !string.IsNullOrEmpty(p.phonogram) && p.phonogram.ToLower().Contains(TBSearchWords.Text.ToLower())).ToList();
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
