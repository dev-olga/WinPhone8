using System;

namespace WinPhone.App.Common.Converters.ShowDetails
{
    using Windows.UI.Xaml.Data;

    using WinPhone.MyShows.Models.Shows;

    internal class ShowStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch ((ShowStatus)value)
            {
                case ShowStatus.Watching:
                    {
                        return "Watching";
                    }
                case ShowStatus.Later:
                    {
                        return "Later";
                    }
                case ShowStatus.Cancelled:
                    {
                        return "Will not watch";
                    }
                case ShowStatus.Remove:
                    {
                        return "Not watching";
                    }

            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
