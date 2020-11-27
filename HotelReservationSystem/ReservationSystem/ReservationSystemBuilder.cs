using HotelReservationSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ReservationSystemDALayer;
using System.Data;

namespace HotelReservationSystem
{
    public class ReservationSystemBuilder : IReservationSystemBuilder
    {
        public ReservationSystemBuilder()
        {
            //AddDefaultHotelData();
            AddSqlServerHotelDetails();
        }

        /// <summary>
        /// Add some default hotels details to Reservation System
        /// </summary>
        private static void AddDefaultHotelData()
        {
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 110, 80, 90, 80, 3);
            MiamiHotels.AddHotel("Bridgewood", 150, 110, 50, 50, 4);
            MiamiHotels.AddHotel("Ridgewood", 220, 100, 150, 40, 5);
        }

        /// <summary>
        /// Add miami hotel details from local sql server
        /// </summary>
        private static void AddSqlServerHotelDetails()
        {
            IEnumerable<DataRow> hotelDetails = SqlServerOperations.GetAllHotelDetails();
            foreach(DataRow row in hotelDetails)
            {
                MiamiHotels.HotelList.Clear();
                MiamiHotels.AddHotel(row.Field<string>("HotelName"), Convert.ToDouble(row.Field<Double>("WeekdayRate")), Convert.ToDouble(row.Field<Double>("WeekendRate")),
                   Convert.ToDouble(row.Field<Double>("SpecialWeekdayRate")), Convert.ToDouble(row.Field<Double>("SpecialWeekendRate")), row.Field<int>("Rating"));
            }
        }

        /// <summary>
        /// Method to find cheapest hotel for a given duration
        /// </summary>
        /// <returns>Hotel with lowest total rate</returns>
        public IEnumerable<Hotel> FindCheapestHotelForNormalCustomer(int duration, int weekendCount)
        {
            double minCost = MiamiHotels.HotelList.Min(h => h.Value.WeekdayRates * (duration-weekendCount)+h.Value.WeekendRates*weekendCount);
            IEnumerable<Hotel> cheapestHotel = MiamiHotels.HotelList.Values.Where(h => (h.WeekdayRates * (duration - weekendCount) + h.WeekendRates * weekendCount) == minCost);
            return cheapestHotel;
        }

        /// <summary>
        /// Find cheapest hotel for a reward customer
        /// </summary>
        public IEnumerable<Hotel> FindCheapestHotelForRewardCustomer(int duration, int weekendCount)
        {
            double minCost = MiamiHotels.HotelList.Min(h => h.Value.SpecialNormalRate * (duration - weekendCount) + h.Value.SpecialWeekendRate * weekendCount);
            IEnumerable<Hotel> cheapestHotel = MiamiHotels.HotelList.Values.Where(h => (h.SpecialNormalRate * (duration - weekendCount) + h.SpecialWeekendRate * weekendCount) == minCost);
            return cheapestHotel;
        }

        /// <summary>
        /// Method to return details of cheapest hotel for given range of dates
        /// </summary>
        public string FindHotel( string start, string end, string customerType="Normal")
        {
            DateTime startDate = DateParser.ConvertToDate(start);
            DateTime endDate = DateParser.ConvertToDate(end);
            int duration = DateParser.FindDuration(startDate, endDate);
            int weekendCount = DateParser.WeekendCount(startDate, endDate);
            
            if (duration == -1)
                throw new HotelReservationException(HotelReservationException.ExceptionType.ENDDATE_BEFORE_STARTDATE, "End date can not be before start date");

            IEnumerable<Hotel> hotels;
            double totalRate;
            if (customerType.ToLower().Contains("reward"))
            {
                hotels = FindCheapestHotelForRewardCustomer(duration, weekendCount);
            }
            else
            {
                hotels = FindCheapestHotelForNormalCustomer(duration, weekendCount);
            }
            Hotel hotel = hotels.First();
            foreach (Hotel eachHotel in hotels.Skip(1))
            {
                if(eachHotel.Rating>hotel.Rating)
                {
                    hotel = eachHotel;
                }
            }
            if (customerType.ToLower().Contains("reward"))
            {
                totalRate = (hotel.SpecialNormalRate * (duration - weekendCount) + hotel.SpecialWeekendRate * weekendCount);
            }
            else
            {
                totalRate = (hotel.WeekdayRates * (duration - weekendCount) + hotel.WeekendRates * weekendCount);
            }
            return hotel.Name + ","+" Total Rates: $"+ totalRate;
        }

        /// <summary>
        /// For a date range, give best rated hotel and details
        /// </summary>
        public string FindBestRatedHotel(string start, string end)
        {
            DateTime startDate = DateParser.ConvertToDate(start);
            DateTime endDate = DateParser.ConvertToDate(end);
            int duration = DateParser.FindDuration(startDate, endDate);
            int weekendCount = DateParser.WeekendCount(startDate, endDate);

            if (duration == -1)
                throw new HotelReservationException(HotelReservationException.ExceptionType.ENDDATE_BEFORE_STARTDATE, "End date can not be before start date");

            int bestRating = MiamiHotels.HotelList.Max(h => h.Value.Rating);
            Hotel bestRatedHotel = MiamiHotels.HotelList.Values.Where(h => h.Rating == bestRating).First();
            return bestRatedHotel.Name + "," + " Total Rates: $" + (bestRatedHotel.WeekdayRates * (duration - weekendCount) + bestRatedHotel.WeekendRates * weekendCount);
        }
    }
}
