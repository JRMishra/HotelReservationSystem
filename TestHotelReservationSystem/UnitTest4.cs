using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HotelReservationSystem;

namespace TestHotelReservationSystem
{
    [TestClass]
    public class UnitTest4
    {
        /// <summary>
        /// Given a range of date (inclusive), it should give count of weekends
        /// </summary>
        [TestMethod]
        public void GivenRangeOfDate_ShouldReturnWeekendCount()
        {
            //Arrange
            int expectedCount = 5;
            //Act
            int actualCount = DateParser.WeekendCount(new DateTime(2020, 11, 08), new DateTime(2020, 11, 22));
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Given start and end date, considering weekday and weekend rates
        /// it should retuen a string with details of cheapest hotel
        /// </summary>
        [TestMethod]
        public void GivenStartAndEndDate_ShouldReturnAboutCheapestHotel()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            //Act
            string hotelDetail = reservationSystem.FindHotel("06Nov2020", "08Nov2020");
            //Assert
            Assert.AreEqual(hotelDetail, "Bridgewood, Total Rates: $250");
        }
    }
}
