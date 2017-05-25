using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace distant_orders_kdz
{
    static class Pages
    {
        static private PageCart _pageCart = new PageCart();

        static public PageCart PageCart
        {
            get { return _pageCart;  }
        }
        static private PageProduct _pageProduct = new PageProduct();

        static public PageProduct PageProduct
        {
            get { return _pageProduct; }
        }
        static private PageUserOrders _pageUserOrders = new PageUserOrders();

        static public PageUserOrders PageUserOrders
        {
            get { return _pageUserOrders; }
        }
    }
}
