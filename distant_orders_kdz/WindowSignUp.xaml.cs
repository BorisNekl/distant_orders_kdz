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
using System.Security.Cryptography;

namespace distant_orders_kdz
{
    /// <summary>
    /// Interaction logic for WindowSignUp.xaml
    /// </summary>
    public partial class WindowSignUp : Window
    {
        private User _newuser = new User();

        public User newuser
        {
            get { return _newuser; }
        }

        public WindowSignUp()
        {
            InitializeComponent();
        }

        private void button_adduser_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_name.Text))
            {
                MessageBox.Show("Name can't be empty", "ERROR");
                textBox_name.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_surname.Text))
            {
                MessageBox.Show("Surname can't be empty", "ERROR");
                textBox_surname.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_mail.Text))
            {
                MessageBox.Show("Mail can't be empty", "ERROR");
                textBox_mail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(passwordBox_1.Password))
            {
                MessageBox.Show("Password can't be empty", "ERROR");
                passwordBox_1.Focus();
                return;
            }
            if(passwordBox_1.Password == passwordBox_2.Password)
            {
                _newuser = new User(textBox_name.Text, textBox_surname.Text, textBox_mail.Text, hash(passwordBox_1.Password), false);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Inserted passwords are different", "ERROR");
            }
            
        }

        private string hash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }
}
