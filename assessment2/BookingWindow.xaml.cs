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

//David Gibson
//This class takes care of adding and editing the bookings.
//09/12/2016

namespace assessment2
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        //List to store the guests that have been added to a booking
        public List<Guest> guestlist = new List<Guest>();
        public List<Guest> listOfGuest = new List<Guest>();
        //List to store the extras that have been added to a booking
        public List<Extras> elist = new List<Extras>();
        public List<Extras> listOfExtras = new List<Extras>();
        public bool error = false;
        public bool edit;
        //declare booking as a type booking
        Booking booking;
        //List to store the customers 
        private List<Customer> customerlist = new List<Customer>();
        //list to store booking
        private List<Booking> bookinglist = new List<Booking>();
        //below allows the main window to be referenced outside of the booking window method below
        private MainWindow window;

        public BookingWindow(MainWindow window, List<Customer> customerlist)
        {
            InitializeComponent();
            this.window = window;
            this.customerlist = customerlist;
            //add all items customer references the customer list into the list view
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
            //add all items customer references the customer list into the list view
            for (int i = 0; i < this.customerlist.Count; i++)
            {
                booking_lv.Items.Add(this.customerlist[i].CustomerRef);
            }
            //set the appropriate values
            booking_lv.SelectedItem = booking.CustomerRef;
            date_arrivalDate.SelectedDate = booking.ArrivalDate;
            date_departureDate.SelectedDate = booking.DepartureDate;
           //load the guests for the booking into the window
            for (int i = 0; i < booking.ListOfGuests.Count; i++)
            {
                lv_guests.Items.Add(booking.ListOfGuests[i].Name + " " + booking.ListOfGuests[i].PassportNumber + " " + booking.ListOfGuests[i].Age);
            }
                //load the values from the lists into the Gui controls as required
                if (booking.ListOfExtras[0].EveningMeal == true)
                {
                    chk_em.IsChecked = true;
                }
                else
                {
                    chk_em.IsChecked = false;
                }
                if (booking.ListOfExtras[0].Breakfast == true)
                {
                    chk_b.IsChecked = true;
                }
                else
                {
                    chk_b.IsChecked = false;
                }
                if (booking.ListOfExtras[0].CarHire == true)
                {
                    chk_c.IsChecked = true;
                    txt_name1.Text = booking.ListOfExtras[0].Driver;
                    hireStartDate.SelectedDate = booking.ListOfExtras[0].HireStartDate;
                    hireEndDate.SelectedDate = booking.ListOfExtras[0].HireEndDate;
                }
                else
                {
                    chk_c.IsChecked = false;
                }
                if (booking.ListOfExtras[0].EveningMeal == true || booking.ListOfExtras[0].Breakfast == true)
                {
                    txt_dietry.Text = booking.ListOfExtras[0].DietryInformation;
                }
        }


        //When the cancel button is clicked then close the program
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //add the extras to the booking
        public void addExtras(Booking newBooking)
        {
            Extras newExtras = new Extras();
            //if check boxes are checked then set the boolean to true, otherwise false
            if (chk_em.IsChecked == true)
            {
                newExtras.EveningMeal = true;
            }
            else
            {
                newExtras.EveningMeal = false;
            }

            if (chk_b.IsChecked == true)
            {
                newExtras.Breakfast = true;
            }
            else
            {
                newExtras.Breakfast = false;
            }

            if (chk_c.IsChecked == true)
            {
                newExtras.CarHire = true;
            }
            else
            {
                newExtras.CarHire = false;
            }
            //set the dietry information
            try
            {
                newExtras.DietryInformation = txt_dietry.Text;
            }
            catch (ArgumentException blank)
            {
                MessageBox.Show("An error has occured: " + blank.Message);
                error = true;
                return;
            }   
            //set the car hire details if the user has opted to hire a car
            if (newExtras.CarHire == true)
            {
                
                try
                {
                    newExtras.Driver = txt_name1.Text;
                    if (hireStartDate.SelectedDate >= DateTime.Today)
                    {
                        newExtras.HireStartDate = (DateTime)hireStartDate.SelectedDate;
                    }
                    else
                    {
                        throw new ArgumentException("The start date of the Car Hire is invalid.");
                    }
                    if (hireEndDate.SelectedDate >= DateTime.Today)
                    {
                        newExtras.HireEndDate = (DateTime)hireStartDate.SelectedDate;
                    }
                    else
                    {
                        throw new ArgumentException("The end date of the Car Hire is invalid.");
                    }
                }

                catch (Exception dateNotBlank)
                {
                    MessageBox.Show("An error has occured: " + dateNotBlank.Message);
                    error = true;
                    return;
                }     
            }
            //There were no errors as the code made it this far
            error = false;
            //addd the new details regarding the extras to the list of extras
            newBooking.ListOfExtras.Insert(0,newExtras);
    }

    //When the add booking button is clicked 
    private void btn_addbooking_Click(object sender, RoutedEventArgs e)
        {
            //if the user is adding a booking, as opposed to editing one  
            if (!edit)
            {
                //create a new booking
                Booking newbooking = new Booking();
                //set the appropriate values
                try
                {
                    newbooking.CustomerRef = Int32.Parse(booking_lv.SelectedItem.ToString());
                    if (date_arrivalDate.SelectedDate >= DateTime.Today)
                    {
                        newbooking.ArrivalDate = (DateTime)date_arrivalDate.SelectedDate;
                    } else
                    {
                        throw new ArgumentException("The arrival date is invalid");
                    }

                    if (date_departureDate.SelectedDate > newbooking.ArrivalDate)
                    {
                        newbooking.DepartureDate = (DateTime)date_departureDate.SelectedDate;
                    }
                    else
                    {
                        throw new ArgumentException("The depature date has to be after the arrival date");
                    }
                }
                catch (Exception dateNotBlank)
                {
                    MessageBox.Show("An error has occured: " + dateNotBlank.Message);
                    return;
                }
                //call the method get booking number thats stored in the factory 
                newbooking.BookingRef = window.idFactory.GetBookingNumber();
                //add booking to the booking list 
                window.bookingslist.Add(newbooking);
                //add the guests to the guest list 
                newbooking.ListOfGuests = guestlist;
                //call the add extras method 
                addExtras(newbooking);
                //if no errors call the addbooking method and add to the booking list
                if (error == false)
                { 
                    window.addbooking(newbooking);
                    window.updateBookingList();   
                    this.Close();
                }
            }
            //otherwise user is editing the booking
            else
            {
                //set the appropriate values
                try
                {
                    booking.CustomerRef = Int32.Parse(booking_lv.SelectedItem.ToString());
                    if (date_arrivalDate.SelectedDate >= DateTime.Today)
                    {
                        booking.ArrivalDate = (DateTime)date_arrivalDate.SelectedDate;
                    }
                    else
                    {
                        throw new ArgumentException("The arrival date is invalid");
                    }
                    if (date_departureDate.SelectedDate > booking.ArrivalDate)
                    {
                        booking.DepartureDate = (DateTime)date_departureDate.SelectedDate;
                    }
                    else
                    {
                        throw new ArgumentException("The depature date has to be after the arrival date");
                    }
                }
                catch (Exception dateNotBlank)
                {
                    MessageBox.Show("An error has occured: " + dateNotBlank.Message);
                    return;
                }
                //set the list of guests to the guestlist
                booking.ListOfGuests = guestlist;
                addExtras(booking);
                //if no errors call the addbooking method and add to the booking list
                if (error == false)
                {
                    window.updateBookingList();
                    this.Close();
                }
            }
        }

        //when the add guest button is clicked
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            //create a new booking
            Guest newGuest = new Guest();
            //set the appropriate values
            try
            {
                newGuest.Name = txt_name.Text;
            }
            catch (Exception ntblank)
            {
                MessageBox.Show("An error has occured: " + ntblank.Message);
                return;
            }
            try
            {
                newGuest.PassportNumber = txt_passport.Text;
            }
            catch (ArgumentException blankOrTooLong)
            {
                MessageBox.Show("An error has occured: " + blankOrTooLong.Message);
                return;
            }
            try
            {
                newGuest.Age = int.Parse(txt_age.Text);
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
            //clear the textboxes
            txt_name.Clear();
            txt_passport.Clear();
            txt_age.Clear();
            //add new guest to the guestlist
            guestlist.Add(newGuest);
            //add new guest to the listview
            lv_guests.Items.Add(newGuest.Name + " " + newGuest.PassportNumber + " " + newGuest.Age);
        }
  
        //when the delete guest button pressed
        private void btn_delguest_Click(object sender, RoutedEventArgs e)
        {
            //delete the selected guest
            dynamic selected = lv_guests.SelectedItem;
            //if no guest selected then display an error message
            if (selected == null)
            {
                MessageBox.Show("You haven't selected a guest to delete.");
                return;
            }
            string name;
            name = selected;
            Guest newGuest = guestlist.Find(x => x.Name == name);
            //remove from the list and the listview
            guestlist.Remove(newGuest);
            lv_guests.Items.Remove(selected);
        }
    }
}
