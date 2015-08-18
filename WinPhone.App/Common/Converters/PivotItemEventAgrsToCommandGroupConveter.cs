using System;
using System.Linq;

namespace WinPhone.App.Common.Converters
{
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Data;

    using WinPhone.App.ViewModels.Main;

    internal class PivotItemEventAgrsToCommandGroupConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var name = (value as PivotItemEventArgs) != null
                ? (value as PivotItemEventArgs).Item.Name : string.Empty;

            return
                Enum.GetValues(typeof(CommandGroups))
                    .Cast<CommandGroups>()
                    .FirstOrDefault(cg => cg.ToString().Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
