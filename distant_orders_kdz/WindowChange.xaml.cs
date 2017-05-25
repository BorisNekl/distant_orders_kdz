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

namespace distant_orders_kdz
{
    /// <summary>
    /// Interaction logic for WindowChange.xaml
    /// </summary>
    public partial class WindowChange : Window
    {
        public WindowChange()
        {
            InitializeComponent();
        }
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _zip_code;

        public string Zip_code
        {
            get { return _zip_code; }
            set { _zip_code = value; }
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            int p, c, a;
            if ((int.TryParse(textBox_phone.Text, out p) || textBox_phone.Text == "") && (int.TryParse(textBox_zipcode.Text, out c) || textBox_zipcode.Text == "") && (!int.TryParse(textBox_address.Text, out a) || textBox_address.Text == ""))
            {
                _phone = textBox_phone.Text;
                _address = textBox_address.Text;
                _zip_code = textBox_zipcode.Text;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Check the information", "ERROR");
            }
        }    
    }
}
