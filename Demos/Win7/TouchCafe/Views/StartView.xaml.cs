namespace TouchCafe.Views
{
    using System.Windows.Controls;
    using System.Windows.Input;
    using TouchCafe.ViewModels;
    
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : UserControl
    {
        private StartViewModel viewModel;

        public StartView(StartViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Event is firing before binding is changing the value. This is to get the demo working.
            viewModel.Name = textBox.Text;

            if (viewModel.DoneCommand.CanExecute(null))
            {
                viewModel.DoneCommand.Execute(null);
            }
        }
    }
}
