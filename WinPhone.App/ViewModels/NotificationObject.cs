namespace WinPhone.App.Common
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;

    public class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string caller = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        //protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        //{
        //    var member = (MemberExpression)propertyExpression.Body;
        //    string propertyName = member.Member.Name;
        //    this.NotifyPropertyChanged(propertyName);
        //}
    }
}
