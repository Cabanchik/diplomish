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
        public byte[] kall { get; set; }
        
        public taskCreate()
        {
            InitializeComponent();
            //var br = App.diplomchikEntities.branch.Select(s => s.title).ToList();
            //branch.ItemsSource = br;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Office Files|*.doc;*.xls;*.ppt*;*.docx;*.pptx;*.csv;*.xlsx*";
            openFileDialog.Multiselect = true;
            List<string> s = new List<string>();
            string filedata;
            if (openFileDialog.ShowDialog() == true)
            {

                try
                {
                    //foreach (string filename in openFileDialog.FileNames)
                        //filess.Items.Add(Path.GetFileName(filename));
                    filedata = File.ReadAllText(openFileDialog.FileName);
                    foreach (var item in openFileDialog.FileNames)
                    {
                        FileStream fs = new FileStream(item, FileMode.Open, FileAccess.Read);
                        s.Add(Path.GetFileNameWithoutExtension(item));
                        // Create a byte array of file stream length
                        byte[] bytes = System.IO.File.ReadAllBytes(item);
                        var ex = Path.GetExtension(item);
                        var name = Path.GetFileNameWithoutExtension(item);
                        //Read block of bytes from stream into the byte array
                        fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
                        kall = bytes;

                        //Close the File Stream
                        fs.Close();
                        file file = new file()
                        {
                            file1 = bytes,
                            extention = ex,
                            upload_date = DateTime.Now,
                            filename = name,
                            //uploader_id =,
                            
                        };
                        App.diplomchikEntities.file.Add(file);
                        
                    }
                    filess.ItemsSource = s;


                }
                catch (Exception)
                {

                    MessageBox.Show("Произошла ошибка");
                }
                
            }




        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var bran = App.diplomchikEntities.branch.Where(s => s.title == branch.SelectedItem.ToString()).Select(s => s.id).FirstOrDefault().ToString();
            task task = new task()
            {
                title = tas.Text.ToString(),
                annotation = annotation.Text.ToString(),
                start_time = Convert.ToDateTime(start.Text),
                end_time = Convert.ToDateTime(end.Text),
                brach_id = Convert.ToInt32(bran),


            };
            try
            {
                App.diplomchikEntities.SaveChanges();
            }
            catch (Exception)
            {

                MessageBox.Show("неполучилось");
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
    }
}

