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
    /// Логика взаимодействия для mineTasks.xaml
    /// </summary>
    public partial class mineTasks : Page
    {
        public user user1 { get; set; }
        public mineTasks(user user2)
        {
            InitializeComponent();
            user1 = user2;
            this.DataContext = user1;
            DateTime sosi = DateTime.Now.AddDays(1);
            foreach (var item in App.diplomchikEntities.task)
            {
                if (item.end_time <= DateTime.Now && item.status_id != 3)
                {
                    item.status_id = 5;
                }
            }
            App.diplomchikEntities.SaveChanges();

            view.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 2).ToList();
            if (view.Items.Count == 0)
            {
                view.Visibility = Visibility.Collapsed;
                null1.Visibility = Visibility.Visible;
            }
            view2.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 1).ToList();
            if (view2.Items.Count == 0)
            {
                view2.Visibility = Visibility.Collapsed;
                null2.Visibility = Visibility.Visible;
            }
            view3.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 2 && t.end_time <= sosi && t.end_time >= DateTime.Now).ToList();
            if (view3.Items.Count == 0)
            {
                view3.Visibility = Visibility.Collapsed;
                null3.Visibility = Visibility.Visible;
            }
            view4.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 5).ToList();
            if (view4.Items.Count == 0)
            {
                view4.Visibility = Visibility.Collapsed;
                null4.Visibility = Visibility.Visible;
            }
            view5.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 3).ToList();
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
            //TaskAdd taskAdd = new TaskAdd(user1);
            //taskAdd.ShowDialog();
            //DateTime sosi = DateTime.Now.AddDays(1);
            //view.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 2).ToList();
            //if (view.Items.Count == 0)
            //{
            //    view.Visibility = Visibility.Collapsed;
            //    null1.Visibility = Visibility.Visible;
            //}
            //view2.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 1).ToList();
            //if (view2.Items.Count == 0)
            //{
            //    view2.Visibility = Visibility.Collapsed;
            //    null2.Visibility = Visibility.Visible;
            //}
            //view3.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 2 && t.end_time <= sosi && t.end_time >= DateTime.Now).ToList();
            //if (view3.Items.Count == 0)
            //{
            //    view3.Visibility = Visibility.Collapsed;
            //    null3.Visibility = Visibility.Visible;
            //}
            //view4.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 5).ToList();
            //if (view4.Items.Count == 0)
            //{
            //    view4.Visibility = Visibility.Collapsed;
            //    null4.Visibility = Visibility.Visible;
            //}
            //view5.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 3).ToList();
            //if (view5.Items.Count == 0)
            //{
            //    view5.Visibility = Visibility.Collapsed;
            //    null5.Visibility = Visibility.Visible;
            //}
            //view.UpdateLayout();
            //view2.UpdateLayout();
            //view3.UpdateLayout();
            //view4.UpdateLayout();
            //view5.UpdateLayout();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Вы точно хотите удалить задачу?", "аЛерт", MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                Button delete = sender as Button;
                task deltask = delete.DataContext as task;
                App.diplomchikEntities.task.Remove(deltask);
                App.diplomchikEntities.SaveChanges();
            }
            DateTime sosi = DateTime.Now.AddDays(1);
            view.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 2).ToList();
            if (view.Items.Count == 0)
            {
                view.Visibility = Visibility.Collapsed;
                null1.Visibility = Visibility.Visible;
            }
            view2.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 1).ToList();
            if (view2.Items.Count == 0)
            {
                view2.Visibility = Visibility.Collapsed;
                null2.Visibility = Visibility.Visible;
            }
            view3.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 2 && t.end_time <= sosi && t.end_time >= DateTime.Now).ToList();
            if (view3.Items.Count == 0)
            {
                view3.Visibility = Visibility.Collapsed;
                null3.Visibility = Visibility.Visible;
            }
            view4.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 5).ToList();
            if (view4.Items.Count == 0)
            {
                view4.Visibility = Visibility.Collapsed;
                null4.Visibility = Visibility.Visible;
            }
            view5.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 3).ToList();
            if (view5.Items.Count == 0)
            {
                view5.Visibility = Visibility.Collapsed;
                null5.Visibility = Visibility.Visible;
            }
            view.UpdateLayout();
            view2.UpdateLayout();
            view3.UpdateLayout();
            view4.UpdateLayout();
            view5.UpdateLayout();


        }

        private void view_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var task123 = (sender as ListView).SelectedItem as task;

            //EditTask editTask = new EditTask(task123);
            //editTask.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var s = MessageBox.Show("Вы точно хотите переместить задачу в выполненные?", "аЛерт", MessageBoxButton.OKCancel);
            if (s == MessageBoxResult.OK)
            {
                Button cont = sender as Button;
                task curr = cont.DataContext as task;
                curr.status_id = 3;
                App.diplomchikEntities.SaveChanges();
            }
            DateTime sosi = DateTime.Now.AddDays(1);
            view.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 2).ToList();
            if (view.Items.Count == 0)
            {
                view.Visibility = Visibility.Collapsed;
                null1.Visibility = Visibility.Visible;
            }
            view2.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 1).ToList();
            if (view2.Items.Count == 0)
            {
                view2.Visibility = Visibility.Collapsed;
                null2.Visibility = Visibility.Visible;
            }
            view3.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 2 && t.end_time <= sosi && t.end_time >= DateTime.Now).ToList();
            if (view3.Items.Count == 0)
            {
                view3.Visibility = Visibility.Collapsed;
                null3.Visibility = Visibility.Visible;
            }
            view4.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 5).ToList();
            if (view4.Items.Count == 0)
            {
                view4.Visibility = Visibility.Collapsed;
                null4.Visibility = Visibility.Visible;
            }
            view5.ItemsSource = App.diplomchikEntities.task.Where(t => t.user_id == user1.id && t.status_id == 3).ToList();
            if (view5.Items.Count == 0)
            {
                view5.Visibility = Visibility.Collapsed;
                null5.Visibility = Visibility.Visible;
            }
            view.UpdateLayout();
            view2.UpdateLayout();
            view3.UpdateLayout();
            view4.UpdateLayout();
            view5.UpdateLayout();
        }
    }
}

