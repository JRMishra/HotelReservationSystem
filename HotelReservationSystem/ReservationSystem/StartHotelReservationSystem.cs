﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

namespace HotelReservationSystem
{
    public class StartHotelReservationSystem
    {
        public static void Start()
        {
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            bool cont = true;
            do
            {
                Console.WriteLine("1. Add Hotel\n" +
                    "2. Reserve hotel\n" +
                    "0. Exit");
                string userChoice = Console.ReadLine();
                switch(userChoice)
                {
                    case "1":
                        Console.WriteLine("Only Admin can add new hotel to the system\n");
                        break;
                    case "2":
                        TakeUserInputToReserveHotel(reservationSystem);
                        break;
                    case "0":
                        cont = false;
                        Console.WriteLine("Thanks for using Hotel Reservation System");
                        break;
                    default:
                        Console.WriteLine("Wrong Value Entered");
                        break;
                }
            } while (cont);
        }

        /// <summary>
        /// Take start date and end date as user input and find cheapest best rated hotel details
        /// </summary>
        private static void TakeUserInputToReserveHotel(ReservationSystemBuilder reservationSystem)
        {
            Console.WriteLine("Enter\n");
             
            Console.Write("Starting Date : ");
            string startDate = Console.ReadLine();
            startDate = String.Concat(startDate.Where(c => !Char.IsWhiteSpace(c)));
            Console.Write("EndDate Date : ");
            string endDate = Console.ReadLine();
            endDate = String.Concat(endDate.Where(c => !Char.IsWhiteSpace(c)));
            Console.WriteLine(startDate+" "+endDate);

            string sysResponse = reservationSystem.FindHotel(startDate,endDate);
            Console.WriteLine(sysResponse);
            Console.WriteLine("Enter 'Y' for Confirmation, 'N' for Cancelation ");
            if (Console.ReadLine().ToUpper() == "Y")
                Console.WriteLine("Reservation Successfull");
            else
                Console.WriteLine("Reservation Cancelled");
        }
    }
}
