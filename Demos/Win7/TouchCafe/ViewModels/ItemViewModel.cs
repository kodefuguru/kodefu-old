namespace TouchCafe.ViewModels
{
    using TouchCafe.Models;
    using System.Windows.Input;

    public class ItemViewModel : ViewModel<ItemModel>
    {
        private double angle;
        private double scaleX = 1;
        private double scaleY = 1;
        private double x;
        private double y;

        public ItemViewModel(ItemModel itemModel)
        {
            Model = itemModel;
            CloseCommand = new DelegateCommand(Close);    
        }

        private void Close()
        {
            OrderRouter.Instance.Main();
        }

        public string Image
        {
            get
            {
                return Model.Image;
            }
            set
            {
                Model.Image = value;
                RaisePropertyChanged("Image");
            }
        }

        public double Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
                RaisePropertyChanged("Angle");
            }
        }

        public double ScaleX
        {
            get
            {
                return scaleX;
            }
            set
            {
                scaleX = value;
                RaisePropertyChanged("ScaleX");
            }
        }

        public double ScaleY
        {
            get
            {
                return scaleY;
            }
            set
            {
                scaleY = value;
                RaisePropertyChanged("ScaleY");
            }
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                RaisePropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                RaisePropertyChanged("Y");
            }
        }
        public ICommand CloseCommand { get; set; }
    }
}
