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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace diplomish
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int a = 0;
        public MainWindow()
        {
            
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new mineTasks());
            ourTaskLbl.Opacity = 0;
            nOurTaskLbl.Opacity = 0;
            settings.Opacity = 0;
            back.Opacity = 0;
            shd.Opacity = 0;

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
                animLbl.Content = "<";
               
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
                animLbl.Content = ">";
                
                a = 0;
            }
            
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
            SelectionPage selectionPage = new SelectionPage();
            mainFrame.NavigationService.Navigate(selectionPage);
        }
    }
}
