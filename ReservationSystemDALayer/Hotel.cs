using System.ComponentModel.DataAnnotations;

namespace ReservationSystemDALayer
{
    public class Hotel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double WeekdayRates { get; set; }
        [Required]
        public double WeekendRates { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public double SpecialNormalRate { get; set; }
        [Required]
        public double SpecialWeekendRate { get; set; }
    }
}