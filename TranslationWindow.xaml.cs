using System.Windows;

namespace EgyptianDictionary
{
    /// <summary>
    /// Логика взаимодействия для TranslationWindow.xaml
    /// </summary>
    /// 
    public partial class TranslationWindow : Window
    {
        readonly private Entities.Translation _currentTranslation = null;
        public TranslationWindow(Entities.Translation currentTranslation)
        {
            InitializeComponent();
            _currentTranslation = currentTranslation;
            LClient.Content = "Перевод для " + _currentTranslation.ClientName;
            TBOriginal.Text = _currentTranslation.OriginalText;
            TBTask.Text = _currentTranslation.Task;
        }

        private void BSend_Click(object sender, RoutedEventArgs e)
        {
            if (TBResult.Text == "")
            {
                MessageBox.Show("Введите перевод текста!");
                return;
            }
            _currentTranslation.Result = TBResult.Text;
            App.Context.SaveChanges();
            MessageBox.Show("Перевод отправлен!");
            this.Close();
        }
        private void BMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
