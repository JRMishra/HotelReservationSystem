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
            Console.WriteLine(reservationSystem.FindHotel("11Nov2020","12Nov2020"));
        }
    }
}
