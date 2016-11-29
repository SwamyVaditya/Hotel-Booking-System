using System;
using System.Collections;
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
        Booking newBooking = new Booking();
        
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

          
            var gridView1 = new GridView();
            lv_bookings.View = gridView1;
            
            gridView1.Columns.Add(new GridViewColumn
            {
                Header = "Booking Ref                   ",
                DisplayMemberBinding = new Binding("BookingRef")
            });
            gridView1.Columns.Add(new GridViewColumn
            {
                Header = "Customer Ref                ",
                DisplayMemberBinding = new Binding("CustomerRef")
            });
        }

        private void btn_addbooking_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new BookingWindow(this, customerlist);
            newWindow.ShowDialog();
            
            
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


        public void addbooking(Booking newBooking)
        {

            lv_bookings.Items.Add(new Booking { BookingRef = newBooking.BookingRef, CustomerRef = newBooking.CustomerRef, ArrivalDate = newBooking.ArrivalDate, DepartureDate = newBooking.DepartureDate });

        }



        public void addcustomer(Customer newCustomer)
        {
           
            lv_Customers.Items.Add(new Customer { customerRef = newCustomer.customerRef, name = newCustomer.name, address = newCustomer.address});
            
        }


        public void updateBookingList()
        {
            lv_bookings.Items.Clear();
            foreach(Booking b in bookingslist)
            {
                lv_bookings.Items.Add(b);
            }

        }



        public void updateCustomerList()
        {
            lv_Customers.Items.Clear();
        foreach(Customer c in customerlist)
        {
            lv_Customers.Items.Add(c);
        }
        }


        private void btn_deletebooking_Click(object sender, RoutedEventArgs e)
        {
            var selected = lv_bookings.SelectedItem;
            bookingslist.Remove(selected);
            updateBookingList();

        }

        private void btn_deletecustomer_Click(object sender, RoutedEventArgs e)
        {
            var selected = lv_Customers.SelectedItem;
            customerlist.Remove(selected);
            updateCustomerList();








          /*  List <String> CustomerList = new List<String>(); 
             foreach (Customer eachItem in lv_Customers.SelectedItems)
            {
               CustomerList.Add(eachItem);
            }
             foreach (String eachItem in CustomerList)
             {
                 lv_Customers.Items.Remove(eachItem);
             }*/
            //lv_Customers.SelectedIndex
           /* foreach (Customer eachitem in lv_Customers.SelectedItems)
            {
                lv_Customers.Items.Remove(eachitem);
            }*/
        }

       

        

        

    }
}
