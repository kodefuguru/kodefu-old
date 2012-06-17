using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchCafe.Models
{
    public class ItemRepository
    {
        // Hard coded for demo
        public IEnumerable<ItemModel> GetAll()
        {
            return new[]
            {
                new ItemModel
                {
                    Name="Raisin Bagel",
                    Price = 4.06,
                    Image = "/Assets/raisinbagel.jpg"
                },
                new ItemModel
                {
                    Name="Blueberry Muffin",
                    Price = 3.50,
                    Image = "/Assets/blueberrymuffin.jpg"
                },
                new ItemModel
                {
                    Name="Cappuccino",
                    Price = 3.60,
                    Image = "/Assets/cappuccino.jpg"
                },
                new ItemModel
                {
                    Name="Mocha",
                    Price = 3.60,
                    Image = "/Assets/mocha.jpg"
                },
                new ItemModel
                {
                    Name="Nutella Bagel",
                    Price = 4.56,
                    Image = "/Assets/nutellabagel.jpg"
                },
                new ItemModel
                {
                    Name="Peach Muffin",
                    Price = 3.50,
                    Image = "/Assets/peachmuffin.jpg"
                },
                new ItemModel
                {
                    Name="Plain Bagel",
                    Price = 2.50,
                    Image = "/Assets/plainbagel.jpg"
                },
                new ItemModel
                {
                    Name="Strawberry Banana Muffin",
                    Price = 3.50,
                    Image = "/Assets/strawberrybananamuffin.jpg"
                },

            };
        }
    }
}
