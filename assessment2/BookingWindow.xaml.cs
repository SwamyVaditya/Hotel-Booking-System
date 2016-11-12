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
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        public BookingWindow()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_addbooking_Click(object sender, RoutedEventArgs e)
        {
            Booking newbooking = new Booking();
            newbooking.BookingRef = int.Parse(txt_bookingref.Text);
            newbooking.ArrivalDate = (DateTime)date_arrivalDate.SelectedDate;
            newbooking.DepartureDate = (DateTime)date_departureDate.SelectedDate;
            MainWindow.bookingslist.Add(newbooking);

        }
    }
}
