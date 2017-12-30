using AccountingSystem.Contexts.Interfaces;
using System.Data.SqlClient;
using System.Data;
using AccountingSystem.Models;
using System.Collections.Generic;
using System;
using System.Configuration;
using AccountingSystem.Mappers;

namespace AccountingSystem.Contexts
{
    public class DbContext : IDbContext
    {
        private const string ClientConst = "GetClient";
        private const string ClientsConst = "GetClients";
        private const string FilteredClientsConst = "GetFilteredClients";
        private const string TotalAmountConst = "GetTotalAmount";

        private string _connectionString;

        public DbContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }

        public IEnumerable<Client> GetClients(string filter = null)
        {
            SqlCommand command = null;

            if (!string.IsNullOrEmpty(filter))
            {
                var sqlParameters = new[] { new SqlParameter("@filter", filter) };
                command = GetCommand(FilteredClientsConst, sqlParameters);
            }
            else
            {
                command = GetCommand(ClientsConst);
            }

            var clients = new List<Client>();
            using (var connection = command.Connection)
            {
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var client = Mapper.MapToClient(reader);
                    clients.Add(client);
                }
            }

            return clients;
        }

        public Client GetClient(int id)
        {
            var command = GetCommand(ClientConst);
            Client client = null;
            var orders = new List<Order>();

            using (var connection = command.Connection)
            {
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (client == null)
                    {
                        client = Mapper.MapToClient(reader);
                    }

                    orders.Add(Mapper.MapToOrder(reader));
                }
            }

            client.SetOrders(orders);
            return client;
        }

        public decimal GetTotalAmount(int id)
        {
            decimal totalAmount;
            var command = GetCommand(TotalAmountConst);

            using (var connection = command.Connection)
            {
                connection.Open();

                var result = command.ExecuteScalar();
                totalAmount = Convert.ToDecimal(result);
            }

            return totalAmount;
        }

        private SqlCommand GetCommand(string commandText, SqlParameter[] parameters = null)
        {
            var command = new SqlCommand()
            {
                Connection = new SqlConnection(_connectionString),
                CommandText = commandText,
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return command;
        }
    }
}