using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HotelReservationSystem;

namespace TestHotelReservationSystem
{
    [TestClass]
    public class UnitTest9
    {
        /// <summary>
        /// Testing ability to add special weekday and weekend rates to an existing hotel
        /// </summary>
        [TestMethod]
        public void GivenSpecialRates_ShouldAddToHotelProperties()
        {
            //Arrange
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 120, 90,3);
            double expectedWeekdayRate = 80;
            double expectedWeekendRate = 80;
            //Act
            MiamiHotels.AddSpecialRates("Lakewood", expectedWeekdayRate, expectedWeekendRate);
            //Assert
            Assert.AreEqual(expectedWeekdayRate, MiamiHotels.HotelList["Lakewood"].SpecialNormalRate);
            Assert.AreEqual(expectedWeekendRate, MiamiHotels.HotelList["Lakewood"].SpecialWeekendRate);
        }

        /// <summary>
        /// When called ReservationSystemBuilder class
        /// it should add three hotels, with proper details, to Miami Hotel list
        /// </summary>
        [TestMethod]
        public void ReservationSystemBuilder_ShouldAddProperSpecialRate()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem;
            Hotel hotel = new Hotel("Bridgewood", 150, 110, 50, 50, 4);
            //Act
            reservationSystem = new ReservationSystemBuilder();
            //Assert
            Assert.AreEqual(hotel.SpecialNormalRate, MiamiHotels.HotelList["Bridgewood"].SpecialNormalRate);
            Assert.AreEqual(hotel.SpecialWeekendRate, MiamiHotels.HotelList["Bridgewood"].SpecialWeekendRate);
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
            MiamiHotels.AddHotel("Lakewood", 120,90,3);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.AddSpecialRates(null, 80,80);
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
            MiamiHotels.AddHotel("Lakewood", 120,90,3);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.AddSpecialRates("lakewood", 80,80);    //testing typoerror
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual("Hotel do not exist", exception.Message);

        }

        /// <summary>
        /// In case we are trying to add 0 as weekend rate,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenZeroAsSpecialRate_ShouldThrowCustomException()
        { 
            //Arrange
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 120,90,3);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.AddSpecialRates("Lakewood", 0,80);
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual("Hotel rate can not be zero", exception.Message);
        }
    }
}
