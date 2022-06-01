using System;
using System.Collections.Generic;
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
            load.Visibility = Visibility.Collapsed;

        }

        private async void LoginClick(object sender, RoutedEventArgs e)
        {
            var CurrentUser = await log1n();
            if (CurrentUser != null)
            {
                MainWindow mainWindow = new MainWindow(CurrentUser);
                mainWindow.Show();
                App.company = CurrentUser.company_id;
                this.Close();
            }
            else if (login.Text == "" || pas.Text == "")
            {
                errorMes.Text = "Все поля должны быть заполнены!";
            }
            else if (App.diplomchikEntities.user.Where(u => u.login == login.Text.ToString()).FirstOrDefault() != null)
            {
                MessageBox.Show("Неверный пароль!");

            }
            else
            {
                MessageBox.Show("Неверный логин!");
            }

        }

        public async Task<user> log1n()
        {
            object CurrentUser = await App.diplomchikEntities.user.Where(u => u.login == login.Text.ToString() && u.password == pas.Text.ToString()).FirstOrDefault();
            return CurrentUser;

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
    }
}
