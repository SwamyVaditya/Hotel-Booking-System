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
using System.IO;
using Newtonsoft.Json;

//David Gibson
//This class stores all the controls for the main GUI window.
//I also load and save the data to and from the JSON files in this class.
//09/12/2016

namespace assessment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //instantiate
        public RefNoFactory idFactory;
        public List<Customer> customerlist = new List<Customer>();
        public List<Booking> bookingslist = new List<Booking>();
        
        //declare instances of booking and customer
        Customer newCustomer = new Customer();
        Booking newBooking = new Booking();

        public MainWindow()
        {
            InitializeComponent();
            //use grid over listview to allow for collumns
            var gridView = new GridView();
            lv_Customers.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Customer Ref               ",
                DisplayMemberBinding = new Binding("CustomerRef")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name                          ",
                DisplayMemberBinding = new Binding("Name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Address                      ",
                DisplayMemberBinding = new Binding("Address")
            });

            //use grid over listview to allow for collumns
            var gridView1 = new GridView();
            lv_bookings.View = gridView1;

            gridView1.Columns.Add(new GridViewColumn
            {
                Header = "Booking Ref       ",
                DisplayMemberBinding = new Binding("BookingRef")
            });
            gridView1.Columns.Add(new GridViewColumn
            {
                Header = "Customer Ref      ",
                DisplayMemberBinding = new Binding("CustomerRef")
            });

            gridView1.Columns.Add(new GridViewColumn
            {
                Header = "Arrival Date      ",
                DisplayMemberBinding = new Binding("ArrivalDate")
            });
            gridView1.Columns.Add(new GridViewColumn
            {
                Header = "Departure Date    ",
                DisplayMemberBinding = new Binding("DepartureDate")
            });

            loadInformation();
            idFactory = new RefNoFactory(this);
        }

        //load information about customers and lists from JSON files into their corresponding lists
        private void loadInformation()
        {
            try
            {
                using (StreamReader file = File.OpenText(@"H:\assessment2\HotelSystemData\Customers.json"))
                {
                    string dataFromFile = File.ReadAllText(@"H:\assessment2\HotelSystemData\Customers.json");
                    //add customers from the customerlist
                    customerlist = JsonConvert.DeserializeObject<List<Customer>>(dataFromFile);
                    //add each customer from the customer lists into the listview using the add method 
                    foreach (Customer customer in customerlist)
                    {
                        addcustomer(customer);
                    }
                }
            }
            catch (Exception e)
            {
                //There shouldn't be any errors but if there are then catch them and display the appropriate error messasge 
                MessageBox.Show(e.ToString());
            }

            try
            {
                using (StreamReader file = File.OpenText(@"H:\assessment2\HotelSystemData\Bookings.json"))
                {
                    string dataFromFile = File.ReadAllText(@"H:\assessment2\HotelSystemData\Bookings.json");
                    bookingslist = JsonConvert.DeserializeObject<List<Booking>>(dataFromFile);
                    foreach (Booking booking in bookingslist)
                    {
                        addbooking(booking);
                    }
                }
            }
            catch (Exception e)
            {
                //There shouldn't be any errors but if there are then catch them and display the appropriate error messasge 
                MessageBox.Show(e.ToString());
            }
        }

        //Factory uses this method to return the customer list 
        public List<Customer> GetListC()
        {
        return customerlist;
        }
        //Factory uses this method to return the bookings list 
        public List<Booking> GetListB()
        {
            return bookingslist;
        }

        //Method to save the data to from the lists to the appropriate file
        //This gets called in the save button method 
        private void saveData(List<Customer> customers, List<Booking> bookings)
        {
            File.WriteAllText(@"H:\assessment2\HotelSystemData\Customers.json", JsonConvert.SerializeObject(customers, Formatting.Indented));
            File.WriteAllText(@"H:\assessment2\HotelSystemData\Bookings.json", JsonConvert.SerializeObject(bookings, Formatting.Indented));
        }

        //When the add booking button is pressed open an add booking window and  pass through the mainwindow and the customerlist 
        private void btn_addbooking_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new BookingWindow(this, customerlist);
            newWindow.ShowDialog();
        }

        //When the add customer button is pressed open an add customer window and pass through the mainwindow 
        private void btn_addcustomer_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CustomerWindow(this);
            newWindow.ShowDialog();
        }

        private void btn_invoice_Click(object sender, RoutedEventArgs e)
        {
            dynamic selected = lv_bookings.SelectedItem;
            //if no item selected then display appropriate error message
            if (selected == null)
            {
                MessageBox.Show("You haven't selected a booking to display invoice for.");
                return;
            }
            int BookingRef;
            BookingRef = selected.BookingRef;
            Booking newBooking = bookingslist.Find(x => x.BookingRef == BookingRef);
            //open the invoice window and pass through the chosen booking
            var newWindow = new Invoice(newBooking);
            newWindow.ShowDialog();
        }

        //when clicked save the information for the bookings and customers
        private void btn_quit_Click(object sender, RoutedEventArgs e)
        {
            //call save data method 
            saveData(customerlist, bookingslist);
            this.Close();
        }

        //Add booking into the listview
        public void addbooking(Booking newBooking)
        {
            lv_bookings.Items.Add(new Booking { BookingRef = newBooking.BookingRef, CustomerRef = newBooking.CustomerRef, ArrivalDate = newBooking.ArrivalDate, DepartureDate = newBooking.DepartureDate });
            
        }

        //Add customer into the listview
        public void addcustomer(Customer newCustomer)
        {

            lv_Customers.Items.Add(new Customer { CustomerRef = newCustomer.CustomerRef, Name = newCustomer.Name, Address = newCustomer.Address });

        }

        public void updateBookingList()
        {
            //update method for the bookings listview
            lv_bookings.Items.Clear();
            foreach (Booking b in bookingslist)
            {
                lv_bookings.Items.Add(b);
            }

        }


        //update method for the customer listview
        public void updateCustomerList()
        {
            lv_Customers.Items.Clear();
            foreach (Customer c in customerlist)
            {
                lv_Customers.Items.Add(c);
            }
        }



        //delete the selected booking
        private void btn_deletebooking_Click(object sender, RoutedEventArgs e)
        {
            dynamic selected = lv_bookings.SelectedItem;
            //if no booking selected display error message 
            if (selected == null)
            {
                MessageBox.Show("You haven't selected a booking to delete.");
                return;
            }
            int bookingRef2 = 0;
            bookingRef2 = selected.BookingRef;
            Booking booking = bookingslist.Find(x => x.BookingRef == bookingRef2);
            bookingslist.Remove(booking);
            lv_bookings.Items.Remove(selected);

        }

        //delete the selected customer
        private void btn_deletecustomer_Click(object sender, RoutedEventArgs e)
        {
            dynamic selected = lv_Customers.SelectedItem;
            //if no customer selected then display error message
            if (selected == null)
            {
                MessageBox.Show("You haven't selected a customer to delete.");
                return;
            }
            int custRef = 0;
            custRef = selected.CustomerRef;
            Customer customer = customerlist.Find(x => x.CustomerRef == custRef);
            customerlist.Remove(customer);
            lv_Customers.Items.Remove(selected);
            
        }

        //edit the chosen booking
        private void btn_editbooking_Click(object sender, RoutedEventArgs e)
        {
            dynamic selected = lv_bookings.SelectedItem;
            //if no booking chosen then display error message 
            if (selected == null)
            {
                MessageBox.Show("You haven't selected a booking to edit.");
                return;  
            }
            
            int bref = 0;
            bref = selected.BookingRef;
            Booking booking = bookingslist.Find(x => x.BookingRef == bref);
            var newWindow = new BookingWindow(this, booking, customerlist);
            newWindow.ShowDialog();
        }

        //edit the chosen customer
        private void btn_editcustomer_Click(object sender, RoutedEventArgs e)
        {
            dynamic selected = lv_Customers.SelectedItem;
            //if no customer chosen then display error message 
            if (selected == null)
            {
                MessageBox.Show("You haven't selected a customer to edit.");
                return;
            }
            int custRef = 0;
            custRef = selected.CustomerRef;
            Customer customer = customerlist.Find(x => x.CustomerRef == custRef);
            var newWindow = new CustomerWindow(this, customer);
            newWindow.ShowDialog();

        }
    }
}
