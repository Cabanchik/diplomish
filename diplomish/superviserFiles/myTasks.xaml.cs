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
        List<string> statuses { get; set; }
        public myTasks()
        {
            InitializeComponent();
            //var p = App.diplomchikEntities.branch.Where(s=> s.task !=null).ToList();

            statuses = new List<string>();          
            brancch.ItemsSource = App.diplomchikEntities.branch.Where(S => S.task.Count != 0).ToList();
            brancch2.ItemsSource = App.diplomchikEntities.user.Where(S => S.task.Count != 0).ToList();
            statuses.AddRange(App.diplomchikEntities.status.Select(s => s.title).ToList());
            statuses.Add("Все");
            statusSort.ItemsSource = statuses;
            statusSort.SelectedItem = statuses[5];
        }

        private void listx1111_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var task123 = (sender as ListView).SelectedItem as task;

            taskEdit editTask = new taskEdit(task123);
            editTask.Show();

        }

        private void userSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            //brancch2.ItemsSource = App.diplomchikEntities.user.Where(S => S.task.Count != 0 && S.name.Contains(userSearch.Text.ToString())).ToList();
        }

        private void statusSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (statusSort.SelectedItem == statuses[5])
            //{
            //    brancch2.ItemsSource = App.diplomchikEntities.user.Where(S => S.task.Count != 0).ToList();
            //}
            //else if (statusSort.SelectedItem == statuses[0])
            //{
            //    var s = App.diplomchikEntities.task.Where(s1 => s1.status_id == 0).Select(s1 => s1.title).FirstOrDefault();
            //    brancch2.ItemsSource = App.diplomchikEntities.user.Where(S => S.task.Count != 0 && s == statuses[1]).ToList();
            //}

        }
    }
}
