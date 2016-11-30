using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment2
{
    public class Customer
    {
        private string Name;
        private string Address;
        private int CustomerRef;
        
        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Name cannot be left blank.");
                }
                Name = value;
            }
        }

        public string address
        {
            get
            {
                return Address;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Address cannot be left blank.");
                }
                Address = value;
            }
        }

        public int customerRef
        {
            get
            {
                return CustomerRef;
            }
            set
            {
                CustomerRef = value;
            }
        }
    }
}
