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
        private string name;
        private string passportNumber;
        private int age;
        
        public string Name
        {
            //get and set the name 
            get
            {
                return name;
            }
            set
            {
                //validation for the name 
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be left blank.");
                }
                name = value;
            }
        }

        public string PassportNumber
        {
            //get and set the passport number
            get
            {
                return passportNumber;
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
                passportNumber = value;
            }
        }

        public int Age
        {
            //get and set the age
            get
            {
                return age;
            }
            set
            {
                //validation for the age 
                if (value < 0 || value > 101 || String.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("Guest age must be within the specified range (0-101 Years old)");
                }
                age = value;
            }
        }
    
    }
}
