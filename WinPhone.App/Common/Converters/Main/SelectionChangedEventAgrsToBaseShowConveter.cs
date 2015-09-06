using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.Common.Converters.Main
{
    using Windows.UI.Xaml.Data;

    using WinPhone.MyShows.Models.Shows;

    internal class SelectionChangedEventAgrsToBaseShowConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return parameter as BaseShow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
