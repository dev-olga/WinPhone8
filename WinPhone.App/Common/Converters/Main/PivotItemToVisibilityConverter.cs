using System;

namespace WinPhone.App.Common.Converters.Main
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    using WinPhone.App.ViewModels.Main;

    internal class PivotItemToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is PivotItems && parameter is PivotItems && (PivotItems)value == (PivotItems)parameter) 
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
