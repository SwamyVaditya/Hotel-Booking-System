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
        private MainWindow mw;
        Booking newbooking = new Booking();
        public BookingWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_addbooking_Click(object sender, RoutedEventArgs e)
        {
            
            newbooking.BookingRef = int.Parse(txt_bookingref.Text);
            newbooking.ArrivalDate = (DateTime)date_arrivalDate.SelectedDate;
            newbooking.DepartureDate = (DateTime)date_departureDate.SelectedDate;
           MainWindow.bookingslist.Add(newbooking);

        }
    }
}
