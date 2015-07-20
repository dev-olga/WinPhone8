﻿namespace WinPhone.App.ViewModels
{
    using System.ComponentModel;

    public class NotificationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string caller = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}