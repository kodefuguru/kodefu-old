//-----------------------------------------------------------------------
// <copyright file="OrderModel.cs" company="Microsoft">
//     Copyright (c) KodefuGuru, Microsoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace TouchCafe.Models
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// TODO: Provide summary section in the documentation header.
    /// </summary>
    public class OrderModel : NotifyPropertyChanged
    {
        private string name;
        private OrderStatus status;
        private ObservableCollection<ItemModel> items = new ObservableCollection<ItemModel>();

        public OrderModel()
        {
            status = OrderStatus.New;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        public ObservableCollection<ItemModel> Items
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

        public OrderStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                RaisePropertyChanged("Status");
            }
        }
    }
}
