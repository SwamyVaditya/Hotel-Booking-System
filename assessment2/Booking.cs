﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment2
{
    class Booking
    {
        private int bookingRef;
        private DateTime arrivalDate;
        private DateTime departureDate;


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
                arrivalDate = value;
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
                departureDate = value;
            }
        }

       
    }
}