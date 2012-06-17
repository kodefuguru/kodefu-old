namespace TouchCafe.ViewModels
{
    using System.Linq;
    using TouchCafe.Models;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class OrderViewModel : ViewModel<OrderModel>
    {
        private ObservableCollection<Selectable<ItemModel>> items;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderViewModel" /> class.
        /// </summary>
        /// <param name="orderModel">The order model.</param>
        public OrderViewModel(OrderModel orderModel)
        {
            Model = orderModel;
            ItemRepository repository = new ItemRepository();
            items = repository.GetAll().ToSelectable().ToObservable();
            CheckoutCommand = new DelegateCommand(Checkout);
            OpenItemCommand = new DelegateCommand<ItemModel>(OpenItem);
        }

        private void Checkout()
        {
            Model.Items = items.Where(i => i.Selected)
                               .Select(i => i.Value)
                               .ToObservable();

            Model.Status = OrderStatus.ItemsSelected;
            OrderRouter.Instance.Route(Model);
        }

        public void OpenItem(ItemModel item)
        {
            OrderRouter.Instance.Route(item);
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

        public string Test
        {
            get
            {
                return Test;
            }
            set
            {
                Test = value;
                RaisePropertyChanged("Test");
            }
        }

        public ICommand CheckoutCommand { get; set; }
        public ICommand OpenItemCommand { get; set; }


        public ObservableCollection<Selectable<ItemModel>> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                RaisePropertyChanged("Items");
            }
        }
    }
}
