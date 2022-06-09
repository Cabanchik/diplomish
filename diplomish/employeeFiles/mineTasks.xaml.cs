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
    /// Логика взаимодействия для mineTasks.xaml
    /// </summary>
    public partial class mineTasks : Page
    {
        public user user1 { get; set; }
        public mineTasks(user user2)
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
            user1 = user2;
            DateTime nw = DateTime.Now + TimeSpan.FromMinutes(3); 
            this.DataContext = user1;
            
            foreach (var item in App.diplomchikEntities.task)
            {
                if (item.end_time <= DateTime.Now && item.status_id ==  1)
                {
                    item.status = App.diplomchikEntities.status.Where(x => x.id == 4).FirstOrDefault();
                }
            }
            App.diplomchikEntities.SaveChanges();
            DateTime endSoon = DateTime.Now.AddDays(1);
            DateTime nowPlus3 = DateTime.Now.AddDays(3);
            view.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 5 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 5 && t.is_deleted != 1)).ToList();
            if (view.Items.Count == 0)
            {
                view.Visibility = Visibility.Collapsed;
                null1.Visibility = Visibility.Visible;
            }
            view2.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view2.Items.Count == 0)
            {
                view2.Visibility = Visibility.Collapsed;
                null2.Visibility = Visibility.Visible;
            }
            view3.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view3.Items.Count == 0)
            {
                view3.Visibility = Visibility.Collapsed;
                null3.Visibility = Visibility.Visible;
            }
            view4.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 4 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 4 && t.is_deleted != 1)).ToList();
            if (view4.Items.Count == 0)
            {
                view4.Visibility = Visibility.Collapsed;
                null4.Visibility = Visibility.Visible;
            }
            view5.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 2 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 2 && t.is_deleted != 1 && t.end_time == nowPlus3)).ToList();
            if (view5.Items.Count == 0)
            {
                view5.Visibility = Visibility.Collapsed;
                null5.Visibility = Visibility.Visible;
            }

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach (var item in App.diplomchikEntities.task)
            {
                if (item.end_time <= DateTime.Now && item.status_id == 1)
                {
                    item.status = App.diplomchikEntities.status.Where(x => x.id == 4).FirstOrDefault();
                }
            }
            App.diplomchikEntities.SaveChanges();
            DateTime endSoon = DateTime.Now.AddDays(1);
            DateTime nowPlus3 = DateTime.Now.AddDays(3);
            view.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 5 && t.is_deleted != 1) || 
            (t.brach_id == user1.branch_id && t.status_id == 5 && t.is_deleted != 1)).ToList();
            if (view.Items.Count == 0)
            {
                view.Visibility = Visibility.Collapsed;
                null1.Visibility = Visibility.Visible;
            }
            view2.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.is_deleted != 1) || 
            (t.brach_id == user1.branch_id && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view2.Items.Count == 0)
            {
                view2.Visibility = Visibility.Collapsed;
                null2.Visibility = Visibility.Visible;
            }
            view3.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.is_deleted != 1) || 
            (t.brach_id == user1.branch_id && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view3.Items.Count == 0)
            {
                view3.Visibility = Visibility.Collapsed;
                null3.Visibility = Visibility.Visible;
            }
            view4.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 4 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 4 && t.is_deleted != 1)).ToList();
            if (view4.Items.Count == 0)
            {
                view4.Visibility = Visibility.Collapsed;
                null4.Visibility = Visibility.Visible;
            }
            view5.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 2 && t.is_deleted != 1) || 
            (t.brach_id == user1.branch_id && t.status_id == 2 && t.is_deleted != 1 && t.end_time == nowPlus3)).ToList();
            if (view5.Items.Count == 0)
            {
                view5.Visibility = Visibility.Collapsed;
                null5.Visibility = Visibility.Visible;
            }
        }

        public static int DTime(DateTime date)
        {
            TimeSpan dii = DateTime.Now - date;
            return dii.Days;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var item in App.diplomchikEntities.task)
            {
                if (item.end_time <= DateTime.Now && item.status_id == 1)
                {
                    item.status = App.diplomchikEntities.status.Where(x => x.id == 4).FirstOrDefault();
                }
            }
            App.diplomchikEntities.SaveChanges();
            DateTime endSoon = DateTime.Now.AddDays(1);
            DateTime nowPlus3 = DateTime.Now.AddDays(3);
            view.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 5 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 5 && t.is_deleted != 1)).ToList();
            if (view.Items.Count == 0)
            {
                view.Visibility = Visibility.Collapsed;
                null1.Visibility = Visibility.Visible;
            }
            view2.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view2.Items.Count == 0)
            {
                view2.Visibility = Visibility.Collapsed;
                null2.Visibility = Visibility.Visible;
            }
            view3.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view3.Items.Count == 0)
            {
                view3.Visibility = Visibility.Collapsed;
                null3.Visibility = Visibility.Visible;
            }
            view4.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 4 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 4 && t.is_deleted != 1)).ToList();
            if (view4.Items.Count == 0)
            {
                view4.Visibility = Visibility.Collapsed;
                null4.Visibility = Visibility.Visible;
            }
            view5.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 2 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 2 && t.is_deleted != 1 && t.end_time == nowPlus3)).ToList();
            if (view5.Items.Count == 0)
            {
                view5.Visibility = Visibility.Collapsed;
                null5.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Вы точно хотите удалить задачу?", "Внимание", MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                Button delete = sender as Button;
                task deltask = delete.DataContext as task;
                deltask.is_deleted = 1;
                App.diplomchikEntities.SaveChanges();
            }
            foreach (var item in App.diplomchikEntities.task)
            {
                if (item.end_time <= DateTime.Now && item.status_id == 1)
                {
                    item.status = App.diplomchikEntities.status.Where(x => x.id == 4).FirstOrDefault();
                }
            }
            App.diplomchikEntities.SaveChanges();
            DateTime endSoon = DateTime.Now.AddDays(1);
            DateTime nowPlus3 = DateTime.Now.AddDays(3);
            view.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 5 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 5 && t.is_deleted != 1)).ToList();
            if (view.Items.Count == 0)
            {
                view.Visibility = Visibility.Collapsed;
                null1.Visibility = Visibility.Visible;
            }
            view2.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view2.Items.Count == 0)
            {
                view2.Visibility = Visibility.Collapsed;
                null2.Visibility = Visibility.Visible;
            }
            view3.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view3.Items.Count == 0)
            {
                view3.Visibility = Visibility.Collapsed;
                null3.Visibility = Visibility.Visible;
            }
            view4.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 4 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 4 && t.is_deleted != 1)).ToList();
            if (view4.Items.Count == 0)
            {
                view4.Visibility = Visibility.Collapsed;
                null4.Visibility = Visibility.Visible;
            }
            view5.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 2 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 2 && t.is_deleted != 1 && t.end_time == nowPlus3)).ToList();
            if (view5.Items.Count == 0)
            {
                view5.Visibility = Visibility.Collapsed;
                null5.Visibility = Visibility.Visible;
            }
        }

        private void view_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var s = MessageBox.Show("Вы точно хотите переместить задачу в выполненные?", "Внимание", MessageBoxButton.OKCancel);
            if (s == MessageBoxResult.OK)
            {
                Button cont = sender as Button;
                task curr = cont.DataContext as task;
                curr.status_id = 2;
                curr.end_time = DateTime.Now;
                App.diplomchikEntities.SaveChanges();
            }
            foreach (var item in App.diplomchikEntities.task)
            {
                if (item.end_time <= DateTime.Now && item.status_id == 1)
                {
                    item.status = App.diplomchikEntities.status.Where(x => x.id == 4).FirstOrDefault();
                }
            }
            App.diplomchikEntities.SaveChanges();
            DateTime endSoon = DateTime.Now.AddDays(1);
            DateTime nowPlus3 = DateTime.Now.AddDays(3);
            view.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 5 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 5 && t.is_deleted != 1)).ToList();
            if (view.Items.Count == 0)
            {
                view.Visibility = Visibility.Collapsed;
                null1.Visibility = Visibility.Visible;
            }
            view2.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view2.Items.Count == 0)
            {
                view2.Visibility = Visibility.Collapsed;
                null2.Visibility = Visibility.Visible;
            }
            view3.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view3.Items.Count == 0)
            {
                view3.Visibility = Visibility.Collapsed;
                null3.Visibility = Visibility.Visible;
            }
            view4.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 4 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 4 && t.is_deleted != 1)).ToList();
            if (view4.Items.Count == 0)
            {
                view4.Visibility = Visibility.Collapsed;
                null4.Visibility = Visibility.Visible;
            }
            view5.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 2 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 2 && t.is_deleted != 1 && t.end_time == nowPlus3)).ToList();
            if (view5.Items.Count == 0)
            {
                view5.Visibility = Visibility.Collapsed;
                null5.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var s = MessageBox.Show("Вы точно хотите принять задачу?", "Внимание", MessageBoxButton.OKCancel);
            if (s == MessageBoxResult.OK)
            {
                Button cont = sender as Button;
                task curr = cont.DataContext as task;
                curr.status_id = 1;
                App.diplomchikEntities.SaveChanges();
            }
            foreach (var item in App.diplomchikEntities.task)
            {
                if (item.end_time <= DateTime.Now && item.status_id == 1)
                {
                    item.status = App.diplomchikEntities.status.Where(x => x.id == 4).FirstOrDefault();
                }
            }
            App.diplomchikEntities.SaveChanges();
            DateTime endSoon = DateTime.Now.AddDays(1);
            DateTime nowPlus3 = DateTime.Now.AddDays(3);
            view.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 5 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 5 && t.is_deleted != 1)).ToList();
            if (view.Items.Count == 0)
            {
                view.Visibility = Visibility.Collapsed;
                null1.Visibility = Visibility.Visible;
            }
            view2.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view2.Items.Count == 0)
            {
                view2.Visibility = Visibility.Collapsed;
                null2.Visibility = Visibility.Visible;
            }
            view3.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view3.Items.Count == 0)
            {
                view3.Visibility = Visibility.Collapsed;
                null3.Visibility = Visibility.Visible;
            }
            view4.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 4 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 4 && t.is_deleted != 1)).ToList();
            if (view4.Items.Count == 0)
            {
                view4.Visibility = Visibility.Collapsed;
                null4.Visibility = Visibility.Visible;
            }
            view5.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 2 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 2 && t.is_deleted != 1 && t.end_time == nowPlus3)).ToList();
            if (view5.Items.Count == 0)
            {
                view5.Visibility = Visibility.Collapsed;
                null5.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Button cont = sender as Button;
            task curr = cont.DataContext as task;
            rejectTaskWindow rejectTaskWindow = new rejectTaskWindow(curr);
            rejectTaskWindow.ShowDialog();
            foreach (var item in App.diplomchikEntities.task)
            {
                if (item.end_time <= DateTime.Now && item.status_id == 1)
                {
                    item.status = App.diplomchikEntities.status.Where(s => s.id == 4).FirstOrDefault();
                }
            }
            App.diplomchikEntities.SaveChanges();
            DateTime endSoon = DateTime.Now.AddDays(1);
            DateTime nowPlus3 = DateTime.Now.AddDays(3);
            view.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 5 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 5 && t.is_deleted != 1)).ToList();
            if (view.Items.Count == 0)
            {
                view.Visibility = Visibility.Collapsed;
                null1.Visibility = Visibility.Visible;
            }
            view2.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view2.Items.Count == 0)
            {
                view2.Visibility = Visibility.Collapsed;
                null2.Visibility = Visibility.Visible;
            }
            view3.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 1 && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.end_time <= endSoon && t.end_time >= DateTime.Now && t.status_id == 1 && t.is_deleted != 1)).ToList();
            if (view3.Items.Count == 0)
            {
                view3.Visibility = Visibility.Collapsed;
                null3.Visibility = Visibility.Visible;
            }
            view4.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 4 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 4 && t.is_deleted != 1)).ToList();
            if (view4.Items.Count == 0)
            {
                view4.Visibility = Visibility.Collapsed;
                null4.Visibility = Visibility.Visible;
            }
            view5.ItemsSource = App.diplomchikEntities.task.Where(t => (t.user_id == user1.id && t.status_id == 2 && t.is_deleted != 1) || (t.brach_id == user1.branch_id && t.status_id == 2 && t.is_deleted != 1 && t.end_time == nowPlus3)).ToList();
            if (view5.Items.Count == 0)
            {
                view5.Visibility = Visibility.Collapsed;
                null5.Visibility = Visibility.Visible;
            }
        }

        private void view_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var task123 = (sender as ListView).SelectedItem as task;

            taskInfo editTask = new taskInfo(task123);
            if (editTask != null)
            {
                editTask.ShowDialog();
            }
        }
    }
}

