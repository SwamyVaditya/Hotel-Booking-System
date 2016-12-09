using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

//David Gibson
//This class allows for unique customer and booking reference numbers 
//09/12/2016

namespace assessment2
{
    public class RefNoFactory
    {
        //start the auto increment at one for customer and booking reference numbers
        //they will be changed further down int if there are already existing customers
        int customerNo = 1;
        int bookingNo = 1;

        public RefNoFactory(MainWindow window)
        {
            //if the customer list isn't empty
            //meaning that customers already exist
            if (window.customerlist.Count != 0)
            {
                customerNo = window.GetListC().Last().CustomerRef + 1;
            }
            //if the bookings list isn't empty
            //meaning that bookings already exist
            if (window.bookingslist.Count != 0)
            {
                bookingNo = window.GetListB().Last().BookingRef + 1;
            }
        }

        //will be called in the customer window to get a new customer number
        public int GetCustomerNumber()
        {
            int reply = customerNo;
            customerNo++;
            return reply;
        }

        //will be called in the booking window to get a new booking number
        public int GetBookingNumber()
        {
            int reply = bookingNo;
            bookingNo++;
            return reply;
        }

        //method to increment the variable for the next customer
        public int GetCustomerNo()
        {
            int newCustomerNo = customerNo;
            customerNo++;
            return newCustomerNo;
        }

        //method to increment the variable for the next booking
        public int GetBookingNo()
        {
            int newBookingNo = bookingNo;
            bookingNo++;
            return newBookingNo;
        }


       
    }
}
