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
        List<Alphabet> alphabet = App.Context.Alphabet.ToList();
        List<Biliteral> biliteral = App.Context.Biliteral.ToList();
        List<Triliteral> triliteral = App.Context.Triliteral.ToList();
        public AlphabetPage()
        {
            InitializeComponent();
            LViewPhonogram.ItemsSource = alphabet;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (298 * index), 0, 0, 0);

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
    }
}
