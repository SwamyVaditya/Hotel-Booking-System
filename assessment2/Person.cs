using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment2
{
    public class Person
    {
        private string name;
        public string Name
        {
            //get and set name 
            get
            {
                return name;
            }
            set
            {
                //validation for the name 
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Name cannot be left blank.");
                }
                name = value;
            }
        }
    }
}
