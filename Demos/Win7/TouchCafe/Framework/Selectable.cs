using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchCafe
{
    public class Selectable<T> : NotifyPropertyChanged
    {
        private readonly T value;
        private bool selected;

        public T Value
        {
            get
            {
                return this.value;
            }
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
                RaisePropertyChanged("Selected");
            }
        }

        public Selectable(T value)
        {
            this.value = value;
            this.selected = false;
        }
    }

    public static class Selectable
    {
        public static Selectable<T> Create<T>(this T item)
        {
            return new Selectable<T>(item);
        }
    }
}
