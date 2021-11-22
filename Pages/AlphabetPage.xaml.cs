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
       readonly List<Alphabet> alphabet = App.Context.Alphabet.ToList();
        readonly List<Biliteral> biliteral = App.Context.Biliteral.ToList();
        readonly List<Triliteral> triliteral = App.Context.Triliteral.ToList();
        public AlphabetPage()
        {
            InitializeComponent();
            LViewPhonogram.ItemsSource = alphabet;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(40 + (284 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    LViewPhonogram.ItemsSource = alphabet;
                    break;
                case 1:
                    LViewPhonogram.ItemsSource = biliteral;
                    break;
                case 2:
                    LViewPhonogram.ItemsSource = triliteral;
                    break;
            }
        }
        private void BSearh_Click(object sender, RoutedEventArgs e)
        {
            var alphabets = App.Context.Alphabet.ToList();
            var biliterals = App.Context.Biliteral.ToList();
            var triliterals = App.Context.Triliteral.ToList();

            if (LViewPhonogram.ItemsSource == alphabet)
            {
                if (TBSearchGardiner.Text == "" && TBSearchTransliteration.Text == "" && TBSearchUnicode.Text == "")
                {
                    alphabets = App.Context.Alphabet.ToList();
                }
                if (TBSearchGardiner.Text != "")
                {
                    alphabets = alphabets.Where(p => !string.IsNullOrEmpty(p.gardiner_code) && p.gardiner_code.ToLower().Contains(TBSearchGardiner.Text.ToLower())).ToList();
                }
                if (TBSearchTransliteration.Text != "")
                {
                    alphabets = alphabets.Where(p => !string.IsNullOrEmpty(p.transliteration) && p.transliteration.ToLower().Contains(TBSearchTransliteration.Text.ToLower())).ToList();
                }
                if (TBSearchUnicode.Text != "")
                {
                    alphabets = alphabets.Where(p => !string.IsNullOrEmpty(p.glyph) && p.glyph.ToLower().Contains(TBSearchUnicode.Text.ToLower())).ToList();
                }
                LViewPhonogram.ItemsSource = alphabets;
            }
            if (LViewPhonogram.ItemsSource == biliteral)
            {
                if (TBSearchGardiner.Text == "" && TBSearchTransliteration.Text == "" && TBSearchUnicode.Text == "")
                {
                    biliterals = App.Context.Biliteral.ToList();
                }
                if (TBSearchGardiner.Text != "")
                {
                    biliterals = biliterals.Where(p => !string.IsNullOrEmpty(p.gardiner_code) && p.gardiner_code.ToLower().Contains(TBSearchGardiner.Text.ToLower())).ToList();
                }
                if (TBSearchTransliteration.Text != "")
                {
                    biliterals = biliterals.Where(p => !string.IsNullOrEmpty(p.transliteration) && p.transliteration.ToLower().Contains(TBSearchTransliteration.Text.ToLower())).ToList();
                }
                if (TBSearchUnicode.Text != "")
                {
                    biliterals = biliterals.Where(p => !string.IsNullOrEmpty(p.glyph) && p.glyph.ToLower().Contains(TBSearchUnicode.Text.ToLower())).ToList();
                }
                LViewPhonogram.ItemsSource = biliterals;
            }
            if (LViewPhonogram.ItemsSource == triliteral)
            {
                if (TBSearchGardiner.Text == "" && TBSearchTransliteration.Text == "" && TBSearchUnicode.Text == "")
                {
                    triliterals = App.Context.Triliteral.ToList();
                }
                if (TBSearchGardiner.Text != "")
                {
                    triliterals = triliterals.Where(p => !string.IsNullOrEmpty(p.gardiner_code) && p.gardiner_code.ToLower().Contains(TBSearchGardiner.Text.ToLower())).ToList();
                }
                if (TBSearchTransliteration.Text != "")
                {
                    triliterals = triliterals.Where(p => !string.IsNullOrEmpty(p.transliteration) && p.transliteration.ToLower().Contains(TBSearchTransliteration.Text.ToLower())).ToList();
                }
                if (TBSearchUnicode.Text != "")
                {
                    triliterals = triliterals.Where(p => !string.IsNullOrEmpty(p.glyph) && p.glyph.ToLower().Contains(TBSearchUnicode.Text.ToLower())).ToList();
                }
                LViewPhonogram.ItemsSource = triliterals;
            }
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
