namespace TouchCafe
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            if (!DigitizerCapabilities.IsMultiTouchReady)
            {
                MessageBox.Show("Does not support multitouch");
                Environment.Exit(1);
            }

            OrderRouter.Instance.RegisterContainer(grid.Children).Route();
        }
    }
}
