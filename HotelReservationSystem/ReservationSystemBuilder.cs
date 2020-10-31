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
            MiamiHotels.AddHotel("Lakewood", 110);
            MiamiHotels.AddHotel("Bridgewood", 150);
            MiamiHotels.AddHotel("Ridgewood", 110);
        }

        private Hotel FindCheapestHotel(int duration)
        {
            double minCost = MiamiHotels.HotelList.Min(h => h.Value.Rates * duration);
            Hotel cheapestHotel = (MiamiHotels.HotelList.Values.Select(h => h).Where(h => h.Rates * duration == minCost)).First();
            return cheapestHotel;
        }

        public string FindHotel(string startDate, string endDate)
        {
            int start = Int32.Parse((startDate[0] + startDate[1]).ToString());
            int end = Int32.Parse((endDate[0] + endDate[1]).ToString());
            int duration = end - start +1;

            Hotel hotel = FindCheapestHotel(duration);
            return hotel.Name + ","+"Total Rates: $"+hotel.Rates*duration;
        }
    }
}
