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
        int _rating;

        public Hotel(string name, double rates)
        {
            _name = name;
            _rates = rates;
            _weekendrates = rates;
            _rating = 0;
        }

        public Hotel(string name, double rates, double weekendrates) : this(name, rates)
        {
            _weekendrates = weekendrates;
        }

        public Hotel(string name, double rates, double weekendrates, int rating) 
        {
            _name = name;
            _rates = rates;
            _weekendrates = weekendrates;
            _rating = rating;
        }

        public string Name { get => _name; }
        public double WeekdayRates { get => _rates; }
        public double WeekendRates { get => _weekendrates; }
        public int Rating { get => _rating; }
    }
}
