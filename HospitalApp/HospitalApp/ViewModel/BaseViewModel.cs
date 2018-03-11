using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HospitalApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #region Attributes
        private string title = string.Empty;
        private bool isRunning;
        private bool isEnabled = true;
        private bool isVisible;
        #endregion

        #region Properties
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public bool IsRunning
        {
            get => isRunning;
            set => SetProperty(ref isRunning, value);
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }
        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }
        #endregion

        #region Methods
        protected void ActivityIndicatorOff()
        {
            isRunning = false;
            isVisible = false;
            isEnabled = true;
        }

        protected void ActivityIndicatorOn()
        {
            isRunning = true;
            isVisible = true;
            isEnabled = false;
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
