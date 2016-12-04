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
        static int CustomerRef;
        

        public CustomerWindow(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            CustomerRef = window.CustRef++;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        private void btn_addCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer newCustomer = new Customer();
            try
            {
                newCustomer.name = txt_name.Text;
                newCustomer.address = txt_address.Text;
            }
            catch (Exception ntblnk)
            {
                MessageBox.Show("An error has occured: " + ntblnk.Message);
                return;
            }
            CustomerRef++;
            newCustomer.customerRef = CustomerRef;
            window.customerlist.Add(newCustomer);
            window.addcustomer(newCustomer);
           // window.updateCustomerList();
            this.Close();
        }
    }
}
