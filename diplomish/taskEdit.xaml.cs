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
        public task task1 { get; set; }
        public taskEdit(task task)
        {
            
            InitializeComponent();
            task1 = task;
            if (task1.user_id == null)
            {
                performer.ItemsSource = App.diplomchikEntities.branch.Select(s => s.title).ToList();
                performer.SelectedItem = task1.branch.title;
            }
            else
            {
                performer.ItemsSource = App.diplomchikEntities.user.Select(s => s.surname + " " + s.name).ToList();
                performer.SelectedItem = App.diplomchikEntities.user.Where(s => s.id == task1.user_id).Select(s => s.surname + " " + s.name).FirstOrDefault().ToString();
            }
            
            title.Text = task1.title;
            anno.Text = task1.annotation;
            start_time.Text = task1.start_time.ToString();
            end_time.Text = task1.end_time.ToString();
            statusBox.ItemsSource = App.diplomchikEntities.status.Select(s => s.title).ToList();
            statusBox.SelectedItem = App.diplomchikEntities.status.Where(s => s.id == task1.status_id).Select(s => s.title).FirstOrDefault().ToString();



        }

        private void filesBtn_Click(object sender, RoutedEventArgs e)
        {
            filesWindow filesWindow = new filesWindow(task1);
            filesWindow.ShowDialog();
        }
    }
}
