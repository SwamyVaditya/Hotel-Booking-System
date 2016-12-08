using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace assessment2
{
    public class RefNoFactory
    {
        int customerNo = 1;
        int bookingNo = 1;

        MainWindow window;

        public RefNoFactory(MainWindow window)
        {
            this.window = window;
            System.Diagnostics.Debug.WriteLine(window.customerlist.Count);
            if (window.customerlist.Count != 0)
            {
                customerNo = window.GetListC().Last().CustomerRef + 1;
            }

            if (window.bookingslist.Count != 0)
            {
                bookingNo = window.GetListB().Last().CustomerRef + 1;
            }
        }

        public int GetCustomerNumber()
        {
            int reply = customerNo;
            customerNo++;
            return reply;
        }

        public int GetBookingNumber()
        {
            int reply = bookingNo;
            bookingNo++;
            return reply;
        }

        public int GetBookingNo()
        {
            int newBookingNo = bookingNo;
            bookingNo++;
            return newBookingNo;
        }


        public int GetCustomerNo()
        {
            int newCustomerNo = customerNo;
            customerNo++;
            return newCustomerNo;
        }
    }
}
