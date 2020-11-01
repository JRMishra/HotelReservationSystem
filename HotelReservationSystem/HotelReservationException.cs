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
            WRONG_DATE_VALUE,
            WRONG_MONTH_VALUE,
            WRONG_YEAR_VALUE,
            ENDDATE_BEFORE_STARTDATE,
            HOTEL_DONOT_HOTEL
        }

        ExceptionType type;
        
        public HotelReservationException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
