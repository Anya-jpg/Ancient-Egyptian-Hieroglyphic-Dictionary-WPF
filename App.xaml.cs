using EgyptianDictionary.Entities;
using System.Data.Entity;
using System.Windows;

namespace EgyptianDictionary
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static Entities.User CurrentUser = null;
    }
}



