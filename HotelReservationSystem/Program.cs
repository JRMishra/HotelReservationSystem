using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System");
            Console.WriteLine("====================================");

            LogDetails logger = new LogDetails();
            bool status = true;
            while(status)
            {
                try
                {
                    status = false;
                    StartHotelReservationSystem.Start();
                }
                catch (HotelReservationException e)
                {
                    status = true;
                    logger.LogCustomError(e.Message);
                    Console.WriteLine("Some error occured!!\nRestarting...");
                }
                catch (Exception e)
                {
                    status = true;
                    logger.LogUnknownError(e.Message);
                    Console.WriteLine("Some error occured!!\nRestarting...");
                }
            } 
        }
    }
}
