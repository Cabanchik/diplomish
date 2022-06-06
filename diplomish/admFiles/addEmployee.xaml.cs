using System;
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
    public partial class addEmployee : Page
    {
        public user user1 { get; set; }
        public byte[] mage { get; set; }
        public addEmployee()
        {
            InitializeComponent();
            brnch.ItemsSource = App.diplomchikEntities.branch.Select(s => s.title).ToList();



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
                mage = ImageToByte(new BitmapImage(new Uri(fin)));
                
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

        private void saveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int s;

                if (sex2.IsChecked == true)
                {
                    s = 2;
                }
                else
                {
                    s = 1;
                }
                var br = App.diplomchikEntities.branch.Where(s1 => s1.title == brnch.SelectedItem.ToString()).Select(s1 => s1.id).FirstOrDefault().ToString();

                user user = new user()
                {
                    name = name.Text,
                    surname = surname.Text,
                    gender_id = s,
                    birth_date = dr.SelectedDate,
                    login = log.Text,
                    password = pas.Text,
                    branch_id = Convert.ToInt32(br),
                    user_pic = mage,
                    company_id = staticUser.user.company_id
                };
                App.diplomchikEntities.user.Add(user);
                App.diplomchikEntities.SaveChanges();
                MessageBox.Show("Пользователь добавлен успешно");
                this.NavigationService.GoBack();
            }
            catch (Exception)
            {

                MessageBox.Show("Все поля должны быть заполнены");
            }
            
        }
        private void sex2_Checked(object sender, RoutedEventArgs e)
        {
            if (sex2.IsChecked == true)
            {

                sex.IsChecked = false;
            }
        }

        

        private void sussy_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
