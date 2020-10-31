using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace HotelReservationSystem
{
    public class MiamiHotels
    {
        public static List<Hotel> hotelList = new List<Hotel>();

        public static void AddHotel(string hotelName, double dailyRate)
        {
            Hotel hotel = new Hotel(hotelName, dailyRate);
            hotelList.Add(hotel);
        }
    }
}
