using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        string _name;
        double _rates;

        public Hotel(string name, double rates)
        {
            _name = name;
            _rates = rates;
        }

        public string Name { get => _name; }
        public double Rates { get => _rates; }
    }
}
