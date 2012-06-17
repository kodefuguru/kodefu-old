namespace Kodefu
{
    using System.ComponentModel;

    public class ObservableObject : INotifyPropertyChanged
    {              
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
