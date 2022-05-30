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
    /// Логика взаимодействия для filesWindow.xaml
    /// </summary>
    public partial class filesWindow : Window
    {
        public task task1 { get; set; }
        public filesWindow(task task)
        {
            InitializeComponent();
            task1 = task;
            this.DataContext = task1;
            filess.ItemsSource = task1.file.ToList();
        }
    }
}
