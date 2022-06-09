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
    public partial class admFilesPage : Page
    {
        List<file> t;


        public admFilesPage()
        {
            
            InitializeComponent();           
            load();
            
        }
        public async void load()
        {
            var s = Task.Run(() => load2());
            t = await s;
            Imported.ItemsSource = t;
            
        }
        public List<file> load2()
        {
            var t = App.diplomchikEntities.file.ToList();
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
                    file deltask = delete.DataContext as file;
                    deltask.task.Clear();
                    App.diplomchikEntities.file.Remove(deltask);
                    App.diplomchikEntities.SaveChanges();
                }
                Imported.ItemsSource = null;
                load();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
            
        }
    }
}
