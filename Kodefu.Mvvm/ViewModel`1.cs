namespace Kodefu.Mvvm
{
    using System.IO.IsolatedStorage;
    using System.IO;
    using System.Xml.Serialization;

    public class ViewModel<T> : ViewModel where T: new()
    {

        private string stateFileName;

        protected string StateFileName
        {
            get
            {
                if (stateFileName.IsNullOrEmpty())
                {
                    this.stateFileName = this.GetType().Name + ".xml";
                }

                return this.stateFileName;
            }
            set
            {
                this.stateFileName = value;
            }
        }

        protected T Model { get; set; }

        public override void Save()
        {
            IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream stream = iso.CreateFile(StateFileName);
            using (StreamWriter writer = new StreamWriter(stream))
            {
                new XmlSerializer(typeof(T)).Serialize(writer, Model);
            }
        }

        public virtual bool Load()
        {            
            IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
            try
            {
                if (iso.FileExists(StateFileName))
                {
                    using (IsolatedStorageFileStream stream = iso.OpenFile(StateFileName, FileMode.Open))
                    {
                        Model = (T)new XmlSerializer(typeof(T)).Deserialize(stream);
                        return true;
                    }
                }
            }
            catch
            {
                iso.DeleteFile(StateFileName);
            }
            Model = new T();
            return false;
        }
    }
}
