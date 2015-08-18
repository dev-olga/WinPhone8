using System;
using System.Linq;

namespace WinPhone.App.Common.Converters.Main
{
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Data;

    using WinPhone.App.ViewModels.Main;

    internal class PivotItemEventAgrsToPivotItemConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return parameter != null && Enum.IsDefined(typeof(PivotItems), parameter) ? (PivotItems)parameter : (PivotItems)0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
