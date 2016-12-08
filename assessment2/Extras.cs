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
        private string dietryInformationEM;
        private bool breakfast;
        private string dietryInformationB;
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

        public string DietryInformationEM
        {
            get
            {
                return dietryInformationEM;
            }
            set
            {
                dietryInformationEM = value;
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

        public string DietryInformationB
        {
            get
            {
                return dietryInformationB;
            }
            set
            {
                dietryInformationB = value;
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
                driver = value;
            }
        }
    }
}
