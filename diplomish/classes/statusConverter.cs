using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace diplomish
{
    class statusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BrushConverter bc = new BrushConverter();
            if (value != null)
            {
                var item = value as status;
                if (item.id == 1)
                {
                    return (Brush)bc.ConvertFrom("#49a303");
                }
                else if (item.id == 2)
                {
                    return (Brush)bc.ConvertFrom("#007d00");
                }
                else if (item.id == 3)
                {
                    return (Brush)bc.ConvertFrom("#7d0000");
                }else if (item.id == 4)
                {
                    return (Brush)bc.ConvertFrom("#450303");
                }else if (item.id == 5)
                {
                    return (Brush)bc.ConvertFrom("#ff9d00");
                }else if (item.id == 6)
                {
                    return (Brush)bc.ConvertFrom("#fc0303");
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
