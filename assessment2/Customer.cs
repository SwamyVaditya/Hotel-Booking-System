using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//David Gibson
//This class stores and validates details belonging to the customer
//09/12/2016
namespace assessment2
{
    public class Customer : Person
    {
        //create private variables for storing working user data
        private string address;
        private int customerRef;
        public string Address
        {
            //get and set address
            get
            {
                return address;
            }
            set
            {
                //validation for the address
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Address cannot be left blank.");
                }
                address = value;
            }
        }

        public int CustomerRef
        {
            //get and set customer reference
            get
            {
                return customerRef;
            }
            set
            {
                customerRef = value;
            }
        }
    }
}
