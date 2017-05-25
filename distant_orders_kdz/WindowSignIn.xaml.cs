using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace distant_orders_kdz
{
    /// <summary>
    /// Interaction logic for WindowSignIn.xaml
    /// </summary>
    public partial class WindowSignIn : Window
    {
        List<User> users = new List<User>();
        public WindowSignIn()
        {
            InitializeComponent();
        }

        private void deserialization()
        {
            if (File.Exists("users.xml"))
            {
                using (FileStream fs = new FileStream("users.xml", FileMode.Open))
                {
                    XmlSerializer deser = new XmlSerializer(typeof(List<User>));
                    users = (List<User>)deser.Deserialize(fs);
                }
            }
        }
        private void serializeUser()
        {
            using (FileStream fs = new FileStream("users.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<User>));
                ser.Serialize(fs, users);
            }
        }
        private string hash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_mail.Text))
            {
                if (!string.IsNullOrWhiteSpace(passwordBox.Password))
                {
                    deserialization();
                    int k = 0;
                    foreach (User user in users)
                    {
                        if (user.Mail == textBox_mail.Text && user.Password == hash(passwordBox.Password))
                        {
                            user.Check = true;
                            serializeUser();
                            DialogResult = true;
                            break;
                        }
                    }
                    foreach (User user in users)
                    {
                        if (!user.Check)
                        {
                            k += 1;
                        }
                    }
                    if (k == users.Count)
                    {
                        MessageBox.Show("Check your information", "ERROR");
                    }
                }
                else
                {
                    MessageBox.Show("Write password", "ERROR");
                    passwordBox.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Write e-mail", "ERROR");
                textBox_mail.Focus();
                return;
            }
            
        }
    }
}
