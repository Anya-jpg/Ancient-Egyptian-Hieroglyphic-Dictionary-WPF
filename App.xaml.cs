using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EgyptianDictionary
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities.EgyptianDBEntities Context
        {
            get;
        }
        = new Entities.EgyptianDBEntities();
        public static Entities.User CurrentUser = null;
    }
}



