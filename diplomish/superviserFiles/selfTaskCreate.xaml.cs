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

using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace diplomish
{
    /// <summary>
    /// Логика взаимодействия для taskAdd.xaml
    /// </summary>
    public partial class selfTaskCreate : Window
    {
        public user user1 { get; set; }
        List<file> files { get; set; }
        public selfTaskCreate(user user)
        {
            InitializeComponent();
            user1 = user;

        }

        
        task task = new task();



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                task = new task()
                {
                    title = tas.Text.ToString(),
                    annotation = annotation.Text.ToString(),
                    start_time = Convert.ToDateTime(start.Text),
                    end_time = Convert.ToDateTime(end.Text),
                    user_id = user1.id,
                    initiator_id = user1.id,
                    status_id = 1,
                    purpose_time = DateTime.Now

                };
                App.diplomchikEntities.task.Add(task);
                App.diplomchikEntities.SaveChanges();
                MessageBox.Show("Задача создана успешно!");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}

