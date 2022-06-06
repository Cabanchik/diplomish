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

namespace diplomish.admFiles
{
    /// <summary>
    /// Логика взаимодействия для admPage.xaml
    /// </summary>
    public partial class admPage : Page
    {
        public admPage()
        {
            InitializeComponent();
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new addEmployee());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new admUsersPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new admFilesPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new admTaskPage());
        }
    }
}
