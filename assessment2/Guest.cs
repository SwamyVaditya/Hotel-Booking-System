using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment2
{
    public class Guest
    {
        private string Name;
        private string PassportNumber;
        private int Age;
        
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
                    throw new ArgumentException("Name cannot be left blank.");
                }
                Name = value;
            }
        }

        public string passportNumber
        {
            get
            {
                return PassportNumber;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Passport number cannot be left blank.");
                }
                PassportNumber = value;
            }
        }

        public int age
        {
            get
            {
                return Age;
            }
            set
            {
                if (value < 0 || value > 101 || String.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("Guest age must be within the specified range (0-101 Years old)");
                }
                Age = value;
            }
        }
    
    }
}
