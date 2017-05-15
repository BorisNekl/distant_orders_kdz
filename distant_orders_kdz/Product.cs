using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace distant_orders_kdz
{
    public class Product
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

        public string showInfo()
        {
            return string.Format("{0} {1}", title, price);
        }
        static List<Product> products = new List<Product>();
        static string[] fileArray = null;
        public static List<Product> Read()
        {
            if (File.Exists("../../catalog.txt"))
            {
                fileArray = File.ReadAllLines("../../catalog.txt");
                foreach (string str in fileArray)
                {
                    string t = str.Split(' ')[0];
                    int p = int.Parse(str.Split(' ')[1]);
                    Product pr = new Product(t,p);
                    products.Add(pr);
                }
            }
            return products;
        }
    }
}
