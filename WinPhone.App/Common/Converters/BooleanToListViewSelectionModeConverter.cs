using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Common.Converters
{
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Data;

    internal class BooleanToListViewSelectionModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value is bool && (bool)value ? ListViewSelectionMode.Multiple : ListViewSelectionMode.None; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
