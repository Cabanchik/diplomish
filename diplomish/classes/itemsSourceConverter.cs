using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace diplomish
{
    class itemsSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {

                var i = value as user;

                i.task.Where(s => s.is_deleted == 0).ToList();
                
                var it = App.diplomchikEntities.task.Where(s=>s.user_id == i.id && s.is_deleted != 1 && s.initiator_id == i.id).ToList();
                if (it.Count == 0)
                {
                    
                }
                return it;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
