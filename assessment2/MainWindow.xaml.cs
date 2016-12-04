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
        public ArrayList bookingslist = new ArrayList();
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
                DisplayMemberBinding = new Binding("customerRef")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name                          ",
                DisplayMemberBinding = new Binding("name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Address                      ",
                DisplayMemberBinding = new Binding("address")
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
                /*Customer newCustomer = File.ReadAllText(@"H:\assessment2backup\data\customers.txt");
                foreach(Customer c in customerInformation)
                customerlist = JsonConvert.DeserializeObject<Customer>(customerInformation);*/
                
                using (StreamReader file = File.OpenText(@"H:\assessment2\HotelSystemData\Customers.json"))
                {

                    //JsonSerializer serializer = new JsonSerializer();
                    //List<Customer> newCustomerLi = (Customer)JsonConvert.DeserializeObjectList<Customer>();
                    string dataFromFile = File.ReadAllText(@"H:\assessment2\HotelSystemData\Customers.json");
                    customerlist = JsonConvert.DeserializeObject<List<Customer>>(dataFromFile);
                    //customerlist.Add(newCustomer);
                    foreach(Customer customer in customerlist)
                    {
                        addcustomer(customer);
                    }
                    
                    //customerlist.Add(JsonConvert.DeserializeObject<Customer>()) ;


                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("There is no file to write to, one will be made when you save customer information.");
            }
        }


        private void saveShit(List<Customer> data)
        {
            File.WriteAllText(@"H:\assessment2\HotelSystemData\Customers.json", JsonConvert.SerializeObject(data, Formatting.Indented));
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
            saveShit(customerlist);
            this.Close();
        }


        public void addbooking(Booking newBooking)
        {

            lv_bookings.Items.Add(new Booking { BookingRef = newBooking.BookingRef, CustomerRef = newBooking.CustomerRef, ArrivalDate = newBooking.ArrivalDate, DepartureDate = newBooking.DepartureDate });

        }



        public void addcustomer(Customer newCustomer)
        {

            lv_Customers.Items.Add(new Customer { customerRef = newCustomer.customerRef, name = newCustomer.name, address = newCustomer.address });

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
            var selected = lv_bookings.SelectedItem;
            bookingslist.Remove(selected);
            updateBookingList();

        }

        private void btn_deletecustomer_Click(object sender, RoutedEventArgs e)
        {
            dynamic selected = lv_Customers.SelectedItem;

            int custRef = 0;
            custRef = selected.customerRef;
            Customer customer = customerlist.Find(x => x.customerRef == custRef);
            customerlist.Remove(customer);
            lv_Customers.Items.Remove(selected);
            //updateCustomerList();
        }







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
        //}

        private void btn_editbooking_Click(object sender, RoutedEventArgs e)
        {

        }









    }
}
