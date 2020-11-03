using System;

namespace HotelReservationSystem
{
    interface IReservationSystemBuilder
    {
        public string FindHotel(string start, string end, string customerType);
    }
}
