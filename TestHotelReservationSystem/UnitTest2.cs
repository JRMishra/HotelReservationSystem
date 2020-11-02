using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using HotelReservationSystem;

namespace TestHotelReservationSystem
{
    [TestClass]
    public class UnitTest2
    {
        /// <summary>
        /// When called ReservationSystemBuilder class
        /// it should add three hotels to Miami Hotel list
        /// </summary>
        [TestMethod]
        public void ReservationSystemBuilder_WhenCalled_ShouldAddThreeHotelsToMiamiHotelList()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem;
            int expected = 3;
            //Act
            reservationSystem = new ReservationSystemBuilder();
            //Assert
            Assert.AreEqual(expected, MiamiHotels.HotelList.Count);
        }

        /// <summary>
        /// Given Duration of stay,
        /// it should return hotel with cheapest total rate
        /// </summary>
        [TestMethod]
        public void GivenDuration_ShouldReturnCheapestHotel()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            //Act
            Hotel hotel = reservationSystem.FindCheapestHotel(2,0);
            //Assert
            Assert.AreEqual(hotel, MiamiHotels.HotelList["Lakewood"]);
        }

        /// <summary>
        /// Given start and end date,
        /// it should retuen a string with details of cheapest hotel
        /// </summary>
        [TestMethod]
        public void GivenStartAndEndDate_ShouldReturnAboutCheapestHotel()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            //Act
            string hotelDetail = reservationSystem.FindHotel("07Sept2020", "09Sept2020");
            //Assert
            Assert.AreEqual(hotelDetail, "Lakewood, Total Rates: $330");
        }

        /// <summary>
        /// If format of any date is incorrect,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenIncorrectDateFormat_ShouldThrowCustomException()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            Exception exception = new Exception();
            //Act
            try
            {
                string hotelDetail = reservationSystem.FindHotel("SevenSept2020", "NineSept2020");
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual(exception.Message, "Wrong date format");
        }

        /// <summary>
        /// If value of any date is wrong,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenWrongDateValue_ShouldThrowCustomException()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            Exception exception = new Exception();
            //Act
            try
            {
                string hotelDetail = reservationSystem.FindHotel("00Sept2020", "05Sept2020");
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual(exception.Message, "Incorrect date value");
        }

        /// <summary>
        /// If value of month is wrong,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenWrongMonthValue_ShouldThrowCustomException()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            Exception exception = new Exception();
            //Act
            try
            {
                string hotelDetail = reservationSystem.FindHotel("05Navember2020", "05November2020");
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual(exception.Message, "Incorrect month value");
        }

        /// <summary>
        /// If value of any year is wrong,
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenWrongYearValue_ShouldThrowCustomException()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            Exception exception = new Exception();
            //Act
            try
            {
                string hotelDetail = reservationSystem.FindHotel("05Nov2020", "15Nov202o");
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual(exception.Message, "Incorrect year value");
        }

        /// <summary>
        /// If end date is before start date
        /// it should throw custom exception with appropriate message
        /// </summary>
        [TestMethod]
        public void GivenEndDateBeforeStartDate_ShouldThrowCustomException()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            Exception exception = new Exception();
            //Act
            try
            {
                string hotelDetail = reservationSystem.FindHotel("05Nov2020", "03Nov2020");
            }
            catch (HotelReservationException e)
            {
                exception = e;
            }
            //Assert
            Assert.AreEqual(exception.Message, "End date can not be before start date");
        }
    }
}
