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
            
            double Nights = (booking.DepartureDate-booking.ArrivalDate).TotalDays;
            int ratePerNight = 0;
            double extrasCost = 0;
            double costNoExtras = 0;
            double hireDays = (booking.ListOfExtras[0].HireEndDate - booking.ListOfExtras[0].HireStartDate).TotalDays;

            if (booking.ListOfExtras[0].CarHire == true)
            {

                extrasCost = extrasCost + (50 * hireDays);
            }


            foreach (Guest g in booking.ListOfGuests)
            {
                if (g.age>18)
                {

                    ratePerNight = 50;
                }
                else
                {
                    ratePerNight = 30;
                }

                double CostPerPerson = Nights * ratePerNight;
                costNoExtras += CostPerPerson;
                if (booking.ListOfExtras[0].EveningMeal == true)
                {
                    extrasCost = extrasCost + 15 * Nights;
                }
                if (booking.ListOfExtras[0].Breakfast == true)
                {
                    extrasCost = extrasCost + 5 * Nights;
                }
            }
            CostPerNight.Content = "£" + costNoExtras / Nights;
            CostOfExtras.Content = "£" + extrasCost;
            TotalCost.Content = "£" + (costNoExtras + extrasCost);
        }
    }
}
