using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class StartHotelReservationSystem
    {
        public static void Start()
        {
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            Console.WriteLine(reservationSystem.FindHotel("11Sept","12Sept"));
        }
    }
}
