﻿using System;
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
using System.Diagnostics;
using System.Windows.Threading;

namespace diplomish
{
    /// <summary>
    /// Логика взаимодействия для filesWindow.xaml
    /// </summary>
    public partial class filesWindow : Window
    {
        DispatcherTimer timer { get; set; }
        public bool ass { get; set; }
        List<file> files { get; set; }
        public task task1 { get; set; }
        public filesWindow(task task)
        {
           
            InitializeComponent();
            

            files = new List<file>();
            task1 = task;
            this.DataContext = task1;
            filess.ItemsSource = task1.file.ToList();
            int x = task1.file.Count();
            if (filess.ItemsSource == null)
            {
                title.Content = "Файлы не прикреплены";
            }
            else
            {
                title.Content = $"Прикреплено {x} файлов";
            }
            files.AddRange(task1.file.ToList());

        }
        int cal = 0;
        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    loadingWin loadingWin = new loadingWin();
        //    if (ass == false)
        //    {
        //        if (cal == 0)
        //        {
                    
        //            loadingWin.ShowDialog();
        //            cal++;
        //        }


        //    }
        //    else if (cal == 1)
        //    {
        //        loadingWin.Close();
        //        cal = 0;
        //    }
        //    Console.WriteLine(cal);

        //}

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ass = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Office Files|*.doc;*.xls;*.ppt*;*.docx;*.pptx;*.csv;*.xlsx*";
            openFileDialog.Multiselect = true;
            List<string> s = new List<string>();
            string filedata;
            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FileNames != null)
                {
                    filess.Visibility = Visibility.Visible;

                    try
                    {

                        //foreach (string filename in openFileDialog.FileNames)
                        //filess.Items.Add(Path.GetFileName(filename));
                        filedata = File.ReadAllText(openFileDialog.FileName);
                        foreach (var item in openFileDialog.FileNames)
                        {

                            FileStream fs = new FileStream(item, FileMode.Open, FileAccess.Read);
                            //s.Add(Path.GetFileNameWithoutExtension(item));
                            // Create a byte array of file stream length
                            byte[] bytes = System.IO.File.ReadAllBytes(item);
                            var ex = Path.GetExtension(item);
                            var name = Path.GetFileNameWithoutExtension(item);
                            //Read block of bytes from stream into the byte array
                            fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));

                            //Close the File Stream
                            fs.Close();
                            file file = new file()
                            {
                                file1 = bytes,
                                extention = ex,
                                upload_date = DateTime.Now,
                                filename = name,
                                uploader_id = task1.initiator_id,


                            };
                            task1.file.Add(file);
                            files.Add(file);
                            App.diplomchikEntities.file.Add(file);



                        }
                        filess.ItemsSource = null;
                        filess.ItemsSource = files;
                        //timer = new DispatcherTimer();
                        //timer.Interval = TimeSpan.FromSeconds(1);
                        //timer.Tick += Timer_Tick;
                        //timer.Start();
                        int? a = await App.diplomchikEntities.SaveChangesAsync();
                        if (a != null)
                        {
                            ass = true;

                        }
                        timer.Stop();
                        int x = task1.file.Count();
                        if (filess.ItemsSource == null)
                        {
                            title.Content = "Файлы не прикреплены";
                        }
                        else
                        {
                            title.Content = $"Прикреплено файлов: {x}";
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var message = MessageBox.Show("Вы точно хотите удалить фаил?", "Внимание", MessageBoxButton.OKCancel);
                if (message == MessageBoxResult.OK)
                {
                    Button delete = sender as Button;
                    file deltask = delete.DataContext as file;
                    App.diplomchikEntities.file.Remove(deltask);
                    files.Remove(deltask);
                    App.diplomchikEntities.SaveChanges();
                    int x = task1.file.Count();
                    if (filess.ItemsSource == null)
                    {
                        title.Content = "Файлы не прикреплены";
                    }
                    else
                    {
                        title.Content = $"Прикреплено {x} файлов";
                    }
                }
                filess.ItemsSource = null;
                filess.ItemsSource = files;
                MessageBox.Show("Фаил был удален успешно");
            }
            catch (Exception)
            {

                MessageBox.Show("Фаил не был удален");
            }

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


        private async void Image1_MouseDown(object sender, MouseButtonEventArgs e)
        {

            string path = @"C:\Users\123\Documents\av\MyTest.zip";
            using (FileStream fstream = new FileStream(path, FileMode.CreateNew))
            {
                byte[] info = App.diplomchikEntities.file.Where(s => s.id == 5).Select(s => s.file1).FirstOrDefault().ToArray();
                fstream.Write(info, 0, info.Length);
                fstream.Close();
            }

        }



    }
}
