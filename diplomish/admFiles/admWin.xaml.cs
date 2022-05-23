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
        public admWin()
        {
            InitializeComponent();
            admFiles.admPage addEmployee = new admFiles.admPage();
            sa.Content = addEmployee;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (sa.CanGoBack == true)
            {
                sa.GoBack();

            }
        }
    }
}
