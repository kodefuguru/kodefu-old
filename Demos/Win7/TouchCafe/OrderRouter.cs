using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using TouchCafe.Models;
using TouchCafe.Views;
using TouchCafe.ViewModels;

namespace TouchCafe
{
    public class OrderRouter
    {
        private UIElementCollection container;
        private Rule<OrderModel> routeRules;

        private static OrderRouter instance;
        public static OrderRouter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderRouter();
                }
                return instance;
            }
        }

        private OrderRouter()
        {
            routeRules = Rule.Create<OrderModel>(o => o.Status == OrderStatus.New, o => Route())
                             .Add(o => o.Status == OrderStatus.NameChosen, o => container.Add(new OrderView(new OrderViewModel(o))))
                             .Add(o => o.Status == OrderStatus.ItemsSelected, o => container.Add(new CheckoutView(new CheckoutViewModel(o))))
                             .Add(o => o.Status == OrderStatus.Submitted, o => container.Add(new CompleteView(new CompleteViewModel(o))));
        }

        public OrderRouter RegisterContainer(UIElementCollection container)
        {
            this.container = container;
            return this;
        }

        public void Route()
        {
            container.Clear();
            container.Add(new StartView(new StartViewModel(new OrderModel())));
        }

        public void Route(OrderModel order)
        {
            container.Clear();
            routeRules.Execute(order);     
        }

        public void Route(ItemModel item)
        {
            container.Add(new ItemView(new ItemViewModel(item)));
        }

        public void Main()
        {
            while (container.Count > 1)
            {
                container.RemoveAt(1);
            }
        }


    }
}
