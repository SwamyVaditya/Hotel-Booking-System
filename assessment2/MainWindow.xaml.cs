﻿using System;
using System.Collections;
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


namespace assessment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ArrayList customerlist = new ArrayList();
        public ArrayList bookingslist = new ArrayList();
        Customer newCustomer = new Customer();
        
        public MainWindow()
        {
            InitializeComponent();
            var gridView = new GridView();
            lv_Customers.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Customer Ref   ",
                DisplayMemberBinding = new Binding("customerRef")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name                   ",
                DisplayMemberBinding = new Binding("name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Address                ",
                DisplayMemberBinding = new Binding("address")
            });
        }

        private void btn_addbooking_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new BookingWindow(this);
            newWindow.ShowDialog();
            //this.updateBookings();
        }

        private void btn_addcustomer_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CustomerWindow(this);
            newWindow.ShowDialog();
            

            
        }

        private void btn_invoice_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Invoice();
            newWindow.ShowDialog();
        }

        private void btn_quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void addcustomer(Customer newCustomer)
        {
            lb_customer.Items.Add(newCustomer.name + " " + newCustomer.address);
            lv_Customers.Items.Add(new Customer { customerRef = newCustomer.customerRef, name = newCustomer.name, address = newCustomer.address});
        }

        

        

    }
}
