using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HotelReservationSystem;

namespace TestHotelReservationSystem
{
    [TestClass]
    public class UnitTest6
    {
        [TestMethod]
        public void GivenDateRange_ShouldReturnCheapestBestRatedHotel()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            //Act
            string hotelDetail = reservationSystem.FindHotel("13Nov2020", "14Nov2020");
            //Assert
            Assert.AreEqual(hotelDetail, "Bridgewood, Total Rates: $200");
        }
    }
}
