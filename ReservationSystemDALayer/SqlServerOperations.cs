using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ReservationSystemDALayer
{
    public class SqlServerOperations
    {
        public static IEnumerable<DataRow> GetAllHotelDetails()
        {
            string connStr = @"Data Source=OCAC\SQK2K20JRM;Initial Catalog=reserve_hotel;Integrated Security=True";
            using(SqlConnection connection = new SqlConnection(connStr))
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Hotels", connection);
                adapter.Fill(dataSet, "Hotels");
                return dataSet.Tables["Hotels"].AsEnumerable();
            }
        }
    }
}
