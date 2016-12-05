using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment2
{
    public class Customer
    {
        private string name;
        private string address;
        private int customerRef;
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Name cannot be left blank.");
                }
                name = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Address cannot be left blank.");
                }
                address = value;
            }
        }

        public int CustomerRef
        {
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
