using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TouchCafe.ViewModels;
using TouchCafe.Models;

namespace TouchCafe.Views
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        private OrderViewModel viewModel;

        public OrderView(OrderViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Selectable<ItemModel> model in e.AddedItems)
            {
                model.Selected = true;
            }
            foreach (Selectable<ItemModel> model in e.RemovedItems)
            {
                model.Selected = false;
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = listBox.GetItem<Selectable<ItemModel>>(e.GetPosition(listBox));

            if (item != null)
            {
                viewModel.OpenItemCommand.Execute(item.Value);
            }

        }


    }
}
