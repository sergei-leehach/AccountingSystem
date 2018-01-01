using AccountingSystem.Models;
using System;
using System.Data.SqlClient;

namespace AccountingSystem.Mappers
{
    public static class Mapper
    {
        public static Client MapToClient(SqlDataReader reader)
        {
            var client = new Client
            {
                Id = Convert.ToInt32(reader["Id"]),
                FullName = reader["FullName"].ToString(),
            };

            return client;
        }

        public static Client MapToClientCard(SqlDataReader reader)
        {
            var client = new Client
            {
                Id = Convert.ToInt32(reader["Id"]),
                FullName = reader["FullName"].ToString(),
                BDay = Convert.ToDateTime(reader["BDay"]),
                PhoneNumber = reader["PhoneNumber"].ToString()
            };

            return client;
        }

        public static Order MapToOrder(SqlDataReader reader)
        {
            var order = new Order
            {
                Id = Convert.ToInt32(reader["OrderId"]),
                ClientId = Convert.ToInt32(reader["Id"]),
                Number = Convert.ToInt32(reader["Number"]),
                Date = Convert.ToDateTime(reader["Date"]),
                Amount = Convert.ToDecimal(reader["Amount"])
            };

            return order;
        }
    }
}