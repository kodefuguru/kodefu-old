namespace TouchCafe.ViewModels
{
    using System;
    using System.Windows.Input;
    using TouchCafe.Models;
    using TouchCafe.Service;
    using Windows7.Location;


    public class StartViewModel : ViewModel<OrderModel>
    {
        PointOfSaleService service;

        public StartViewModel(OrderModel orderModel)
        {
            service = new PointOfSaleService();
            Model = orderModel;
            DoneCommand = new DelegateCommand(Done, () => !String.IsNullOrWhiteSpace(Name));
            var provider = new LatLongLocationProvider(10000);
            try
            {
                var report = (LatLongLocationReport)provider.GetReport();
                service.ReportLocation(report.Latitude, report.Longitude);
            }
            catch
            {
                service.LocationMalfunction();
            }

        }

        public string Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public void Done()
        {
            Model.Status = OrderStatus.NameChosen;
            OrderRouter.Instance.Route(Model);
        }

        public ICommand DoneCommand { get; set; }
    }
}
