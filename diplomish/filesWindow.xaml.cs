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
    /// Логика взаимодействия для filesWindow.xaml
    /// </summary>
    public partial class filesWindow : Window
    {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
                            string path = @"C:\Users\123\Documents\av\MyTest.png";
                            using (FileStream fstream = new FileStream(path, FileMode.CreateNew))
                            {

                                byte[] info = bytes;
                                // запись массива байт++ов в файл
                                fstream.Write(info, 0, info.Length);
                                fstream.Close();
                            }
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
                        App.diplomchikEntities.SaveChanges();
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
                    catch (Exception)
                    {

                        MessageBox.Show("Произошла ошибка");
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
        private void Image1_MouseDown(object sender, MouseButtonEventArgs e)
        {

            string path = @"C:\Users\123\Documents\av\MyTest.png";            
            using (FileStream fstream = new FileStream(path, FileMode.CreateNew))
            {

                byte[] info = App.diplomchikEntities.file.Where(s => s.id == 711).Select(s => s.file1).FirstOrDefault().ToArray();
                // запись массива байт++ов в файл
                fstream.Write(info, 0, info.Length);
                fstream.Close();
            }

        }
    }
}
