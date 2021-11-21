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
using System.Windows.Shapes;

namespace EgyptianDictionary
{
    /// <summary>
    /// Логика взаимодействия для TranslationWindow.xaml
    /// </summary>
    /// 
    public partial class TranslationWindow : Window
    {
        private Entities.Translation _currentTranslation = null;
        public TranslationWindow(Entities.Translation currentTranslation)
        {
            InitializeComponent();
            _currentTranslation = currentTranslation;
            LClient.Content = "Перевод для " + _currentTranslation.clientName;
            TBOriginal.Text = _currentTranslation.originalText;
            TBTask.Text = _currentTranslation.task;
        }

        private void BSend_Click(object sender, RoutedEventArgs e)
        {
            if (TBResult.Text == "")
            {
                MessageBox.Show("Введдите данные!");
                return;
            }
            _currentTranslation.result = TBResult.Text;
            App.Context.SaveChanges();
            MessageBox.Show("Перевод отправлен!");
            this.Close();
        }
    }
}
