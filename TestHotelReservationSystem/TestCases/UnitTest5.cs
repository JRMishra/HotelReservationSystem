using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HotelReservationSystem;

namespace TestHotelReservationSystem
{
    [TestClass]
    public class UnitTest5
    {
        /// <summary>
        /// Testing ability to add weekend rates to an existing hotel
        /// </summary>
        [TestMethod]
        public void GivenHotelRating_ShouldAddToHotelProperties()
        {
            //Arrange
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 120, 80);
            int expectedRating = 3;
            //Act
            MiamiHotels.AddRating("Lakewood", expectedRating);
            //Assert
            Assert.AreEqual(expectedRating, MiamiHotels.HotelList["Lakewood"].Rating);
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
            MiamiHotels.AddHotel("Lakewood", 120,90);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.AddRating(null, 3);
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
            MiamiHotels.AddHotel("Lakewood", 120,80);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.AddRating("lakewood", 3);    //testing typoerror
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual("Hotel do not exist", exception.Message);

        }

        /// <summary>
        /// In case we are passing negative hotel rating,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenNegativeHotelRating_ShouldThrowCustomException()
        {
            //Arrange
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 120,80);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.AddRating("Lakewood", -3);
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual("Rating can not be negative", exception.Message);

        }

        /// <summary>
        /// In case we are passing negative hotel rating,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenHotelRatingAboveFive_ShouldThrowCustomException()
        {
            //Arrange
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel("Lakewood", 120, 80);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.AddRating("Lakewood", 7);
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual("Rating can not exceed 5", exception.Message);

        }
    }
}
