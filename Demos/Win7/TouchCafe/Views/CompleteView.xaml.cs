namespace TouchCafe.Views
{
    using System.Windows.Controls;
    using System.Windows.Input;
    using TouchCafe.ViewModels;
    
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class CompleteView : UserControl
    {
        private CompleteViewModel viewModel;

        public CompleteView(CompleteViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            viewModel.DoneCommand.Execute(null);
        }
    }
}
