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
                Age = value;
            }
        }
    
    }
}
