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
using System.Windows.Shapes;

namespace assessment2
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow(Customer newCustomer)
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_addCustomer_Click(object sender, RoutedEventArgs e)
        {
            int CustomerRef = 0;
           // Customer newCustomer = new Customer();
            newCustomer.name = txt_name.Text;
            newCustomer.address = txt_address.Text;
            newCustomer.customerRef = CustomerRef + 1;
            
            this.Close();
           
        }
    }
}