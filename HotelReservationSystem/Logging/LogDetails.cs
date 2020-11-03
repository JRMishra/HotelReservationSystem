using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    /// <summary>
    /// To login execution details
    /// </summary>
    class LogDetails
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void LogCustomError(string msg)
        {
            logger.Error(" -- CUSTOM ERROR : "+msg);
        }

        public void LogUnknownError(string msg)
        {
            logger.Error(" -- UNKNOWN ERROR : " + msg);
        }
    }
}
