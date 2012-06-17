namespace TouchCafe.ViewModels
{
    using System.Linq;
    using TouchCafe.Models;
    using System.Collections.Generic;
    using TouchCafe.Service;
    using System.Windows.Input;

    public class CheckoutViewModel : ViewModel<OrderModel>
    {
        PointOfSaleService service;

        public CheckoutViewModel(OrderModel orderModel)
        {
            Model = orderModel;
            service = new PointOfSaleService();
            SubmitCommand = new DelegateCommand(Submit);    
        }

        private void Submit()
        {
            service.SubmitOrder(Model);
            Model.Status = OrderStatus.Submitted;
            OrderRouter.Instance.Route(Model);
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

        public IEnumerable<ItemModel> Items
        {
            get
            {
                return Model.Items;
            }
        }

        public double Total
        {
            get
            {
                return Model.Items.Select(i => i.Price).Sum();
            }
        }

        public ICommand SubmitCommand { get; set; }
    }
}
