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
        public string kall { get; set; }
        public taskCreate()
        {
            InitializeComponent();
            string a = App.diplomchikEntities.file.Where(s => s.id == 1).Select(s => s.file1).ToString();
            kall = a;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT(*.txt)|*.txt|DOCX (.docx)|*.docx*";
            openFileDialog.Multiselect = true;

            string filedata;
            if (openFileDialog.ShowDialog() == true)
            {

                //foreach (string filename in openFileDialog.FileNames)
                //    filess.Items.Add(Path.GetFileName(filename));
                filedata = File.ReadAllText(openFileDialog.FileName);

                file file = new file()
                {
                    file1 = "негры",
                    old_extention = ".txt"
                };
                App.diplomchikEntities.file.Add(file);
                App.diplomchikEntities.SaveChanges();
                this.Close();
                //byte[] dataArray = new byte[];
                //using (FileStream
                //fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                //{
                //    // Write the data to the file, byte by byte.
                //    for (int i = 0; i < dataArray.Length; i++)
                //    {
                //        fileStream.WriteByte(dataArray[i]);

                //    }

                //    file file = new file()
                //    {
                //        file1 = dataArray
                //    };
                //    App.diplomchikEntities.file.Add(file);
                //    //App.diplomchikEntities.SaveChanges();

                //// Set the stream position to the beginning of the file.
                //    fileStream.Seek(0, SeekOrigin.Begin);

                //    // Read and verify the data.
                //    for (int i = 0; i < fileStream.Length; i++)
                //    {
                //        if (dataArray[i] != fileStream.ReadByte())
                //        {
                //            Console.WriteLine("Error writing data.");
                //            return;
                //        }
                //    }
                //    Console.WriteLine("The data was written to {0} " +
                //        "and verified.", fileStream.Name);
                //}
                //byte[] buffer = File.ReadAllBytes(openFileDialog.FileName);
                //using (MemoryStream reader = new MemoryStream(fileStream))
                //{
                //    reader.BaseStream.CopyTo(bytes);

                //    file file = new file()
                //    {
                //        file1 = (reader)
                //    };
                //    App.diplomchikEntities.file.Add(reader);
                //}

            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\123\Documents\av\MyTest.txt";
            using (FileStream fs = File.Create(path))
            {
                StreamWriter output = new StreamWriter(fs);               
                string info = App.diplomchikEntities.file.Where(s=>s.id == 31).Select(s => s.file1).FirstOrDefault().ToString();
                output.Write(info);
                output.Close();
                
            }

        }
    }
}
