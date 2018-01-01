using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using AccountingSystem.Mappers;
using AccountingSystem.Models;
using AccountingSystem.Contexts.Interfaces;

namespace AccountingSystem.Contexts
{
    public class DbContext : IDbContext
    {
        private const string ClientCardConst = "GetClientCard";
        private const string ClientsConst = "GetClients";
        private const string FilteredClientsConst = "GetFilteredClients";
        private const string TotalAmountConst = "GetTotalAmount";

        private readonly string _connectionString;

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
            var sqlParameters = new[] { new SqlParameter("@id", id) };
            var command = GetCommand(ClientCardConst, sqlParameters);

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
                        client = Mapper.MapToClientCard(reader);
                    }

                    orders.Add(Mapper.MapToOrder(reader));
                }
            }

            client.SetOrders(orders);
            return client;
        }

        public decimal GetTotalAmount(int id)
        {
            SqlParameter resultParameter = new SqlParameter("@TotalAmount", SqlDbType.Decimal)
            {
                Direction = ParameterDirection.ReturnValue,
                Scale = 2,
                Precision = 18
            };

            var sqlParameters = new[] { new SqlParameter("@ClientId", id), resultParameter };
            var command = GetCommand(TotalAmountConst, sqlParameters);

            decimal totalAmount;
            using (var connection = command.Connection)
            {
                connection.Open();

                command.ExecuteNonQuery();
                totalAmount = Convert.ToDecimal(resultParameter.Value);
            }

            return totalAmount;
        }

        private SqlCommand GetCommand(string commandText, SqlParameter[] parameters = null)
        {
            var command = new SqlCommand
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