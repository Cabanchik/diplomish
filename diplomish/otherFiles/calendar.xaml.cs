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
    /// Логика взаимодействия для calendar.xaml
    /// </summary>
    public partial class calendar : Page
    {
        public calendar()
        {
            BrushConverter bc = new BrushConverter();
            var emil = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var yo = App.diplomchikEntities.task.Where(w => (w.end_time.Value.Month == DateTime.Now.Month && w.end_time > DateTime.Now && w.status_id != 2 && w.status_id != 6 && staticUser.user.id == w.user_id && w.is_deleted !=1)||(w.end_time.Value.Month == DateTime.Now.Month && w.end_time > DateTime.Now && w.status_id != 2 && w.status_id != 6 && staticUser.user.branch_id == w.brach_id && w.is_deleted != 1)).Select(s => s.end_time.Value.Day).ToList();
            List<int> pisa = new List<int>();
            int a = 0;
            InitializeComponent();

            for (int i = 0; i < emil; i++)
            {
                a++;
                pisa.Add(a);
                
            }
          
            for (int i = 0; i < pisa.Count; i++)
            {
                Label stas1 = new Label()
                {
                    Content = pisa[i].ToString(),
                    Width = 58,
                    Height = 58,
                    Background = (Brush)bc.ConvertFrom("#fc9003"),
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    BorderBrush = (Brush)bc.ConvertFrom("#000000"),
                    BorderThickness = new Thickness(1),
                    FontSize = 38

                };
                if (yo.Contains(pisa[i]))
                {
                    stas1.Background = (Brush)bc.ConvertFrom("#ff0022");

                }
                wrap.Children.Add(stas1);
                


            }

        }
    }
}
