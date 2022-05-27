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

namespace diplomish
{
    /// <summary>
    /// Логика взаимодействия для myTasks.xaml
    /// </summary>
    public partial class myTasks : Page
    {
        public myTasks()
        {
            InitializeComponent();
            //var p = App.diplomchikEntities.branch.Where(s=> s.task !=null).ToList();
            
                      
            brancch.ItemsSource = App.diplomchikEntities.branch.Where(S => S.task.Count != 0).ToList();
            brancch2.ItemsSource = App.diplomchikEntities.user.Where(S => S.task.Count != 0).ToList();
        }
    }
}
