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
    /// Логика взаимодействия для taskInfo.xaml
    /// </summary>
    public partial class taskInfo : Window
    {
        public task task1 { get; set; }
        public taskInfo(task task)
        {
            BrushConverter bc = new BrushConverter();
            InitializeComponent();
            task1 = task;
            title.Text = task.title;
            anno.Text = task.annotation;
            start_time.Value = task.start_time;
            end_time.Value = task.end_time;
            statusBox.Text = task.status.title.ToString();
            if (task.status_id == 1)
            {
                statusBox.Foreground = (Brush)bc.ConvertFrom("#49a303");
            }
            else if (task.status_id == 2)
            {
                statusBox.Foreground = (Brush)bc.ConvertFrom("#007d00");
            }
            else if (task.status_id == 3)
            {
                statusBox.Foreground = (Brush)bc.ConvertFrom("#7d0000");
            }
            else if (task.status_id == 4)
            {
                statusBox.Foreground = (Brush)bc.ConvertFrom("#450303");
            }
            else if (task.status_id == 5)
            {
                statusBox.Foreground = (Brush)bc.ConvertFrom("#ff9d00");
            }
            else if (task.status_id == 6)
            {
                statusBox.Foreground = (Brush)bc.ConvertFrom("#49a303");
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void filesBtn_Click(object sender, RoutedEventArgs e)
        {
            filesWindow filesWindow = new filesWindow(task1);
            filesWindow.ShowDialog();

        }
    }
}
