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


namespace assessment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Customer> customerlist = new List<Customer>();
        public List<Booking> bookingslist = new List<Booking>();
        
        Customer newCustomer = new Customer();
        Booking newBooking = new Booking();

        private int customerReference;


        public int CustRef
        {
            get
            {
                return customerReference;
            }
            set
            {
                customerReference = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
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
        }


        private void loadInformation()
        {
            try
            {
                using (StreamReader file = File.OpenText(@"H:\assessment2\HotelSystemData\Customers.json"))
                {
                    string dataFromFile = File.ReadAllText(@"H:\assessment2\HotelSystemData\Customers.json");
                    customerlist = JsonConvert.DeserializeObject<List<Customer>>(dataFromFile);
                    foreach (Customer customer in customerlist)
                    {
                        addcustomer(customer);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                // MessageBox.Show("There is no file to write to, one will be made when you save customer information.");
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
                MessageBox.Show(e.ToString());
            }
        }


           


        private void saveData(List<Customer> customers, List<Booking> bookings)
        {
            File.WriteAllText(@"H:\assessment2\HotelSystemData\Customers.json", JsonConvert.SerializeObject(customers, Formatting.Indented));
            File.WriteAllText(@"H:\assessment2\HotelSystemData\Bookings.json", JsonConvert.SerializeObject(bookings, Formatting.Indented));
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
            saveData(customerlist, bookingslist);
            this.Close();
        }


        public void addbooking(Booking newBooking)
        {

            lv_bookings.Items.Add(new Booking { BookingRef = newBooking.BookingRef, CustomerRef = newBooking.CustomerRef, ArrivalDate = newBooking.ArrivalDate, DepartureDate = newBooking.DepartureDate });

        }



        public void addcustomer(Customer newCustomer)
        {

            lv_Customers.Items.Add(new Customer { CustomerRef = newCustomer.CustomerRef, Name = newCustomer.Name, Address = newCustomer.Address });

        }


        public void updateBookingList()
        {
            lv_bookings.Items.Clear();
            foreach (Booking b in bookingslist)
            {
                lv_bookings.Items.Add(b);
            }

        }



        public void updateCustomerList()
        {
            lv_Customers.Items.Clear();
            foreach (Customer c in customerlist)
            {
                lv_Customers.Items.Add(c);
            }
        }




        private void btn_deletebooking_Click(object sender, RoutedEventArgs e)
        {
            dynamic selected = lv_bookings.SelectedItem;
            int bookingRef2 = 0;
            bookingRef2 = selected.BookingRef;
            Booking booking = bookingslist.Find(x => x.BookingRef == bookingRef2);
            bookingslist.Remove(booking);
            lv_bookings.Items.Remove(selected);

        }

        private void btn_deletecustomer_Click(object sender, RoutedEventArgs e)
        {
            dynamic selected = lv_Customers.SelectedItem;

            int custRef = 0;
            custRef = selected.CustomerRef;
            Customer customer = customerlist.Find(x => x.CustomerRef == custRef);
            customerlist.Remove(customer);
            lv_Customers.Items.Remove(selected);
            
        }


        private void btn_editbooking_Click(object sender, RoutedEventArgs e)
        {

        }









    }
}
