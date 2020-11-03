using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using HotelReservationSystem;
using System.Linq;

namespace TestHotelReservationSystem
{
    [TestClass]
    public class UnitTest10
    {
        [TestMethod]
        public void GivenCustomerTypeAsReward_ShouldUseSpecialRates()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            //Act
            string hotelDetail = reservationSystem.FindHotel("13Nov2020", "14Nov2020", "Reward");
            //Assert
            Assert.AreEqual(hotelDetail, "Ridgewood, Total Rates: $140");
        }
    }
}
