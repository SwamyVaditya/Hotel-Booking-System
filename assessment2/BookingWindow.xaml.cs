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
using System.Windows.Shapes;

namespace assessment2
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        static int BookingRef = 1;
        public ArrayList guestlist = new ArrayList();
        private ArrayList customerlist1=new ArrayList();
        private MainWindow window;
        
        public BookingWindow(MainWindow window, ArrayList customerlist)
        {
            InitializeComponent();
            this.window = window;
            customerlist1 = customerlist;
            foreach (Customer Item in customerlist1)
            {
                booking_lv.Items.Add(Item.customerRef);
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_addbooking_Click(object sender, RoutedEventArgs e)
        {
            Booking newbooking = new Booking();
            
            newbooking.CustomerRef = Int32.Parse(booking_lv.SelectedItem.ToString());
            newbooking.ArrivalDate = (DateTime)date_arrivalDate.SelectedDate;
            newbooking.DepartureDate = (DateTime)date_departureDate.SelectedDate;
            newbooking.BookingRef = BookingRef++;
            window.bookingslist.Add(newbooking);
            window.addbooking(newbooking);
            window.updateBookingList();

            this.Close();
        }

        


        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Guest newGuest = new Guest();

            try
            {
                newGuest.name = txt_name.Text;
            }
            catch(Exception ntblank)
            {
                MessageBox.Show("An error has occured: " + ntblank.Message);
                return;
            }
            try
            {
                newGuest.passportNumber = txt_passport.Text;
            }
            catch (Exception blank)
            {
                MessageBox.Show("An error has occured: " + blank.Message);
               return;
            }
            try
            {
                newGuest.age = int.Parse(txt_age.Text);
            }
            catch (Exception outrange)
            {
                MessageBox.Show("An error has occured: " + outrange.Message);
                
            }


            
            txt_name.Clear();
            txt_passport.Clear();
            txt_age.Clear();




            guestlist.Add(newGuest);
           lv_guests.Items.Add(newGuest.name + " " + newGuest.passportNumber + " " + newGuest.age);
          // addGuest(newGuest);
           
        }

       // public void addGuest(Guest newGuest)
       // {
          //  lv_guests.Items.Add(new Guest { name = newGuest.name, age = newGuest.age, passportNumber = newGuest.passportNumber });
       // }

        public void updateGuestList()
        {
            lv_guests.Items.Clear();
            foreach (Guest g in guestlist)
            {
                lv_guests.Items.Add(g);
            }
        }

        private void btn_delguest_Click(object sender, RoutedEventArgs e)
        {
             List <String> guestlist = new List<String>(); 
             foreach (String eachItem in lv_guests.SelectedItems)
            {
               guestlist.Add(eachItem);
            }
             foreach (String eachItem in guestlist)
             {
                 lv_guests.Items.Remove(eachItem);
             } 
        }






       
    }
}
