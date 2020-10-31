using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace HotelReservationSystem
{
    public class MiamiHotels
    {
        static Dictionary<string,Hotel> hotelList = new Dictionary<string, Hotel>();

        public static Dictionary<string, Hotel> HotelList { get => hotelList; }

        public static void AddHotel(string hotelName, double dailyRate)
        {
            if (hotelName == null)
                throw new HotelReservationException(HotelReservationException.ExceptionType.NULL_HOTEL_NAME, "Hotel name can not be null");
           
            if (dailyRate == 0.0)
                throw new HotelReservationException(HotelReservationException.ExceptionType.ZERO_HOTEL_RATE, "Hotel rate can not be null");
            
            if(hotelList.ContainsKey(hotelName))
                throw new HotelReservationException(HotelReservationException.ExceptionType.HOTEL_ALREADY_EXISTS, "This hotel already exist");

            Hotel hotel = new Hotel(hotelName, dailyRate);
            hotelList.Add(hotelName, hotel);
        }

        public static void AddHotel(Hotel hotel)
        {
            AddHotel(hotel.Name, hotel.Rates);
        }
    }
}
