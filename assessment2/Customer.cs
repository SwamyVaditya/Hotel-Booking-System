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
