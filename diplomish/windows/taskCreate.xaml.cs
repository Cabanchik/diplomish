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
        task task = new task();
        bool nullStart = false;
        bool nullEnd = false;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (branch.SelectedItem != null)
            {
                var us = App.diplomchikEntities.user.Where(s => s.surname + " " + s.name == branch.SelectedItem.ToString()).Select(s => s.id).FirstOrDefault();
                var bran = App.diplomchikEntities.branch.Where(s => s.title == branch.SelectedItem.ToString()).Select(s => s.id).FirstOrDefault();



                if (us == 0)
                {
                    if (start.Text == null)
                    {
                        nullStart = true;
                    }
                    if (end.Text == null)
                    {
                        nullEnd = true;
                    }

                    if (nullStart == true && nullEnd == true)
                    {
                        task = new task()
                        {
                            title = tas.Text.ToString(),
                            annotation = annotation.Text.ToString(),
                            start_time = null,
                            end_time = null,
                            user_id = null,
                            brach_id = Convert.ToInt32(bran),
                            status_id = 5,
                            initiator_id = staticUser.user.id,
                            purpose_time = DateTime.Now

                        };
                        isAdded = true;
                        App.diplomchikEntities.task.Add(task);

                        App.diplomchikEntities.SaveChanges();
                    }
                    else if (nullStart == false && nullEnd == true)
                    {
                        task = new task()
                        {
                            title = tas.Text.ToString(),
                            annotation = annotation.Text.ToString(),
                            start_time = null,
                            end_time = Convert.ToDateTime(end.Text),
                            user_id = null,
                            brach_id = Convert.ToInt32(bran),
                            status_id = 5,
                            initiator_id = staticUser.user.id,
                            purpose_time = DateTime.Now

                        };
                        isAdded = true;
                        App.diplomchikEntities.task.Add(task);

                        App.diplomchikEntities.SaveChanges();
                    }
                    else if (nullStart == true && nullEnd == false)
                    {
                        task = new task()
                        {
                            title = tas.Text.ToString(),
                            annotation = annotation.Text.ToString(),
                            start_time = Convert.ToDateTime(start.Text),
                            end_time = null,
                            user_id = null,
                            brach_id = Convert.ToInt32(bran),
                            status_id = 5,
                            initiator_id = staticUser.user.id,
                            purpose_time = DateTime.Now

                        };
                        isAdded = true;
                        App.diplomchikEntities.task.Add(task);
                        App.diplomchikEntities.SaveChanges();
                        this.Close();
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
                            brach_id = Convert.ToInt32(bran),
                            status_id = 5,
                            initiator_id = staticUser.user.id,
                            purpose_time = DateTime.Now

                        };
                        isAdded = true;
                        App.diplomchikEntities.task.Add(task);
                        App.diplomchikEntities.SaveChanges();
                        this.Close();
                    }



                }
                else if (bran == 0)
                {
                    if (start.Text == null)
                    {
                        nullStart = true;
                    }
                    if (end.Text == null)
                    {
                        nullEnd = true;
                    }
                    if (nullStart == true && nullEnd == true)
                    {
                        task = new task()
                        {
                            title = tas.Text.ToString(),
                            annotation = annotation.Text.ToString(),
                            start_time = null,
                            end_time = null,
                            user_id = Convert.ToInt32(us),
                            brach_id = null,
                            status_id = 5,
                            initiator_id = staticUser.user.id,
                            purpose_time = DateTime.Now

                        };
                        isAdded = true;
                        App.diplomchikEntities.task.Add(task);

                        App.diplomchikEntities.SaveChanges();
                    }
                    else if (nullStart == false && nullEnd == true)
                    {
                        task = new task()
                        {
                            title = tas.Text.ToString(),
                            annotation = annotation.Text.ToString(),
                            start_time = null,
                            end_time = Convert.ToDateTime(end.Text),
                            user_id = Convert.ToInt32(us),
                            brach_id = null,
                            status_id = 5,
                            initiator_id = staticUser.user.id,
                            purpose_time = DateTime.Now

                        };
                        isAdded = true;
                        App.diplomchikEntities.task.Add(task);

                        App.diplomchikEntities.SaveChanges();
                    }
                    else if (nullStart == true && nullEnd == false)
                    {
                        task = new task()
                        {
                            title = tas.Text.ToString(),
                            annotation = annotation.Text.ToString(),
                            start_time = Convert.ToDateTime(start.Text),
                            end_time = null,
                            user_id = Convert.ToInt32(us),
                            brach_id = null,
                            status_id = 5,
                            initiator_id = staticUser.user.id,
                            purpose_time = DateTime.Now

                        };
                        isAdded = true;
                        App.diplomchikEntities.task.Add(task);

                        App.diplomchikEntities.SaveChanges();
                    }
                    else
                    {
                        task = new task()
                        {
                            title = tas.Text.ToString(),
                            annotation = annotation.Text.ToString(),
                            start_time = Convert.ToDateTime(start.Text),
                            end_time = Convert.ToDateTime(end.Text),
                            user_id = Convert.ToInt32(us),
                            brach_id = null,
                            status_id = 5,
                            initiator_id = staticUser.user.id,
                            purpose_time = DateTime.Now


                        };
                        isAdded = true;
                        App.diplomchikEntities.task.Add(task);

                        App.diplomchikEntities.SaveChanges();
                    }


                }
            }
            else
            {
                if (start.Text == null)
                {
                    nullStart = true;
                }
                else
                {
                    nullStart = false;
                }
                if (end.Text == null)
                {
                    nullEnd = true;
                }
                else
                {
                    nullEnd = false;
                }
                if (nullStart == true && nullEnd == true)
                {
                    task = new task()
                    {
                        title = tas.Text.ToString(),
                        annotation = annotation.Text.ToString(),
                        start_time = null,
                        end_time = null,
                        user_id = null,
                        brach_id = null,
                        status_id = 5,
                        initiator_id = staticUser.user.id,
                        purpose_time = DateTime.Now

                    };
                    isAdded = true;
                    App.diplomchikEntities.task.Add(task);

                    App.diplomchikEntities.SaveChanges();
                }
                else if (nullStart == false && nullEnd == true)
                {
                    task = new task()
                    {
                        title = tas.Text.ToString(),
                        annotation = annotation.Text.ToString(),
                        start_time = null,
                        end_time = Convert.ToDateTime(end.Text),
                        user_id = null,
                        brach_id = null,
                        status_id = 5,
                        initiator_id = staticUser.user.id,
                        purpose_time = DateTime.Now

                    };
                    isAdded = true;
                    App.diplomchikEntities.task.Add(task);

                    App.diplomchikEntities.SaveChanges();
                }
                else if (nullStart == true && nullEnd == false)
                {
                    task = new task()
                    {
                        title = tas.Text.ToString(),
                        annotation = annotation.Text.ToString(),
                        start_time = Convert.ToDateTime(start.Text),
                        end_time = null,
                        user_id = null,
                        brach_id = null,
                        status_id = 5,
                        initiator_id = staticUser.user.id,
                        purpose_time = DateTime.Now

                    };
                    isAdded = true;
                    App.diplomchikEntities.task.Add(task);

                    App.diplomchikEntities.SaveChanges();
                }

            }


            filesWindow filesWindow = new filesWindow(task);
            filesWindow.ShowDialog();



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (isAdded == false)
            {
                if (branch.SelectedItem != null)
                {

                    var us = App.diplomchikEntities.user.Where(s => s.surname + " " + s.name == branch.SelectedItem.ToString()).Select(s => s.id).FirstOrDefault();
                    var bran = App.diplomchikEntities.branch.Where(s => s.title == branch.SelectedItem.ToString()).Select(s => s.id).FirstOrDefault();


                    if (us == 0)
                    {
                        if (start.Text == null)
                        {
                            nullStart = true;
                        }
                        else
                        {
                            nullStart = false;
                        }
                        if (end.Text == null)
                        {
                            nullEnd = true;
                        }
                        else
                        {
                            nullEnd = false;
                        }
                        if (nullStart == true && nullEnd == true)
                        {
                            MessageBox.Show("Все даты должны быть запонены");
                        }
                        else if (nullStart == false && nullEnd == true)
                        {
                            MessageBox.Show("Не заполнена дата конца задачи");
                        }
                        else if (nullStart == true && nullEnd == false)
                        {
                            MessageBox.Show("Не заполнена дата начала задачи");
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
                                brach_id = Convert.ToInt32(bran),
                                initiator_id = user1.id,
                                status_id = 5,
                                purpose_time = DateTime.Now

                            };
                            App.diplomchikEntities.task.Add(task);
                            App.diplomchikEntities.SaveChanges();
                            MessageBox.Show("Задача создана!");
                            this.Close();
                        }

                    }
                    else if (bran == 0)
                    {
                        if (start.Text == null)
                        {
                            nullStart = true;
                        }
                        else
                        {
                            nullStart = false;
                        }
                        if (end.Text == null)
                        {
                            nullEnd = true;
                        }
                        else
                        {
                            nullEnd = false;
                        }
                        if (nullStart == true && nullEnd == true)
                        {
                            MessageBox.Show("Все даты должны быть запонены");
                        }
                        else if (nullStart == false && nullEnd == true)
                        {
                            MessageBox.Show("Не заполнена дата конца задачи");
                        }
                        else if (nullStart == true && nullEnd == false)
                        {
                            MessageBox.Show("Не заполнена дата начала задачи");
                        }
                        else
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
                                status_id = 5,
                                purpose_time = DateTime.Now

                            };
                            App.diplomchikEntities.task.Add(task);
                            App.diplomchikEntities.SaveChanges();
                            MessageBox.Show("Задача создана!");
                            this.Close();
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Исполнитель не указан");
                }
            }
            else
            {
                try
                {
                    task.annotation = annotation.Text.ToString();
                    task.title = tas.Text.ToString();
                    task.status_id = 5;
                    task.purpose_time = DateTime.Now;
                    task.initiator_id = staticUser.user.id;
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
                    MessageBox.Show("Задача создана");
                    this.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Все поля должны быть запонены");
                }

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
            if (isAdded == true)
            {

                var message = MessageBox.Show("Вы точно хотите удалить задачу?", "Внимание", MessageBoxButton.OKCancel);
                if (message == MessageBoxResult.OK)
                {
                    task.file.Clear();
                    App.diplomchikEntities.task.Remove(task);
                    App.diplomchikEntities.SaveChanges();
                }

            }
            this.Close();
        }
    }
}

