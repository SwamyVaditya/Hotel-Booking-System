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

//David Gibson
//This class takes care of adding and editing the customers.
//09/12/2016

namespace assessment2
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        //using a mainwindow here so that I can access main window throughout this class
        private MainWindow window;
        bool edit;
        Customer customer;

        public CustomerWindow(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            //set the edit boolean to false 
            edit = false;
        }
        private List<Customer> customerlist = new List<Customer>();

        public CustomerWindow(MainWindow window, Customer customer)
        {
            InitializeComponent();
            this.window = window;
            //set the edit boolean to true
            edit = true;
            this.customer = customer;
            //load appropriate values into the text boxes
            txt_name.Text = customer.Name;
            txt_address.Text = customer.Address;
        }

        
        //when the cancel button is clicked then close the customer window 
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        //if the add customer button is clicked 
        private void btn_addCustomer_Click(object sender, RoutedEventArgs e)
        {
            //if adding as opposed to editing 
            if (!edit)
            {
                //create a new customer
                Customer newCustomer = new Customer();
                //set the appropriate values
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
                //get the customer number from the factory method getcustomerno
                newCustomer.CustomerRef = window.idFactory.GetCustomerNo();
                //add customer to the list
                window.customerlist.Add(newCustomer);
                //add customer to the listview
                window.addcustomer(newCustomer);
                // window.updateCustomerList();
                this.Close();
            }
            else
            {
                //set the appropriate values
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
                //identify customer by index
                int index = window.customerlist.FindIndex(x => x.CustomerRef == customer.CustomerRef);
                //update the values for the corresponding customer
                window.customerlist[index] = customer;
                window.updateCustomerList();
                //close the window
                this.Close();
            }
        }
    }
}
