using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Common.Converters
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    using WinPhone.App.ViewModels.Main;

    internal class CommandGroupToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is CommandGroups && parameter is CommandGroups && (CommandGroups)value == (CommandGroups)parameter) 
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
