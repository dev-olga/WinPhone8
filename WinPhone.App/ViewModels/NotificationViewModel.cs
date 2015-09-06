namespace WinPhone.App.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;

    using WinPhone.App.Common.Helpers;

    public class NotificationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string caller = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(ExpressionHelper.GetFullPropertyName(propertyExpression)));
            }
        }
    }
}
