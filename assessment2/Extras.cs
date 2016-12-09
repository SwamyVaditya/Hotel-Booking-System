using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment2
{
    public class Extras
    {
        private bool eveningMeal;
        private string dietryInformation;
        private bool breakfast;
        private bool carHire;
        private DateTime hireStartDate;
        private DateTime hireEndDate;
        private string driver;


        public bool EveningMeal
        {
            get
            {
                return eveningMeal;
            }
            set
            {
                eveningMeal = value;
            }
        }

        public string DietryInformation
        {
            get
            {
                return dietryInformation;
            }
            set
            {
                dietryInformation = value;
            }
        }
        public bool Breakfast
        {
            get
            {
                return breakfast;
            }
            set
            {
                breakfast = value;
            }
        }

       

        public bool CarHire
        {
            get
            {
                return carHire;
            }
            set
            {
                carHire = value;
            }
        }

        public DateTime HireStartDate
        {
            get
            {
                return hireStartDate;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Start Date cannot be left blank");
                }
                hireStartDate = value;
            }
        }
        public DateTime HireEndDate
        {
            get
            {
                return hireEndDate;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("End Date cannot be left blank");
                }
                hireEndDate = value;
            }
        }
        public string Driver
        {
            get
            {
                return driver;
            }
            set
            {
                if (String.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("You must enter a driver name.");
                }
                driver = value;
            }
        }
    }
}
