namespace TouchCafe.Views
{
    using System.Windows.Controls;
    using System.Windows.Input;
    using TouchCafe.ViewModels;
    using System.Windows;
    
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class ItemView : UserControl
    {
        private ItemViewModel viewModel;
        private Point previousLocation;



        public ItemView(ItemViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel;
            MouseDown += ProcessDown;
            MouseMove += ProcessMove;
            MouseWheel += ProcessMouseWheel;
            //StylusDown += ProcessDown;
            //StylusMove += ProcessMove;
            //StylusSystemGesture += ProcessSystemGesture;
        }



        void ProcessSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            if (e.SystemGesture == SystemGesture.TwoFingerTap)
            {
                viewModel.CloseCommand.Execute(null);
            }
        }


        #region Mouse Events
        private void ProcessDown(object sender, MouseButtonEventArgs e)
        {
            previousLocation = e.GetPosition(canvas);
            if (e.ClickCount > 1)
            {
                viewModel.CloseCommand.Execute(null);
            }
        }

        private void ProcessMove(object sender, MouseEventArgs e)
        {


            if (e.LeftButton == MouseButtonState.Released)
                return;
            Point newLocation = e.GetPosition(canvas);

            viewModel.X += newLocation.X - previousLocation.X;
            viewModel.Y += newLocation.Y - previousLocation.Y;

            previousLocation = newLocation;
        }

        private void ProcessMouseWheel(object sender, MouseWheelEventArgs e)
        {
            double scalingFactor = 1 + e.Delta / 1000.0;
            viewModel.ScaleX *= scalingFactor;
            viewModel.ScaleY *= scalingFactor;
        }

        #endregion

        #region Touch Events
        private void ProcessDown(object sender, StylusEventArgs e)
        {
            previousLocation = e.GetPosition(canvas);
        }

        private void ProcessMove(object sender, StylusEventArgs e)
        {
            Point newLocation = e.GetPosition(canvas);

            viewModel.X += newLocation.X - previousLocation.X;
            viewModel.Y += newLocation.Y - previousLocation.Y;

            previousLocation = newLocation;
        }
        #endregion

        #region MultiTouch

        protected override void OnManipulationDelta(ManipulationDeltaEventArgs e)
        {
            viewModel.X += e.DeltaManipulation.Translation.X;
            viewModel.Y += e.DeltaManipulation.Translation.Y;
            viewModel.Angle += e.DeltaManipulation.Rotation;
            viewModel.ScaleX *= e.DeltaManipulation.Scale.X;
            viewModel.ScaleY *= e.DeltaManipulation.Scale.Y;
            e.Handled = true;
            base.OnManipulationDelta(e);
        }

        protected override void OnManipulationInertiaStarting(ManipulationInertiaStartingEventArgs e)
        {
            // 10 inches * 96 pixels / 1000ms^2
            e.TranslationBehavior.DesiredDeceleration = 10.0 * 96.0 / (1000.0 * 1000.0);

            // .1 inch * 96 pixels / 1000ms^2
            e.ExpansionBehavior.DesiredDeceleration = 0.1 * 96.0 / (1000.0 * 1000.0);

            // 2 rotations (360 * 2) per second (1000ms^2)
            e.RotationBehavior.DesiredDeceleration = 720 / (1000.0 * 1000.0);
            e.Handled = true;
            base.OnManipulationInertiaStarting(e);

        }

        protected override void OnManipulationStarting(ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = this;
            e.Handled = true;
            base.OnManipulationStarting(e);
        }

        #endregion
    }



}
