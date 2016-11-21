using System;
using System.Collections;
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
        private ArrayList customerlist1=new ArrayList();
        private MainWindow window;
        
        public BookingWindow(MainWindow window, ArrayList customerlist)
        {
            InitializeComponent();
            this.window = window;
            customerlist1 = customerlist;
            foreach (var Item in customerlist1)
            {
                booking_lv.Items.Add(Item);
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_addbooking_Click(object sender, RoutedEventArgs e)
        {
            Booking newbooking = new Booking();
            newbooking.CustomerRef = Int32.Parse(booking_lv.SelectedItem.ToString());
            newbooking.ArrivalDate = (DateTime)date_arrivalDate.SelectedDate;
            newbooking.DepartureDate = (DateTime)date_departureDate.SelectedDate;
           
            this.Close();
        }

        private void btn_guest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Guest newGuest = new Guest();
            newGuest.name = txt_name.Text;
            newGuest.passportNumber = txt_passport.Text;
            newGuest.age = int.Parse(txt_age.Text);
            txt_name.Clear();
            txt_passport.Clear();
            txt_age.Clear();

            lv_guests.Items.Add(newGuest.name + "\n" + newGuest.passportNumber + "\n" + newGuest.age);

        }

        private void btn_delguest_Click(object sender, RoutedEventArgs e)
        {
            foreach (ListViewItem i in lv_guests.SelectedItems)
            {
                lv_guests.Items.Remove(i);

            }

            
        }

       
    }
}
