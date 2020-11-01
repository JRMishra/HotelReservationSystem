using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        string _name;
        double _rates;
        double _weekendrates;

        public Hotel(string name, double rates)
        {
            _name = name;
            _rates = rates;
            _weekendrates = rates;
        }

        public Hotel(string name, double rates, double weekendrates) : this(name, rates)
        {
            _weekendrates = weekendrates;
        }

        public string Name { get => _name; }
        public double Rates { get => _rates; }
        public double WeekendRates { get => _weekendrates; } 
    }
}
