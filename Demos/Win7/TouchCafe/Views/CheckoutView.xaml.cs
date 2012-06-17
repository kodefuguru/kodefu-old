using System.Windows.Controls;
using TouchCafe.ViewModels;

namespace TouchCafe.Views
{
    /// <summary>
    /// Interaction logic for CheckoutView.xaml
    /// </summary>
    public partial class CheckoutView : UserControl
    {
        CheckoutViewModel viewModel;

        public CheckoutView(CheckoutViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel;
        }
    }
}
