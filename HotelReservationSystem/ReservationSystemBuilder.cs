using HotelReservationSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{
    public class ReservationSystemBuilder : IReservationSystemBuilder
    {
        public ReservationSystemBuilder()
        {
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 110,90,3);
            MiamiHotels.AddHotel("Bridgewood", 150,50,4);
            MiamiHotels.AddHotel("Ridgewood", 220,150,5);
        }
         
        /// <summary>
        /// Method to find cheapest hotel for a given duration
        /// </summary>
        /// <returns>Hotel with lowest total rate</returns>
        public IEnumerable<Hotel> FindCheapestHotel(int duration, int weekendCount)
        {
            double minCost = MiamiHotels.HotelList.Min(h => h.Value.WeekdayRates * (duration-weekendCount)+h.Value.WeekendRates*weekendCount);
            IEnumerable<Hotel> cheapestHotel = MiamiHotels.HotelList.Values.Where(h => (h.WeekdayRates * (duration - weekendCount) + h.WeekendRates * weekendCount) == minCost);
            return cheapestHotel;
        }

        /// <summary>
        /// Method to return details of cheapest hotel for given range of dates
        /// </summary>
        public string FindHotel(string start, string end)
        {
            DateTime startDate = DateParser.ConvertToDate(start);
            DateTime endDate = DateParser.ConvertToDate(end);
            int duration = DateParser.FindDuration(startDate, endDate);
            int weekendCount = DateParser.WeekendCount(startDate, endDate);
            
            if (duration == -1)
                throw new HotelReservationException(HotelReservationException.ExceptionType.ENDDATE_BEFORE_STARTDATE, "End date can not be before start date");
            
            IEnumerable<Hotel> hotels = FindCheapestHotel(duration, weekendCount);
            Hotel hotel = FindCheapestHotel(duration, weekendCount).First();
            foreach (Hotel eachHotel in hotels.Skip(1))
            {
                if(eachHotel.Rating>hotel.Rating)
                {
                    hotel = eachHotel;
                }
            }  
            return hotel.Name + ","+" Total Rates: $"+(hotel.WeekdayRates*(duration-weekendCount)+hotel.WeekendRates*weekendCount);
        }

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
