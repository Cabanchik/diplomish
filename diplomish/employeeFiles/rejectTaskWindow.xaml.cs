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
    /// Логика взаимодействия для rejectTaskWindow.xaml
    /// </summary>
    public partial class rejectTaskWindow : Window
    {
        public task task1 { get; set; }
        public rejectTaskWindow(task task)
        {
            InitializeComponent();
            task1 = task;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rejectLine.Text == "" || rejectLine.Text ==  " ")
            {
                MessageBox.Show("Не заполнена причина отказа!");
            }
            else
            {
                task1.status_id = 6;
                task1.reject_com = rejectLine.Text.ToString();
                MessageBox.Show("Задача отклонена");
                this.Close();
            }
            
        }

        private void dwnld_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
