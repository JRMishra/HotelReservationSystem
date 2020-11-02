using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        string _name;
        double _rates;
        double _specialNormalRate;
        double _weekendrates;
        double _specialWeekendRate;
        int _rating;

        public Hotel(string name, double rates)
        {
            _name = name;
            _rates = rates;
            _specialNormalRate = rates;
            _weekendrates = rates;
            _specialWeekendRate = rates;
            _rating = 0;
        }

        public Hotel(string name, double rates, double weekendrates) : this(name, rates)
        {
            _weekendrates = weekendrates;
            _specialWeekendRate = weekendrates;
        }

        public Hotel(string name, double rates, double weekendrates, int rating) 
        {
            _name = name;
            _rates = rates;
            _specialNormalRate = rates;
            _weekendrates = rates;
            _specialWeekendRate = rates;
            _rating = rating;
        }

        public Hotel(string name, double normalRates, double specialNormalRate, double weekendRates, double specialWeekendRate, int rating)
        {
            _name = name;
            _rates = normalRates;
            _specialNormalRate = specialNormalRate;
            _weekendrates = weekendRates;
            _specialWeekendRate = specialWeekendRate;
            _rating = rating;
        }

        public string Name { get => _name; }
        public double WeekdayRates { get => _rates; }
        public double WeekendRates { get => _weekendrates; }
        public int Rating { get => _rating; }
        public double SpecialNormalRate { get => _specialNormalRate; }
        public double SpecialWeekendRate { get => _specialWeekendRate; }
    }
}
