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

namespace assessment2
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        
        private MainWindow window;
        bool edit;
        Customer customer;

        public CustomerWindow(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            edit = false;
        }
        private List<Customer> customerlist = new List<Customer>();

        public CustomerWindow(MainWindow window, Customer customer)
        {
            InitializeComponent();
            this.window = window;
            edit = true;
            this.customer = customer;
            txt_name.Text = customer.Name;
            txt_address.Text = customer.Address;
        }

        

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        private void btn_addCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (!edit)
            {
                Customer newCustomer = new Customer();
                try
                {
                    newCustomer.Name = txt_name.Text;
                    newCustomer.Address = txt_address.Text;
                }
                catch (Exception ntblnk)
                {
                    MessageBox.Show("An error has occured: " + ntblnk.Message);
                    return;
                }
                newCustomer.CustomerRef = window.idFactory.GetCustomerNo();
                window.customerlist.Add(newCustomer);
                window.addcustomer(newCustomer);
                // window.updateCustomerList();
                this.Close();
            }
            else
            {

                try
                {
                    customer.Name = txt_name.Text;
                    customer.Address = txt_address.Text;
                }
                catch (Exception ntblnk)
                {
                    MessageBox.Show("An error has occured: " + ntblnk.Message);
                    return;
                }
                int index = window.customerlist.FindIndex(x => x.CustomerRef == customer.CustomerRef);
                window.customerlist[index] = customer;
                window.updateCustomerList();
                this.Close();
            }


        }
    }
}
