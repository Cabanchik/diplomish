using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace diplomish
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly Duration openCloseDuraion = new Duration(TimeSpan.FromSeconds(0.5));

        public static bazedEntities1 diplomchikEntities = new bazedEntities1();

        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            diplomchikEntities = new bazedEntities1();
        }
    }
}
