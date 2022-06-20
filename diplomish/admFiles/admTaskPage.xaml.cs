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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace diplomish
{
    /// <summary>
    /// Логика взаимодействия для admFilesPage.xaml
    /// </summary>
    public partial class admTaskPage : Page
    {
        List<task> t;


        public admTaskPage()
        {
            
            InitializeComponent();           
            sasun();
            
        }
        public async void sasun()
        {
            var s = Task.Run(() => sasun2());
            t = await s;
            Imported.ItemsSource = t;
            
        }
        public List<task> sasun2()
        {
            var t = App.diplomchikEntities.task.ToList();
            return t;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var message = MessageBox.Show("Вы точно хотите удалить фаил?", "Внимание", MessageBoxButton.OKCancel);
                if (message == MessageBoxResult.OK)
                {
                    Image delete = sender as Image;
                    task deltask = delete.DataContext as task;
                    App.diplomchikEntities.task.Remove(deltask);
                    App.diplomchikEntities.SaveChanges();
                }
                Imported.ItemsSource = null;
                sasun();

            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
            
        }
    }
}
