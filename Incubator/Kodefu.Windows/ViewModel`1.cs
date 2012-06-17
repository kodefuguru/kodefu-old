namespace Kodefu.Windows
{
    using System;
    using System.ComponentModel;
        
    public class ViewModel<T> : INotifyPropertyChanged, IDisposable
    {
        internal T Model { get; private set; }
        
        public ViewModel(T model)
        {
            Model = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Dispose()
        {
            Model = default(T);
            PropertyChanged = null;
        }
    }
}
