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
using System.Windows.Threading;

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
            App.diplomchikEntities = new diplomkchikEntities();
            statuses = new List<string>();
            brancch.ItemsSource = App.diplomchikEntities.branch.Where(S => S.task.Count != 0 && S.task.Where(t => t.initiator_id == staticUser.user.id && t.is_deleted != 1).Count() > 0).ToList();
            //var l = staticUser.user.task1.ToList();
            brancch2.ItemsSource = App.diplomchikEntities.user.Where(S => S.task.Count != 0 && S.task.Where(t=>t.initiator_id == staticUser.user.id && t.is_deleted != 1).Count() > 0 && S.id != staticUser.user.id).ToList();
            statuses.AddRange(App.diplomchikEntities.status.Select(s => s.title).ToList());
            statuses.Add("Все");
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
            
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            App.diplomchikEntities = new diplomkchikEntities();
            brancch.ItemsSource = null;
            brancch2.ItemsSource = null;
            brancch.ItemsSource = App.diplomchikEntities.branch.Where(S => S.task.Count != 0 && S.task.Where(t => t.initiator_id == staticUser.user.id && t.is_deleted != 1).Count() > 0).ToList();
            brancch2.ItemsSource = App.diplomchikEntities.user.Where(S => S.task.Count != 0 && S.task.Where(t => t.initiator_id == staticUser.user.id && t.is_deleted != 1).Count() > 0 && S.id != staticUser.user.id).ToList();
        }

        private void listx1111_MouseDoubleClick_2(object sender, MouseButtonEventArgs e)
        {
            var task123 = (sender as ListView).SelectedItem as task;

            taskEdit editTask = new taskEdit(task123);
            editTask.Show();
            brancch.ItemsSource = App.diplomchikEntities.branch.Where(S => S.task.Count != 0 && S.task.Where(t => t.initiator_id == staticUser.user.id && t.is_deleted != 1).Count() > 0).ToList();
            brancch2.ItemsSource = App.diplomchikEntities.user.Where(S => S.task.Count != 0 && S.task.Where(t => t.initiator_id == staticUser.user.id && t.is_deleted != 1).Count() > 0 && S.id != staticUser.user.id).ToList();

        }
    }
}
