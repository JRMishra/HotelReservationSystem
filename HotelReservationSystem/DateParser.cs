using System;
using System.Collections.Generic;

namespace HotelReservationSystem
{
    public class DateParser
    {
        static readonly Dictionary<string, string> monthlyDays = new Dictionary<string, string>()
        {
            ["Jan"] = "01",
            ["Feb"] = "02",
            ["Mar"] = "03",
            ["Apr"] = "04",
            ["May"] = "05",
            ["Jun"] = "06",
            ["Jul"] = "07",
            ["Aug"] = "08",
            ["Sep"] = "09",
            ["Oct"] = "10",
            ["Nov"] = "11",
            ["Dec"] = "12",
        };

        static readonly Dictionary<int, int> daysInEveryMonth = new Dictionary<int, int>()
        {
            [1] = 31,
            [2] = 28,
            [3] = 31,
            [4] = 30,
            [5] = 31,
            [6] = 30,
            [7] = 31,
            [8] = 31,
            [9] = 30,
            [10] = 31,
            [11] = 30,
            [12] = 31,
        };

        /// <summary>
        /// Convert a date as string to DateTime value
        /// </summary>
        /// <param name="dateValue"></param>
        /// <returns></returns>
        public static DateTime ConvertToDate(string dateValue)
        {
            string date = dateValue.Substring(0, 2);
            int dateNum;
            bool isNum = Int32.TryParse(date, out dateNum);
            if (!isNum)
                throw new HotelReservationException(HotelReservationException.ExceptionType.WRONG_DATE_FORMAT, "Wrong date format");

            string monthNum = dateValue.Substring(2, 3);
            if (!monthlyDays.ContainsKey(monthNum))
                throw new HotelReservationException(HotelReservationException.ExceptionType.WRONG_MONTH_VALUE, "Incorrect month value");

            string month = monthlyDays[monthNum];
            if (Convert.ToInt32(date) <= 0 || Convert.ToInt32(date) > daysInEveryMonth[Convert.ToInt32(month)])
                throw new HotelReservationException(HotelReservationException.ExceptionType.WRONG_DATE_VALUE, "Incorrect date value");

            string year = dateValue.Substring(dateValue.Length - 4); ;
            int yearNum;
            bool isYear = Int32.TryParse(year, out yearNum);
            if (!isYear)
                throw new HotelReservationException(HotelReservationException.ExceptionType.WRONG_YEAR_VALUE, "Incorrect year value");
            
            string formatedDate = date + "/" + month + "/" + year;
            DateTime dateTime;
            try
            {
                dateTime = Convert.ToDateTime(formatedDate);
            }
            catch (Exception)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.WRONG_DATE_FORMAT, "Wrong date format");
            }
            return dateTime;
        }

        /// <summary>
        /// Given start and end date, should return duration in days
        /// </summary>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <returns>if end is before start it will return -1, else the duration in days</returns>
        public static int FindDuration(DateTime start, DateTime end)
        {
            int duration=0;
            if (DateTime.Compare(start,end)>0)
                return -1;
            if (start.Year < end.Year)
            {
                duration+= (end.Year-start.Year-1)*365;
                duration += daysInEveryMonth[start.Month] - start.Day + 1;
                for (int i = start.Month + 1; i <= 12; i++)
                {
                    duration += daysInEveryMonth[i];
                }
                start = new DateTime(end.Year,01,01);
            }
            if(start.Month<end.Month)
            {
                duration += daysInEveryMonth[start.Month] - start.Day + 1;
                for (int i = start.Month +1; i < end.Month; i++)
                {
                    duration += daysInEveryMonth[i];
                }

                duration += end.Day;
            }
            else
            {
                duration += end.Day - start.Day + 1;
            }
           return duration;
        }

        /// <summary>
        /// Count number of weekends present inclusively between two specified dates
        /// </summary>
        /// <param name="start">starting date</param>
        /// <param name="end">ending date</param>
        /// <returns>count of weekends</returns>
        public static int WeekendCount(DateTime start, DateTime end)
        {
            DayOfWeek startDay = start.DayOfWeek;
            DayOfWeek endDay = end.DayOfWeek;
            
            int count = 0;
            count += 2*( (end.Day-start.Day+1)/ 7);
            int remaining = (end.Day - start.Day+1) % 7;
            if ((int)startDay == 0)
                count += (remaining == 1) ? 1 : 2;
            else if ((int)startDay == 6)
                count += (remaining == 1) ? 1 : 2;
            else
            {
                int c = ((int)startDay + remaining-1);
                if (c < 6)
                    count += 0;
                else if (c == 6)
                    count += 1;
                else
                    count += 2;
            }
            return count;
        }
    }
}