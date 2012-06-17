//-----------------------------------------------------------------------
// <copyright file="NotifyPropertyChanged.cs" company="Microsoft">
//     Copyright (c) KodefuGuru, Microsoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace TouchCafe
{
    using System;
    using System.Linq;
    using System.ComponentModel;

    /// <summary>
    /// TODO: Provide summary section in the documentation header.
    /// </summary>
    public class NotifyPropertyChanged : INotifyPropertyChanged, IDisposable
    {
        public virtual void Dispose()
        {

        }

        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
