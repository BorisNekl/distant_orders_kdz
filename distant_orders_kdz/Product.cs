using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace distant_orders_kdz
{
    class Product
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public Product(string title, int price)
        {
            this.title = title;
            this.price = price;
        }

    }
}
