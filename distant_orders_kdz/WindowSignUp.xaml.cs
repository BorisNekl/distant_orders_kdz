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
    /// Interaction logic for WindowSignUp.xaml
    /// </summary>
    public partial class WindowSignUp : Window
    {
        public WindowSignUp()
        {
            InitializeComponent();
        }

        private void button_adduser_Click(object sender, RoutedEventArgs e)
        {
            WindowSignUp m = new WindowSignUp();
            AddUser.Adding(textBox_name.Text, textBox_surname.Text, textBox_mail.Text, textBox_password.Text);
            m.Close();
        }
    }
}
