using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace distant_orders_kdz
{
    class AddUser
    {
        public static void Adding( string n, string s, string m, string p)
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
