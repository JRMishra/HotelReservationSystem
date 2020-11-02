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
                throw new HotelReservationException(HotelReservationException.ExceptionType.HOTEL_ALREADY_EXISTS, 
                                                     "This hotel already exist");
        }

        /// <summary>
        /// Take hotel name and weekday and weekend rates, if eligible, add to hotel reservation system
        /// </summary>
        public static void AddHotel(string hotelName, double weekdayRate, double weekendRate)
        {
            Hotel hotel = new Hotel(hotelName, weekdayRate, weekendRate);
            if (IsEligible(hotel))
                hotelList.Add(hotel.Name, hotel);
            else
                throw new HotelReservationException(HotelReservationException.ExceptionType.HOTEL_ALREADY_EXISTS,
                                                    "This hotel already exist");
        }

        /// <summary>
        /// Take hotel name, rating and weekday and weekend rates, if eligible, add to hotel reservation system
        /// </summary>
        public static void AddHotel(string hotelName, double weekdayRate, double weekendRate, int rating)
        {
            Hotel hotel = new Hotel(hotelName, weekdayRate, weekendRate,rating);
            if (IsEligible(hotel))
                hotelList.Add(hotel.Name, hotel);
            else
                throw new HotelReservationException(HotelReservationException.ExceptionType.HOTEL_ALREADY_EXISTS,
                                                    "This hotel already exist");
        }

        /// <summary>
        /// Take name, rating and weekday and weekend rates for normal and special customers, 
        /// if eligible, add to hotel reservation system
        /// </summary>
        public static void AddHotel(string hotelName, double weekdayRate, double specialWeekdayRate, double weekendRate, double specialWeekendRate, int rating)
        {
            Hotel hotel = new Hotel(hotelName, weekdayRate, specialWeekdayRate, weekendRate, specialWeekendRate, rating);
            if (IsEligible(hotel))
                hotelList.Add(hotel.Name, hotel);
            else
                throw new HotelReservationException(HotelReservationException.ExceptionType.HOTEL_ALREADY_EXISTS,
                                                    "This hotel already exist");
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
        /// Add weekend rate for the hotel separately
        /// </summary>
        /// <param name="hotelName">Name of the hotel</param>
        /// <param name="weekendRate">Weekend hotel rate to add</param>
        public static void AddWeekendRate(string hotelName, double weekendRate)
        {
            FilterWrongHotelName(hotelName); 
            Hotel hotel = new Hotel(hotelList[hotelName].Name, hotelList[hotelName].WeekdayRates, weekendRate);
            IsEligible(hotel);
            hotelList[hotelName] = hotel;
        }

        /// <summary>
        /// Add rating to an existing hotel in system
        /// </summary>
        /// <param name="hotelName">Hotel name</param>
        /// <param name="rating">rating value</param>
        public static void AddRating(string hotelName, int rating)
        {
            FilterWrongHotelName(hotelName);
            Hotel hotel = new Hotel(hotelList[hotelName].Name, hotelList[hotelName].WeekdayRates, 
                                    hotelList[hotelName].WeekendRates, rating );
            IsEligible(hotel);
            hotelList[hotelName] = hotel;
        }

        /// <summary>
        /// Add special rates for weekdays and weekends
        /// </summary>
        public static void AddSpecialRates(string hotelName, double specialWeekdayRate, double specialWeekendRate)
        {
            FilterWrongHotelName(hotelName);
            Hotel hotel = new Hotel(hotelList[hotelName].Name, hotelList[hotelName].WeekdayRates, specialWeekdayRate, hotelList[hotelName].WeekendRates, specialWeekendRate, hotelList[hotelName].Rating );
            IsEligible(hotel);
            hotelList[hotelName] = hotel;
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

            if (hotel.WeekdayRates == 0.0 || hotel.WeekendRates==0.0 || hotel.SpecialNormalRate==0.0 || hotel.SpecialWeekendRate==0.0)
                throw new HotelReservationException(HotelReservationException.ExceptionType.ZERO_HOTEL_RATE, "Hotel rate can not be zero");

            if(hotel.Rating<0)
                throw new HotelReservationException(HotelReservationException.ExceptionType.NEGATIVE_RATING, "Rating can not be negative");

            if (hotel.Rating > 5)
                throw new HotelReservationException(HotelReservationException.ExceptionType.RATING_OUTOF_BOUND, "Rating can not exceed 5");

            if (!hotelList.ContainsKey(hotel.Name))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Throws custom exception if hotel name is null or does not exist
        /// </summary>
        private static void FilterWrongHotelName(string hotelName)
        {
            if (hotelName == null)
                throw new HotelReservationException(HotelReservationException.ExceptionType.NULL_HOTEL_NAME, "Hotel name can not be null");

            if (!hotelList.ContainsKey(hotelName))
                throw new HotelReservationException(HotelReservationException.ExceptionType.HOTEL_DONOT_EXIST, "Hotel do not exist");
        }
    }
}
