using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;
using System;

namespace TestHotelReservationSystem
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Given name and rate of hotel, 
        /// it should create an instance of hotel class with corresponding properties 
        /// </summary>
        [TestMethod]
        public void GivenHotelNameAndRate_ShouldCreateNewHotelObject()
        {
            //Arrange
            Hotel hotel;
            string expectedName = "LakeWood";
            double expectedRate = 90;

            //Act
            hotel = new Hotel(expectedName, expectedRate);

            //Assert
            Assert.AreEqual(expectedName, hotel.Name);
            Assert.AreEqual(expectedRate, hotel.WeekdayRates);
        }

        /// <summary>
        /// Given hotel name and rate, 
        /// it should add it to hotel reservation system
        /// </summary>
        [TestMethod]
        public void GivenNameAndRate_ShouldAddHotelToResvSystem()
        {
            //Arrange
            string expectedName = "LakeWood";
            double expectedRate = 90;

            //Act
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel(expectedName, expectedRate);

            //Assert
            Assert.AreEqual(expectedName, MiamiHotels.HotelList[expectedName].Name);
            Assert.AreEqual(expectedRate, MiamiHotels.HotelList[expectedName].WeekdayRates);
        }

        /// <summary>
        /// Given a proper hotel,
        /// it should add it to hotel reservation system
        /// </summary>
        [TestMethod]
        public void GivenHotel_ShouldAddToReservationSystem()
        {
            //Arrange
            string expectedName = "BridgeWood";
            double expectedRate = 100;
            Hotel hotel = new Hotel(expectedName, expectedRate);

            //Act
            MiamiHotels.HotelList.Clear();
            MiamiHotels.AddHotel(hotel);

            //Assert
            Assert.AreEqual(hotel.GetType(), MiamiHotels.HotelList[expectedName].GetType());
        }

        /// <summary>
        /// Given hotel name as Null,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenNullHotelName_ShouldThrowCustomException()
        {
            //Arrange
            Hotel hotel = new Hotel(null, 100);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.HotelList.Clear();
                MiamiHotels.AddHotel(hotel);
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            catch (Exception e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual(exception.Message, "Hotel name can not be null");
        }

        /// <summary>
        /// Given hotel rate as zero,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenZeroHotelRate_ShouldThrowCustomException()
        {
            //Arrange
            Hotel hotel = new Hotel("RidgeWood", 0);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.HotelList.Clear();
                MiamiHotels.AddHotel(hotel);
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            catch (Exception e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual(exception.Message, "Hotel rate can not be zero");
        }

        /// <summary>
        /// If we try to add a hotel more than once
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenDuplicateHotel_ShouldThrowCustomException()
        {
            //Arrange
            Hotel firstHotel = new Hotel("LakeWood", 100);
            Hotel secondHotel = new Hotel("LakeWood", 120);
            Exception exception = new Exception();
            //Act
            try
            {
                MiamiHotels.HotelList.Clear();
                MiamiHotels.AddHotel(firstHotel);
                MiamiHotels.AddHotel(secondHotel);
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            catch (Exception e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual(exception.Message, "This hotel already exist");
        }
        
    }
}