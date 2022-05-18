using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace diplomish
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static System.Windows.Threading.DispatcherTimer readDataTimer = new System.Windows.Threading.DispatcherTimer();
        public int a = 0;
        public user chel { get; set; }
        public MainWindow()
        {

            InitializeComponent();
            mainFrame.NavigationService.Navigate(new mineTasks());
            ourTaskLbl.Opacity = 0;
            nOurTaskLbl.Opacity = 0;
            settings.Opacity = 0;
            back.Opacity = 0;
            shd.Opacity = 0;
            calendar calendar = new calendar();
            sss.Content = calendar;
            sss.Opacity = 0;

            sss.Visibility = Visibility.Collapsed;

        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (a == 0)
            {
                DoubleAnimation checkBoxAnim = new DoubleAnimation(420, App.openCloseDuraion);
                border.BeginAnimation(WidthProperty, checkBoxAnim);
                navStack.BeginAnimation(WidthProperty, checkBoxAnim);
                DoubleAnimation opacityAnim = new DoubleAnimation(1, App.openCloseDuraion);
                ourTaskLbl.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                nOurTaskLbl.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                back.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                settings.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                shd.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                call.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                animLbl.Content = "<";
                DoubleAnimation opacityAnim1 = new DoubleAnimation(1, new Duration(TimeSpan.FromSeconds(1)));
                sss.BeginAnimation(UIElement.OpacityProperty, opacityAnim1);
                sss.Visibility = Visibility.Visible;

                a = 1;
            }
            else if (a == 1)
            {
                DoubleAnimation checkBoxAnim = new DoubleAnimation(70, App.openCloseDuraion);
                border.BeginAnimation(WidthProperty, checkBoxAnim);
                navStack.BeginAnimation(WidthProperty, checkBoxAnim);
                DoubleAnimation opacityAnim = new DoubleAnimation(0, App.openCloseDuraion);
                ourTaskLbl.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                nOurTaskLbl.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                back.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                settings.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                shd.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                call.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
                animLbl.Content = ">";

                DoubleAnimation opacityAnim1 = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(1)));
                sss.BeginAnimation(UIElement.OpacityProperty, opacityAnim1);
                a = 0;
                sss.Visibility = Visibility.Collapsed;
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += timer_Tick;
                timer.Start();
                if (sss.Visibility == Visibility.Collapsed)
                {
                    timer.Stop();
                }



            }

        }

        void timer_Tick(object sender, EventArgs e)
        {
            sss.Visibility = Visibility.Collapsed;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            taskCreate taskCreate = new taskCreate();
            taskCreate.ShowDialog();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var message = MessageBox.Show("Вы точно хотите выйти?", "аЛерт", MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void backClick(object sender, MouseButtonEventArgs e)
        {
            if (mainFrame.CanGoBack == true)
            {
                mainFrame.GoBack();
            }
        }
        private void tasksOnMePage(object sender, MouseButtonEventArgs e)
        {
            mineTasks selectionPage = new mineTasks();
            mainFrame.NavigationService.Navigate(selectionPage);
            navLbl.Content = "Задачи на мне";
        }

        private void StackPanel_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            myTasks mineTasks = new myTasks();
            mainFrame.NavigationService.Navigate(mineTasks);
            navLbl.Content = "Задачи от меня";
        }

        
        private void sss_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("sss");
        }

        private void StackPanel_MouseDown_2(object sender, MouseButtonEventArgs e)
        {

            editEmployee addEmployee = new editEmployee(chel);
            addEmployee.ShowDialog();
        }
    }
}
