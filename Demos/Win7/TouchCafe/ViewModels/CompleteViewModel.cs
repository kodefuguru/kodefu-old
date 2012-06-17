namespace TouchCafe.ViewModels
{
    using TouchCafe.Models;
    using System.Windows.Input;

    public class CompleteViewModel : ViewModel<OrderModel>
    {
        public CompleteViewModel(OrderModel orderModel)
        {
            Model = orderModel;
            DoneCommand = new DelegateCommand(Done);
        }

        public void Done()
        {
            OrderRouter.Instance.Route();
        }

        public ICommand DoneCommand { get; set; }
    }
}
