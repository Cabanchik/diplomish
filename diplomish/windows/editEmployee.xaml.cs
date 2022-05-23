﻿using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для addEmployee.xaml
    /// </summary>
    public partial class editEmployee : Window
    {
        public user user1 { get; set; }
        public editEmployee(user user)
        {
            InitializeComponent();
            user1 = user;
            this.DataContext = user1;
            if (user.gender_id == 1)
            {
                sex.IsChecked = true;
                sex2.IsChecked = false;
            }
            else
            {
                sex.IsChecked = false;
                sex2.IsChecked = true;
            }

            brnch.ItemsSource = App.diplomchikEntities.branch.Select(s => s.title).ToList();
            brnch.Text = user1.branch.title;
        }

        private void surname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void sex_Checked(object sender, RoutedEventArgs e)
        {
            if (sex.IsChecked == true)
            {
                sex2.IsChecked = false;
            }


        }

        private void Ellipse_Drop(object sender, DragEventArgs e)
        {
            
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                string fin = System.IO.Path.GetFullPath(files[0]);

                dicpic.ImageSource = new BitmapImage(new Uri(fin));                
                user1.user_pic = ImageToByte(new BitmapImage(new Uri(fin)));
                App.diplomchikEntities.SaveChanges();
            }
        }
        public static byte[] ImageToByte(BitmapImage image)
        {
            MemoryStream memoryStream = new MemoryStream();
            JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
            jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(image));
            jpegBitmapEncoder.Save(memoryStream);
            return memoryStream.ToArray();
        }

        private void edit1_Click(object sender, RoutedEventArgs e)
        {
            pic.AllowDrop = true;
            edit1.Visibility = Visibility.Collapsed;
            sussy.Visibility = Visibility.Visible;

            name.IsReadOnly = false;
            surname.IsReadOnly = false;
            sex.IsEnabled = true;
            sex2.IsEnabled = true;
            dr.IsEnabled = true;
            log.IsReadOnly = false;
            pas.IsReadOnly = false;
            lbl.Visibility = Visibility.Visible;
            pas.Text = Convert.ToString(user1.password);
            brnch.IsReadOnly = false;
            
        }
        private void sex2_Checked(object sender, RoutedEventArgs e)
        {
            if (sex2.IsChecked == true)
            {

                sex.IsChecked = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sussy_Click(object sender, RoutedEventArgs e)
        {
            pic.AllowDrop = false;
            edit1.Visibility = Visibility.Visible;
            sussy.Visibility = Visibility.Collapsed;

            name.IsReadOnly = true;
            surname.IsReadOnly = true;
            sex.IsEnabled = false;
            sex2.IsEnabled = false;
            dr.IsEnabled = false;
            log.IsReadOnly = true;
            pas.IsReadOnly = true;
            brnch.IsReadOnly = true;
            lbl.Visibility = Visibility.Collapsed;

            if (sex2.IsChecked == true)
            {
                user1.gender_id = 11;
            }
            else if (sex.IsChecked == true)
            {
                user1.gender_id = 1;

            }
            user1.name = name.Text.ToString();
            user1.surname = surname.Text.ToString();
            user1.birth_date = Convert.ToDateTime(dr.Text);
            user1.login = log.Text.ToString();
            user1.password = pas.Text.ToString();
            var br = App.diplomchikEntities.branch.Where(s => s.title == brnch.SelectedItem.ToString()).Select(s => s.id).FirstOrDefault().ToString();
            user1.branch_id = Convert.ToInt32(br);
            App.diplomchikEntities.SaveChanges();
            pas.Text = "***";
        }
    }
}
