using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchCafe.Models
{
    public class ItemModel : NotifyPropertyChanged
    {
        private string image;
        private string name;
        private double price;

        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                RaisePropertyChanged("Image");
            }
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

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                RaisePropertyChanged("Price");
            }
        }
    }
}
