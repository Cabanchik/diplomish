using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace diplomish
{
    /// <summary>
    /// Логика взаимодействия для LogWin.xaml
    /// </summary>
    public partial class LogWin : Window
    {
        bool ass = false;
        DispatcherTimer timer { get; set; }
        public LogWin()
        {

            InitializeComponent();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var s = userName.Split('\\');
            //load.Visibility = Visibility.Collapsed;
            var s1 = Directory.Exists($@"C:\Users\{s[1]}\Downloads\Everydaynik dowloads");
            if (s1 == false)
            {
                string path1 = $@"C:\Users\{s[1]}\Downloads";
                string path2 = System.IO.Path.Combine(path1, "Everydaynik dowloads");
                Directory.CreateDirectory(path2);
            }




            //"DESKTOP-R3QCPIV\\123"





        }

        private async void LoginClick(object sender, RoutedEventArgs e)
        {
            if (pas.Password == "" || pas.Password == " ")
            {
                pas.Password = pas1.Text; 
            }
            //try
            //{
                var CurrentUser = App.diplomchikEntities.user.Where(u => u.login == login.Text.ToString() && u.password == pas.Password.ToString()).FirstOrDefault();
                if (CurrentUser != null)
                {
                    staticUser.user = CurrentUser;
                    MainWindow mainWindow = new MainWindow(CurrentUser);
                    mainWindow.Show();

                    this.Close();
                }
                //else if (login.Text == "" || pas.Password == "")
                //{
                //    errorMes.Text = "Все поля должны быть заполнены!";
                //}
                //else if (App.diplomchikEntities.user.Where(u => u.login == login.Text.ToString()).FirstOrDefault() != null)
                //{
                //    MessageBox.Show("Неверный пароль!");

                //}
                //else
                //{
                //    MessageBox.Show("Неверный логин!");
                //}
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Произошла ошибка");
            //}
           

        }




        private void TextBoxPreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void LoginPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.Match(e.Text, @"[0-9a-zA-Zа-яА-Я]").Success)
            {
                e.Handled = true;
            }
        }

        private void PasswordPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.Match(e.Text, @"[0-9a-zA-Z!@#$%^&*()_+=\[{\]};:<>|./?,-]").Success)
            {
                e.Handled = true;
            }
        }

        private void accept_Checked(object sender, RoutedEventArgs e)
        {

            
                pas.Visibility = Visibility.Collapsed;
                
                pas1.Visibility = Visibility.Visible;
                pas1.Text = pas.Password;

            




        }

        private void accept_Unchecked(object sender, RoutedEventArgs e)
        {
            
                
                pas1.Visibility = Visibility.Collapsed;
                pas.Visibility = Visibility.Visible;
                pas.Password = pas1.Text;
            

        }
    }


}

