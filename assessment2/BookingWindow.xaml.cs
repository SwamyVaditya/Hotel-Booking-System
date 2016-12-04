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
        //Set Up auto increment for the booking ref
        static int BookingRef = 1;
        //ArrayList to store the guests that have been added to a booking
        public ArrayList guestlist = new ArrayList();
        //ArrayList to store the customers 
        private List<Customer> customerlist = new List<Customer>();
        //below allows the main window to be referenced outside of the booking window method below
        private MainWindow window;

        public BookingWindow(MainWindow window, List<Customer> customerlist)
        {
            InitializeComponent();
            this.window = window;
            this.customerlist = customerlist;
            for (int i = 0; i < this.customerlist.Count; i++)
            {
                booking_lv.Items.Add(this.customerlist[i].customerRef);
            }
        }

        //When the cancel button is clicked then close the program
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //When the add booking button is clicked then set the values for the variables in the booking class
        private void btn_addbooking_Click(object sender, RoutedEventArgs e)
        {
            Booking newbooking = new Booking();

            try
            {
                newbooking.CustomerRef = Int32.Parse(booking_lv.SelectedItem.ToString());
                newbooking.ArrivalDate = (DateTime)date_arrivalDate.SelectedDate;
                newbooking.DepartureDate = (DateTime)date_departureDate.SelectedDate;
            }

            catch (NullReferenceException empty)
            {
                MessageBox.Show("An error has occured: " + empty.Message);
                return;
            }

            catch (Exception dateNotBlank)
            {
                MessageBox.Show("An error has occured: " + dateNotBlank.Message);
                return;
            }

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
            catch (Exception ntblank)
            {
                MessageBox.Show("An error has occured: " + ntblank.Message);
                return;
            }
            try
            {
                newGuest.passportNumber = txt_passport.Text;
            }
            catch (ArgumentException blankOrTooLong)
            {
                MessageBox.Show("An error has occured: " + blankOrTooLong.Message);
                return;
            }

            try
            {
                newGuest.age = int.Parse(txt_age.Text);
            }
            catch (ArgumentException outrange)
            {
                MessageBox.Show("An error has occured: " + outrange.Message);
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("An error has occured: Is not a numnber");
                return;
            }
            txt_name.Clear();
            txt_passport.Clear();
            txt_age.Clear();
            guestlist.Add(newGuest);
            lv_guests.Items.Add(newGuest.name + " " + newGuest.passportNumber + " " + newGuest.age);

        }



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
            List<String> guestlist = new List<String>();
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
