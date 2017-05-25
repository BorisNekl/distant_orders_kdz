using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace distant_orders_kdz
{
    public class Order
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        private string _phone;
        
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _mail;

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _zip_code;

        public string Zip_code
        {
            get { return _zip_code; }
            set { _zip_code = value; }
        }
        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private List<Product> _products;

        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public Order(string name, string surname, string mail, string phone, string address, string zip_code, List<Product> products, DateTime date)
        {
            _name = name;
            _surname = surname;
            _mail = mail;
            _phone = phone;
            _address = address;
            _zip_code = zip_code;
            _products = products;
            _date = date;
        }
        public Order()
        {

        }
    }
}
