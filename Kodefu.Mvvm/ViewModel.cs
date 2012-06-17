namespace Kodefu.Mvvm
{
    using System;

    public class ViewModel : ObservableObject, IDisposable
    {
        public virtual void Dispose()
        {
            
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }
    }
}
