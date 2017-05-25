using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace distant_orders_kdz
{
    public class UserOrder
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public UserOrder(string name, int price, string address, string zip_code, string phone, string mail, DateTime date)
        {
            _name = name;
            _price = price;
            _address = address;
            _zip_code = zip_code;
            _phone = phone;
            _mail = mail;
            _date = date;
        }
        public UserOrder()
        {

        }
    }
}
