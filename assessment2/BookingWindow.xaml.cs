﻿using System;
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
        //static int BookingRef = 1;
        //List to store the guests that have been added to a booking
        public List<Guest> guestlist = new List<Guest>();

        public List<Guest> listOfGuest = new List<Guest>();

        bool edit;
        
        Booking booking;
        //List to store the customers 
        private List<Customer> customerlist = new List<Customer>();
        private List<Booking> bookinglist = new List<Booking>();
        //below allows the main window to be referenced outside of the booking window method below
        private MainWindow window;

        public BookingWindow(MainWindow window, List<Customer> customerlist)
        {
            InitializeComponent();
            this.window = window;
            this.customerlist = customerlist;
            
            for (int i = 0; i < this.customerlist.Count; i++)
            {
                booking_lv.Items.Add(this.customerlist[i].CustomerRef);
            }
        }


        public BookingWindow(MainWindow window, Booking booking, List<Customer> customerlist)
        {
            InitializeComponent();
            this.window = window;
            edit = true;
            this.booking = booking;
            this.customerlist = customerlist;
            for (int i = 0; i < this.customerlist.Count; i++)
            {
                booking_lv.Items.Add(this.customerlist[i].CustomerRef);
            }
            booking_lv.SelectedItem = booking.CustomerRef;
            date_arrivalDate.SelectedDate = booking.ArrivalDate;
            date_departureDate.SelectedDate = booking.DepartureDate;
           //load the guests for the booking into the window
            for (int i = 0; i < booking.ListOfGuests.Count; i++)
            {
                lv_guests.Items.Add(booking.ListOfGuests[i].name + " " + booking.ListOfGuests[i].passportNumber + " " + booking.ListOfGuests[i].age);
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
            if (!edit)
            {
                Booking newbooking = new Booking();
                try
                {
                    newbooking.CustomerRef = Int32.Parse(booking_lv.SelectedItem.ToString());
                    newbooking.ArrivalDate = (DateTime)date_arrivalDate.SelectedDate;
                    newbooking.DepartureDate = (DateTime)date_departureDate.SelectedDate;

                    // newbooking.ListOfGuests = lv_guests.Items.Cast<Guest>().Select(i => i).ToList();
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


                newbooking.BookingRef = window.idFactory.GetBookingNo();
                window.bookingslist.Add(newbooking);
                newbooking.ListOfGuests = guestlist;
                window.addbooking(newbooking);
                window.updateBookingList();

                this.Close();
            }
            else
            {
                try
                {
                    
                    booking.CustomerRef = Int32.Parse(booking_lv.SelectedItem.ToString());
                    booking.ArrivalDate = (DateTime)date_arrivalDate.SelectedDate;
                    booking.DepartureDate = (DateTime)date_departureDate.SelectedDate;

                    // newbooking.ListOfGuests = lv_guests.Items.Cast<Guest>().Select(i => i).ToList();
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
                booking.ListOfGuests = guestlist;
                
                window.updateBookingList();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            //if (!edit)
            //{
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
  

        private void btn_delguest_Click(object sender, RoutedEventArgs e)
        {
            //List<String> guestlist = new List<String>();
            //foreach (String eachItem in lv_guests.SelectedItems)
            //{
            //    guestlist.Add(eachItem);
            //}
            //foreach (String eachItem in guestlist)
            //{
            //    lv_guests.Items.Remove(eachItem);
            //}

            dynamic selected = lv_guests.SelectedItem;

            string name;
            name = selected;
            Guest newGuest = guestlist.Find(x => x.name == name);
            guestlist.Remove(newGuest);
            lv_guests.Items.Remove(selected);


        }

    }
}
