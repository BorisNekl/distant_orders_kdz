using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace distant_orders_kdz
{
    class User
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public User( string name, string surname, string mail, string password)
        {
            this.name = name;
            this.surname = surname;
            this.mail = mail;
            this.password = password;
        }
        
        public static void AddUser(string n, string s, string m, string p)
        {
            using (FileStream fs = new FileStream("Users.txt", FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(n + ' ' + s + ' ' + m + ' ' + p);
                    sw.WriteLine();
                }
            }
        }
    }
}
