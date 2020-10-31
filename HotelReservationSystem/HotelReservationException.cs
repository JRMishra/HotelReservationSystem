using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelReservationException : Exception
    {
        public enum ExceptionType
        {
            HOTEL_ALREADY_EXISTS,
            NULL_HOTEL_NAME,
            ZERO_HOTEL_RATE,
            WRONG_DATE_FORMAT,
            WRONG_DATE_VALUE
        }

        ExceptionType type;
        
        public HotelReservationException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
