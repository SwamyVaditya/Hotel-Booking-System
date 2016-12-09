using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//David Gibson
//This class stores and validates details belonging to the guest
//09/12/2016

namespace assessment2
{
    public class Guest
    {
        //private variables to store working data
        private string Name;
        private string PassportNumber;
        private int Age;
        
        public string name
        {
            //get and set the name 
            get
            {
                return Name;
            }
            set
            {
                //validation for the name 
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be left blank.");
                }
                Name = value;
            }
        }

        public string passportNumber
        {
            //get and set the passport number
            get
            {
                return PassportNumber;
            }
            set
            {
                //validation for the passport number
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Passport number cannot be left blank.");
                }
                if (value.Length > 10)
                {
                    
                    throw new ArgumentException("Passport number cannot be less than 10 characters.");
                }
                PassportNumber = value;
            }
        }

        public int age
        {
            //get and set the age
            get
            {
                return Age;
            }
            set
            {
                //validation for the age 
                if (value < 0 || value > 101 || String.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("Guest age must be within the specified range (0-101 Years old)");
                }
                Age = value;
            }
        }
    
    }
}
