using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//David Gibson
//This class stores and validates details belonging to the booking
//09/12/2016

namespace assessment2
{
    public class Booking
    {
        //create private variables for storing working data
        private int customerRef;
        private int bookingRef;
        private DateTime arrivalDate = DateTime.Now;
        private DateTime departureDate;
        private List<Guest> listOfGuests = new List<Guest>();
        private List<Extras> listOfExtras = new List<Extras>();

        public int CustomerRef
        {
            //get and set customer reference
            get
            {
                return customerRef;
            }
            set
            {
                //validation for the customer reference
                if (String.IsNullOrEmpty(value.ToString()))
                {
                    throw new NullReferenceException("You must select a customer reference number.");
                }
                customerRef = value;
            }
        }
        public int BookingRef
        {
            //get and set booking reference
            get
            {
                return bookingRef;
            }
            set
            {
                bookingRef = value;
            }
        }

        public DateTime ArrivalDate
        {
            //get and set arrival date 
            get
            {
                return arrivalDate;
            }
            set
            {
                //validation for the arrival date
                if (value == null)
                {
                    throw new NullReferenceException("Arrival Date cannot be left blank");
                }
                arrivalDate = value;
            }
        }

        public DateTime DepartureDate
        {
            //get and set departure date
            get
            {
                return departureDate;
            }
            set
            {
                //validation for the departure date
                if (value == null)
                {
                    throw new NullReferenceException("Departure Date cannot be left blank");
                }               
                departureDate = value;
            }
        }



    public List<Guest> ListOfGuests
        {
        //get and set listofguests 
            get
            {
                return listOfGuests;
            }
            set
            {
                listOfGuests = value;
            }
        }

        public List<Extras> ListOfExtras
        {
            //get and set listofextras
            get
            {
                return listOfExtras;
            }
            set
            {
                listOfExtras = value;
            }
        }

    }
}
