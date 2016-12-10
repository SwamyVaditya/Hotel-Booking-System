using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//David Gibson
//This class stores and validates details belonging to the Extras
//09/12/2016

namespace assessment2
{
    public class Extras
    {
        //private variables to store working data
        private bool eveningMeal;
        private string dietryInformation;
        private bool breakfast;
        private bool carHire;
        private DateTime hireStartDate;
        private DateTime hireEndDate;
        private string driver;

        public bool EveningMeal
        {
            //get and set evening meal
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
            //get and set the dietry information
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
            //get and set the breakfast
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
            //get and set the carhire
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
            //get and set the hire start date
            get
            {
                return hireStartDate;
            }
            set
            {
                //validation for the hire start date
                if (value == null)
                {
                    throw new NullReferenceException("Start Date cannot be left blank");
                }
                hireStartDate = value;
            }
        }
        public DateTime HireEndDate
        {
            //get and set the hire end date
            get
            {
                return hireEndDate;
            }
            set
            {
                //validation for the hire end date
                if (value == null)
                {
                    throw new NullReferenceException("End Date cannot be left blank");
                }
                hireEndDate = value;
            }
        }
        public string Driver
        {
            //get and set the driver
            get
            {
                return driver;
            }
            set
            {

                //validation for driver
                if (String.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("You must enter a driver name.");
                }
                driver = value;
            }
        }
    }
}
