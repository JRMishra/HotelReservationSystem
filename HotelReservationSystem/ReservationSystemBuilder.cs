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
            MiamiHotels.AddHotel("Lakewood", 110);
            MiamiHotels.AddHotel("Bridgewood", 150);
            MiamiHotels.AddHotel("Ridgewood", 220);
        }
         
        /// <summary>
        /// Method to find cheapest hotel for a given duration
        /// </summary>
        /// <returns>Hotel with lowest total rate</returns>
        public Hotel FindHotel(int duration)
        {
            double minCost = MiamiHotels.HotelList.Min(h => h.Value.Rates * duration);
            Hotel cheapestHotel = (MiamiHotels.HotelList.Values.Select(h=>h).Where(h => h.Rates * duration == minCost)).First();
            return cheapestHotel;
        }

        /// <summary>
        /// Method to return details of cheapest hotel for given range of dates
        /// </summary>
        public string FindHotel(string startDate, string endDate)
        {
            int duration = FindDuration(startDate, endDate);
            Hotel hotel = FindHotel(duration);
            return hotel.Name + ","+" Total Rates: $"+hotel.Rates*duration;
        }

        /// <summary>
        /// Given start and end date, should return duration
        /// </summary>
        private int FindDuration(string start, string end)
        {
            int startDay,endDay;
            bool isStartDateNumeric = Int32.TryParse(start.Substring(0,2),out startDay);
            bool isEndDateNumeric  = Int32.TryParse(end.Substring(0, 2), out endDay);

            if(!isStartDateNumeric || !isEndDateNumeric)
                throw new HotelReservationException(HotelReservationException.ExceptionType.WRONG_DATE_FORMAT, "Wrong date format");
            
            if (startDay <= 0 || startDay > 31 || endDay <= 0 || endDay > 31)
                throw new HotelReservationException(HotelReservationException.ExceptionType.WRONG_DATE_VALUE, "Incorrect date value");
            
            int duration = endDay - startDay + 1;
            return duration;
        }
    }
}
