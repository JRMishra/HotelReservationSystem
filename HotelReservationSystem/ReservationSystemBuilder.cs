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
            MiamiHotels.AddHotel("Lakewood", 110,80);
            MiamiHotels.AddHotel("Bridgewood", 150,50);
            MiamiHotels.AddHotel("Ridgewood", 220,160);
        }
         
        /// <summary>
        /// Method to find cheapest hotel for a given duration
        /// </summary>
        /// <returns>Hotel with lowest total rate</returns>
        public Hotel FindHotel(int duration)
        {
            double minCost = MiamiHotels.HotelList.Min(h => h.Value.WeekdayRates * duration);
            Hotel cheapestHotel = (MiamiHotels.HotelList.Values.Select(h=>h).Where(h => h.WeekdayRates * duration == minCost)).First();
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
            if (duration == -1)
                throw new HotelReservationException(HotelReservationException.ExceptionType.ENDDATE_BEFORE_STARTDATE, "End date can not be before start date");
            Hotel hotel = FindHotel(duration);
            return hotel.Name + ","+" Total Rates: $"+hotel.WeekdayRates*duration;
        }

    }
}
