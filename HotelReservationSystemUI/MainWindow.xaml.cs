using System;
using System.Collections.Generic;
using System.Globalization;
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
using HotelReservationSystem;

namespace HotelReservationSystemUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string radioBtnValue;

        public MainWindow()
        {
            InitializeComponent();
            CalendarDateRange dateRange = new CalendarDateRange(DateTime.MinValue, DateTime.Today);
            StartDate.BlackoutDates.Add(dateRange);
            EndDate.BlackoutDates.Add(dateRange);
        }

        /// <summary>
        /// Submit Button Click Event
        /// </summary>
        private void ReserveBtn_Click(object sender, RoutedEventArgs e)
        {
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();

            string customerType = radioBtnValue??"Normal";
            string startDate = StartDate.SelectedDate.Value.ToString("dd-MMMM-yyyy", CultureInfo.InvariantCulture);
            startDate = startDate.Replace("-", "");
            startDate = String.Concat(startDate.Where(c => !Char.IsWhiteSpace(c)));
            string endDate = EndDate.SelectedDate.Value.ToString("dd-MMMM-yyyy", CultureInfo.InvariantCulture);
            endDate = String.Concat(endDate.Where(c => !Char.IsWhiteSpace(c)));
            endDate = endDate.Replace("-", "");
            
            string sysResponse;
            try
            {
                sysResponse = reservationSystem.FindHotel(startDate, endDate, customerType);
            }
            catch(Exception)
            {
                sysResponse = "Error !";
            }
            ResultLbl.Content = "Cheapest Hotel with Best Rating :\n"+ sysResponse;
        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            radioBtnValue = "Normal";
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            radioBtnValue = "Reward";
        }

        /// <summary>
        /// Disable dates before selected start date in end date calender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EndDate.SelectedDate = null;
            CalendarDateRange dateRange = new CalendarDateRange(DateTime.MinValue, StartDate.SelectedDate??DateTime.Today);
            EndDate.BlackoutDates.Add(dateRange);
        }
    }
}