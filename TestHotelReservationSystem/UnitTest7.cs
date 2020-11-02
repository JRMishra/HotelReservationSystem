using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HotelReservationSystem;

namespace TestHotelReservationSystem
{
    [TestClass]
    public class UnitTest7
    {
        /// <summary>
        /// For the given date range, it should give details of hotel with best rating
        /// </summary>
        [TestMethod]
        public void GivenDateRange_ShouldReturn_BestRatedHotelDetails()
        {
            //Arrange
            ReservationSystemBuilder reservationSystem = new ReservationSystemBuilder();
            //Act
            string hotelDetail = reservationSystem.FindBestRatedHotel("13Nov2020", "14Nov2020");
            //Assert
            Assert.AreEqual(hotelDetail, "Ridgewood, Total Rates: $370");
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
                string hotelDetail = reservationSystem.FindBestRatedHotel("SevenNov2020", "NineNov2020");
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
                string hotelDetail = reservationSystem.FindBestRatedHotel("00Nov2020", "05Nov2020");
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
                string hotelDetail = reservationSystem.FindBestRatedHotel("05Navember2020", "05November2020");
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
                string hotelDetail = reservationSystem.FindBestRatedHotel("05Nov2020", "15Nov202o");
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
                string hotelDetail = reservationSystem.FindBestRatedHotel("05Nov2020", "03Nov2020");
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
