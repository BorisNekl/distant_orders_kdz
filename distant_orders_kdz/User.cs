using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace distant_orders_kdz
{
    public class User
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

        private string _mail;

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool _check;

        public bool Check
        {
            get { return _check; }
            set { _check = value; }
        }

        public User( string name, string surname, string mail, string password, bool check)
        {
            _name = name;
            _surname = surname;
            _mail = mail;
            _password = password;
            _check = check;
        }

        public static bool Search(List<User> users)
        {
            bool b = new bool();
            foreach(User u in users)
            {
                if (u.Check)
                {
                    b = true;
                }
            }
            return b;
        }
        public User()
        {

        }

    }
}
