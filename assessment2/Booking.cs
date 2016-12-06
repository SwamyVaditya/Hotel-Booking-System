using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment2
{
    public class Booking
    {
        private int customerRef;
        private int bookingRef;
        private DateTime arrivalDate;
        private DateTime departureDate;
        private List<Guest> listOfGuests = new List<Guest>();


        public int CustomerRef
        {
            get
            {
                return customerRef;
            }
            set
            {
                
                if (String.IsNullOrEmpty(value.ToString()))
                {
                    throw new NullReferenceException("You must select a customer reference number.");
                }
                customerRef = value;
            }
        }
        public int BookingRef
        {
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
            get
            {
                return arrivalDate;
            }
            set
            {
                if (arrivalDate == null)
                {
                    //throw new NullReferenceException("Arrival Date cannot be left blank");
                    throw new ArgumentException("Arrival Date cannot be left blank");
                }

                //if(arrivalDate==DateTime.MinValue)
                //{
                //    throw new ArgumentException("Arrival date must be added");
                //}
                //if(!arrivalDate.HasValue)

                //arrivalDate = value;
            }
        }

        public DateTime DepartureDate
        {
            get
            {
                return departureDate;
            }
            set
            {
                if (departureDate == null)
                {
                    throw new ArgumentException("Departure Date cannot be left blank");
                }
                //if (arrivalDate.Date < departureDate.Date)
                //{
                //    throw new Exception("Some exception");
                    
                //}                
                departureDate = value;
            }
        }



    public List<Guest> ListOfGuests
        {
            get
            {
                return listOfGuests;
            }
            set
            {
                listOfGuests = value;
            }
        } 
    }
}
