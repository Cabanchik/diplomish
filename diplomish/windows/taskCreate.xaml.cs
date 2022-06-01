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
    public partial class taskCreate : Window
    {
        bool isAdded { get; set; }
        public user user1 { get; set; }
        List<file> files { get; set; }
        public taskCreate(user user)
        {
            InitializeComponent();
            //var br = App.diplomchikEntities.branch.Select(s => s.title).ToList();
            //branch.ItemsSource = br;
            user1 = user;
            branch.ItemsSource = App.diplomchikEntities.user.Select(s => s.surname + " " + s.name).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Office Files|*.doc;*.xls;*.ppt*;*.docx;*.pptx;*.csv;*.xlsx*";
            //openFileDialog.Multiselect = true;

            //string filedata;
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    if (openFileDialog.FileNames != null)
            //    {
            //        filess.Visibility = Visibility.Visible;

            //        try
            //        {
            //            files = new List<file>();
            //            //foreach (string filename in openFileDialog.FileNames)
            //            //filess.Items.Add(Path.GetFileName(filename));
            //            filedata = File.ReadAllText(openFileDialog.FileName);
            //            foreach (var item in openFileDialog.FileNames)
            //            {

            //                FileStream fs = new FileStream(item, FileMode.Open, FileAccess.Read);
            //                //s.Add(Path.GetFileNameWithoutExtension(item));
            //                // Create a byte array of file stream length
            //                byte[] bytes = System.IO.File.ReadAllBytes(item);
            //                var ex = Path.GetExtension(item);
            //                var name = Path.GetFileNameWithoutExtension(item);
            //                //Read block of bytes from stream into the byte array
            //                fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));


            //                //Close the File Stream
            //                fs.Close();
            //                file file = new file()
            //                {
            //                    file1 = bytes,
            //                    extention = ex,
            //                    upload_date = DateTime.Now,
            //                    filename = name,
            //                    uploader_id = user1.id,

            //                };
            //                files.Add(file);
            //                App.diplomchikEntities.file.Add(file);
            //                //App.diplomchikEntities.SaveChanges();

            //            }
            //            filess.ItemsSource = files;


            //        }
            //        catch (Exception)
            //        {

            //            MessageBox.Show("Произошла ошибка");
            //        }
            //    }

            //}
            if (branch.SelectedItem != null)
            {
                var us = App.diplomchikEntities.user.Where(s => s.surname + " " + s.name == branch.SelectedItem.ToString()).Select(s => s.id).FirstOrDefault();
                var bran = App.diplomchikEntities.branch.Where(s => s.title == branch.SelectedItem.ToString()).Select(s => s.id).FirstOrDefault();



                if (us == 0)
                {
                    task = new task()
                    {
                        title = tas.Text.ToString(),
                        annotation = annotation.Text.ToString(),
                        start_time = Convert.ToDateTime(start.Text),
                        end_time = Convert.ToDateTime(end.Text),
                        user_id = null,
                        brach_id = Convert.ToInt32(bran),

                    };
                    isAdded = true;
                    App.diplomchikEntities.task.Add(task);

                    App.diplomchikEntities.SaveChanges();

                }
                else if (bran == 0)
                {
                    task = new task()
                    {
                        title = tas.Text.ToString(),
                        annotation = annotation.Text.ToString(),
                        start_time = Convert.ToDateTime(start.Text),
                        end_time = Convert.ToDateTime(end.Text),
                        user_id = Convert.ToInt32(us),
                        brach_id = null,
                        initiator_id = user1.id,


                    };
                    isAdded = true;
                    App.diplomchikEntities.task.Add(task);

                    App.diplomchikEntities.SaveChanges();
                }
            }
            else
            {
                task = new task()
                {
                    title = tas.Text.ToString(),
                    annotation = annotation.Text.ToString(),
                    start_time = Convert.ToDateTime(start.Text),
                    end_time = Convert.ToDateTime(end.Text),
                    user_id = null,
                    brach_id = null

                };
                isAdded = true;
                App.diplomchikEntities.task.Add(task);
                App.diplomchikEntities.SaveChanges();
            }

           
            filesWindow filesWindow = new filesWindow(task);
            filesWindow.ShowDialog();



        }
        task task = new task();
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (isAdded == false)
            {
                var us = App.diplomchikEntities.user.Where(s => s.surname + " " + s.name == branch.SelectedItem.ToString()).Select(s => s.id).FirstOrDefault();
                var bran = App.diplomchikEntities.branch.Where(s => s.title == branch.SelectedItem.ToString()).Select(s => s.id).FirstOrDefault();
                int perf;

                if (us == 0)
                {
                    task = new task()
                    {
                        title = tas.Text.ToString(),
                        annotation = annotation.Text.ToString(),
                        start_time = Convert.ToDateTime(start.Text),
                        end_time = Convert.ToDateTime(end.Text),
                        user_id = null,
                        brach_id = Convert.ToInt32(bran),
                        initiator_id = user1.id

                    };
                }
                else if (bran == 0)
                {
                    task = new task()
                    {
                        title = tas.Text.ToString(),
                        annotation = annotation.Text.ToString(),
                        start_time = Convert.ToDateTime(start.Text),
                        end_time = Convert.ToDateTime(end.Text),
                        user_id = Convert.ToInt32(us),
                        brach_id = null,
                        initiator_id = user1.id,
                        status_id = 1

                    };
                }
            }
            else
            {
                task.title = tas.Text.ToString();
                task.annotation = annotation.Text.ToString();
                try
                {
                    task.start_time = Convert.ToDateTime(start.Text);

                }
                catch (Exception)
                {
                    task.start_time = null;
                }
                try
                {
                    task.end_time = Convert.ToDateTime(end.Text);
                }
                catch (Exception)
                {
                    task.end_time = null;
                }
                var pr = App.diplomchikEntities.user.Where(s => s.surname + " " + s.name == branch.SelectedItem).Select(s => s.id).FirstOrDefault();
                if (pr == 0)
                {
                    task.brach_id = App.diplomchikEntities.branch.Where(s => s.title == branch.SelectedItem).Select(s => s.id).FirstOrDefault();
                    task.user_id = null;
                }
                else
                {
                    task.user_id = App.diplomchikEntities.user.Where(s => s.surname + " " + s.name == branch.SelectedItem).Select(s => s.id).FirstOrDefault();
                    task.brach_id = null;
                }


                App.diplomchikEntities.SaveChanges();
            }


            try
            {

                
                
                MessageBox.Show("Задача создана");
                this.Close();
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show("неполучилось");
            }

        }





        private void employee_Checked(object sender, RoutedEventArgs e)
        {
            if (employee.IsChecked == true)
            {
                branchs.IsChecked = false;
            }
            labl.Content = "Сотрудник";
            var br = App.diplomchikEntities.user.Select(s => s.surname + " " + s.name).ToList();

            branch.ItemsSource = br;

        }

        private void branchs_Checked(object sender, RoutedEventArgs e)
        {
            if (branchs.IsChecked == true)
            {
                employee.IsChecked = false;
            }
            labl.Content = "Отдел";
            var em = App.diplomchikEntities.branch.Select(s => s.title).ToList();
            branch.ItemsSource = em;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            var message = MessageBox.Show("Вы точно хотите удалить фаил?", "аЛерт", MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                Button delete = sender as Button;
                file delfile = delete.DataContext as file;
                files.Remove(delfile);
                filess.ItemsSource = null;
                filess.ItemsSource = files;
                filess.UpdateLayout();
            }
            if (files.Count == 0)
            {
                filess.Visibility = Visibility.Collapsed;
            }
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}

