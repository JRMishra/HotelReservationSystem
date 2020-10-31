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

        /// <summary>
        /// Take hotel name and rate, if eligible, add to hotel reservation system
        /// </summary>
        /// <param name="hotelName">Name of hotel</param>
        /// <param name="dailyRate">Daily Rate of hotel</param>
        public static void AddHotel(string hotelName, double dailyRate)
        {
            Hotel hotel = new Hotel(hotelName, dailyRate);
            if (IsEligible(hotel))
                hotelList.Add(hotel.Name, hotel);
            else
                throw new HotelReservationException(HotelReservationException.ExceptionType.HOTEL_ALREADY_EXISTS, "This hotel already exist");

        }

        /// <summary>
        /// Take a hotel, if eligible, add to hotel reservation system
        /// </summary>
        /// <param name="hotel">hotel to add in reservation system</param>
        public static void AddHotel(Hotel hotel)
        {
            if(IsEligible(hotel))
                hotelList.Add(hotel.Name, hotel);
            else
                throw new HotelReservationException(HotelReservationException.ExceptionType.HOTEL_ALREADY_EXISTS, "This hotel already exist");
        }

        /// <summary>
        /// Check eligibility criteria for hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Returns true if eligible, else false</returns>
        private static bool IsEligible(Hotel hotel)
        {
            if (hotel.Name == null)
                throw new HotelReservationException(HotelReservationException.ExceptionType.NULL_HOTEL_NAME, "Hotel name can not be null");

            if (hotel.Rates == 0.0)
                throw new HotelReservationException(HotelReservationException.ExceptionType.ZERO_HOTEL_RATE, "Hotel rate can not be null");

            if (!hotelList.ContainsKey(hotel.Name))
                return true;
            else
                return false;
        }
    }
}
