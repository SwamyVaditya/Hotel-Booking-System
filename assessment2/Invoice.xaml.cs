using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//David Gibson
//this class displays cost information for the booking
//09/12/2016
namespace assessment2
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        public Invoice(Booking booking)
        {
            InitializeComponent();
            //declare variables to hold information about the booking costs and time stayed/used extras
            double Nights = (booking.DepartureDate - booking.ArrivalDate).TotalDays;
            int ratePerNight = 0;
            double extrasCost = 0;
            double costNoExtras = 0;
            double hireDays = (booking.ListOfExtras[0].HireEndDate - booking.ListOfExtras[0].HireStartDate).TotalDays;

            //if the user has hired a car then add the cost of the hire to extras 
            if (booking.ListOfExtras[0].CarHire == true)
            {
                extrasCost = extrasCost + (50 * hireDays);
            }
            //for every guest that is a part of booking
            foreach (Guest g in booking.ListOfGuests)
            {
                if (g.Age > 18)
                {
                    //if the guest is over 18 then set the appropriate rate
                    ratePerNight = 50;
                }
                else
                {
                    //if the guest is under 18 then set the appropriate rate
                    ratePerNight = 30;
                }
                //set the cost per person
                double CostPerPerson = Nights * ratePerNight;
                //set the cost without the extras
                costNoExtras += CostPerPerson;
                //if the user has opted in for evening meals then add the cost of the meal to extras 
                if (booking.ListOfExtras[0].EveningMeal == true)
                {
                    extrasCost = extrasCost + 15 * Nights;
                }
                //if the user has opted in for breakfasts then add the cost of the meal to extras 
                if (booking.ListOfExtras[0].Breakfast == true)
                {
                    extrasCost = extrasCost + 5 * Nights;
                }
            }
            //Set the labels to their corresponding values
            CostPerNight.Content = "£" + costNoExtras / Nights;
            CostOfExtras.Content = "£" + extrasCost;
            TotalCost.Content = "£" + (costNoExtras + extrasCost);
        }
    }
}
