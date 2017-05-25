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
    /// Interaction logic for WindowSearch.xaml
    /// </summary>
    public partial class WindowSearch : Window
    {
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public WindowSearch()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if(!int.TryParse(textBox_name.Text, out n))
            {
                _name = textBox_name.Text;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Check your information", "ERROR");
            }
        }
    }
}
