using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HotelReservationSystem;

namespace TestHotelReservationSystem
{
    [TestClass]
    public class UnitTest3
    {
        /// <summary>
        /// Testing ability to add weekend rates to an existing hotel
        /// </summary>
        [TestMethod]
        public void GivenWeekendRate_ShouldAddToHotelProperties()
        {
            //Arrange
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 120);
            double expectedWeekendRate = 80;
            //Act
            MiamiHotels.AddWeekendRate("Lakewood", expectedWeekendRate);
            //Assert
            Assert.AreEqual(expectedWeekendRate, MiamiHotels.HotelList["Lakewood"].WeekendRates);
        }

        /// <summary>
        /// In case we are trying to add 0 as weekend rate,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenZeroAsWeekendRate_ShouldThrowCustomException()
        {
            //Arrange
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 120);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.AddWeekendRate("Lakewood", 0);
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual("Hotel rate can not be zero", exception.Message);
        }

        /// <summary>
        /// In case we are passing null as hotel name,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenHotelNameAsNull_ShouldThrowCustomException()
        {
            //Arrange
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 120);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.AddWeekendRate(null,80);
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual("Hotel name can not be null", exception.Message);
        }

        /// <summary>
        /// In case we are passing name of hotel, that doesn't exist in system
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenWrongHotelName_ShouldThrowCustomException()
        {
            //Arrange
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 120);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.AddWeekendRate("lakewood", 80);    //testing typoerror
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual("Hotel do not exist", exception.Message);

        }
    }
}
