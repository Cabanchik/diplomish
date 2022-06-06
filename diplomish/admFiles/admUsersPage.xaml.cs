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
    public partial class admUsersPage : Page
    {
        List<user> t;


        public admUsersPage()
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
        public List<user> sasun2()
        {
            var t = App.diplomchikEntities.user.ToList();
            return t;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var message = MessageBox.Show("Вы точно хотите удалить фаил?", "Внимание", MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                Image delete = sender as Image;
                user deltask = delete.DataContext as user;
                App.diplomchikEntities.user.Remove(deltask);
                App.diplomchikEntities.SaveChanges();
            }
        }
    }
}
