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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace assessment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ArrayList bookingslist = new ArrayList();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_addbooking_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new BookingWindow();
            newWindow.ShowDialog();
        }

        private void btn_addcustomer_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Customer();
            newWindow.ShowDialog();
        }

        private void btn_invoice_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Invoice();
            newWindow.ShowDialog();
        }

        private void btn_quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void updateBookings()
        {
            string [] title = {"BookingRef", "Arrival Date", "Departure Date"}
            
            //Update booking listview
            lv_bookings.Items.Clear();
            foreach(Booking b in bookingslist)
            {
               // lv_bookings.Items.Add("-").SubItems.AddRange(title);

                  /*ListViewItem item1 = new ListViewItem();
                  item1.SubItems.Add("SubItem1a");
                  item1.SubItems.Add("SubItem1b");
                  item1.SubItems.Add("SubItem1c");
                lv_bookings.Items.AddRange(new ListViewItem[] {item1}); */
            }
        }

    }
}
