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

namespace diplomish
{
    /// <summary>
    /// Логика взаимодействия для admWin.xaml
    /// </summary>
    public partial class admWin : Window
    {
        public static admWin Instance { get; private set; }
        public admWin()
        {
            InitializeComponent();
            
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            stack.Visibility = Visibility.Collapsed;
            frame.Visibility = Visibility.Visible;
            frame.NavigationService.Navigate(new addEmployee());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.mainFrame.Content = new admUsersPage();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.mainFrame.Content = new admFilesPage();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.mainFrame.Content = new admTaskPage();
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
               
    }
}
