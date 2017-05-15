﻿using System;
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
using System.Xml.Serialization;
using System.IO;

namespace distant_orders_kdz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, RoutedEventArgs e)
        {
            WindowProducts a = new WindowProducts();
            MainWindow m = new MainWindow();
            m.Close();
            a.Show();
        }

        private void button_signup_Click(object sender, RoutedEventArgs e)
        {
            WindowSignUp a = new WindowSignUp();
            if(a.ShowDialog().Value)
            {
                users.Add(a.newuser);
                serializeUser();
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
        private void button_signin_Click(object sender, RoutedEventArgs e)
        {
            WindowSignIn a = new WindowSignIn();
            a.ShowDialog();
        }
    }
}
