namespace Kodefu
{
    using System.ComponentModel;

    public class Selectable<T> : INotifyPropertyChanged    
    {
        private bool selected;

        public Selectable(T value)
            : this(value, false) { }        

        public Selectable(T value, bool selected)
        {
            this.Value = value;
            this.selected = selected;
        }

        public bool Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                this.selected = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
                }
            }
        }

        public T Value { get; private set; }
    
        public event PropertyChangedEventHandler  PropertyChanged;
}
}
