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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;

namespace distant_orders_kdz
{
    /// <summary>
    /// Interaction logic for PageCart.xaml
    /// </summary>
    public partial class PageCart : Page
    {
        private Order _neworder = new Order();
        static List<Order> orders = new List<Order>();
        static List<Product> products = new List<Product>();
        static List<User> users = new List<User>();
        public PageCart()
        {
            InitializeComponent();
            ReadTemp();
            DeserializeOrder();
            listBox_order.ItemsSource = products;
            DeserializeUser();
        }
        public void Refresh()
        {
            DeserializeUser();
            foreach (User u in users)
            {
                if (u.Check)
                {
                    textBox_mail.Text = u.Mail;
                    textBox_mail.IsEnabled = false;
                    textBox_name.Text = u.Name;
                    textBox_name.IsEnabled = false;
                    textBox_surname.Text = u.Surname;
                    textBox_surname.IsEnabled = false;
                }
            }
        }
        private void DeserializeUser()
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
        private void ReadTemp()
        {
            if (File.Exists("temp.txt"))
            {
                using(FileStream fs = new FileStream("temp.txt", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string str = sr.ReadLine();
                        string[] strarray = str.Split(',');
                        foreach(string s in strarray)
                        {
                            string t = s.Split(' ')[0];
                            int p = int.Parse(s.Split(' ')[1]);
                            Product pr = new Product(t, p);
                            products.Add(pr);
                        }
                    }
                }
            }
        } 
        public void RefreshListBox()
        {
            foreach (Product pr in products.ToArray())
            {
                products.Remove(pr);
            }
            ReadTemp();
            listBox_order.ItemsSource = null;
            listBox_order.ItemsSource = products;
        }
        private void button_checkout_Click(object sender, RoutedEventArgs e)
        {
            int p, c, a ;
            if (int.TryParse(textBox_phone.Text, out p) && int.TryParse(textBox_code.Text, out c) && !int.TryParse(textBox_address.Text, out a))
            {
                _neworder = new Order(textBox_name.Text, textBox_surname.Text, textBox_mail.Text, textBox_phone.Text, textBox_address.Text, textBox_code.Text, products, DateTime.Now);
                orders.Add(_neworder);
                SerializeOrder();      
                File.Delete("temp.txt");
                textBox_phone.Text = "";
                textBox_address.Text = "";
                textBox_code.Text = "";
                listBox_order.ItemsSource = null;
                MessageBox.Show("We have your order now! You can check it by pressing the button 'Your orders'", "Success!");
            }
            else
            {
                MessageBox.Show("Check the information", "ERROR");
            }
        }
        private void SerializeOrder()
        {
            using (FileStream fs = new FileStream("orders.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Order>));
                ser.Serialize(fs, orders);
            }
        }
        private void DeserializeOrder()
        {
            if (File.Exists("orders.xml"))
            {
                using (FileStream fs = new FileStream("orders.xml", FileMode.Open))
                {
                    XmlSerializer deser = new XmlSerializer(typeof(List<Order>));
                    orders = (List<Order>)deser.Deserialize(fs);
                }
            }
        }
        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void button_order_Click(object sender, RoutedEventArgs e)
        {
            Pages.PageUserOrders.RefreshDataGrid();
            NavigationService.Navigate(Pages.PageUserOrders);
        }
    }
}
