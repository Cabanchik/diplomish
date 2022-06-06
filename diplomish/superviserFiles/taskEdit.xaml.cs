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
    /// Логика взаимодействия для taskEdit.xaml
    /// </summary>
    public partial class taskEdit : Window
    {
        List<string> performers {get;set;}
        public task task1 { get; set; }
        public taskEdit(task task)
        {
            performers = new List<string>();
            InitializeComponent();
            task1 = task;
            performers.AddRange(App.diplomchikEntities.branch.Select(s => s.title).ToList());
            performers.AddRange(App.diplomchikEntities.user.Select(s => s.surname + " " + s.name).ToList());
            performer.ItemsSource = performers;
            if (task1.user_id == null)
            {
                
                performer.SelectedItem = task1.branch.title;
            }
            else
            {
                
                performer.SelectedItem = App.diplomchikEntities.user.Where(s => s.id == task1.user_id).Select(s => s.surname + " " + s.name).FirstOrDefault().ToString();
            }
            
            title.Text = task1.title;
            anno.Text = task1.annotation;
            start_time.Value = task1.start_time;
            end_time.Value = task1.end_time;
            statusBox.Content = task1.status.title;

        }

        private void filesBtn_Click(object sender, RoutedEventArgs e)
        {
            filesWindow filesWindow = new filesWindow(task1);
            filesWindow.ShowDialog();
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void taskEditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                task1.title = title.Text.ToString();
                task1.annotation = anno.Text.ToString();
                try
                {
                    task1.start_time = Convert.ToDateTime(start_time.Text);

                }
                catch (Exception)
                {
                    task1.start_time = null;
                }
                try
                {
                    task1.end_time = Convert.ToDateTime(end_time.Text);
                }
                catch (Exception)
                {
                    task1.end_time = null;
                }
                var pr = App.diplomchikEntities.user.Where(s => s.surname + " " + s.name == performer.SelectedItem).Select(s => s.id).FirstOrDefault();
                if (pr == 0)
                {
                    task1.brach_id = App.diplomchikEntities.branch.Where(s => s.title == performer.SelectedItem).Select(s => s.id).FirstOrDefault();
                    task1.user_id = null;
                }
                else
                {
                    task1.user_id = App.diplomchikEntities.user.Where(s => s.surname + " " + s.name == performer.SelectedItem).Select(s => s.id).FirstOrDefault();
                    task1.brach_id = null;
                }


                App.diplomchikEntities.SaveChanges();
                MessageBox.Show("Изменения внесены успешно");
            }
            catch (Exception)
            {

                MessageBox.Show("Изменения не были внесены");
            }
            

        }

        private void taskDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Вы точно хотите удалить задачу?", "Внимание", MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                task1.is_deleted = 1;
                App.diplomchikEntities.SaveChanges();
            }
        }
               
    }
}
