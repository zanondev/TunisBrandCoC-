using System;
using System.Data.SqlClient;
using TunisBrandCo.Domain.Features.Clients;

namespace TunisBrandCo.Infra.Data.Features.Clients
{
    public class ClientDAO
    {
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;initial catalog=SERRALINHASAEREASDB;uid=sa;pwd=tunico;";

        public void AddClient(Client newClient)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"INSERT CLIENT VALUES (@CPF, @CLIENT_NAME, @BIRTHDATE, @LOYALTY_POINTS);";
                    ConvertObjectToSql(newClient, DoCommand);
                    DoCommand.CommandText = sql;
                    DoCommand.ExecuteNonQuery(); 
                }
            }
        }

        public void DeleteCliente(int clientId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"DELETE FROM CLIENT WHERE ID = @ID;";
                    DoCommand.Parameters.AddWithValue("@CPF", clientId);
                    DoCommand.CommandText = sql;
                    DoCommand.ExecuteNonQuery();
                }
            }
        }

        public void UpdateClient(Client client)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"UPDATE CLIENT SET            
                                        CPF = @CPF,
                                        CLIENT_NAME = @CLIENT_NAME,
                                        BIRTHDATE = @BIRTHDATE,
                                        LOYALTY_POINTS = @LOYALTY_POINTS,
                                        WHERE ID = @ID;";
                    DoCommand.Parameters.AddWithValue("@ID", client.Id);
                    ConvertObjectToSql(client, DoCommand);
                    DoCommand.CommandText = sql;
                    DoCommand.ExecuteNonQuery();
                }
            }
        }

        private Client ConvertSqlToObjetc(SqlDataReader reader)
        {
            Client client = new Client();
            client.Id = Convert.ToInt32(reader["ID"].ToString());
            client.Cpf = reader["CPF"].ToString();
            client.Name = reader["CLIENT_NAME"].ToString();
            client.BirthDate = Convert.ToDateTime(reader["BIRTHDATE"].ToString());
            client.LoyaltyPoints = Convert.ToDecimal(reader["LOYALTY_POINTS"].ToString());

            return client;
        }

        private void ConvertObjectToSql(Client client, SqlCommand doCommand)
        {
            doCommand.Parameters.AddWithValue("@CPF", client.Cpf);
            doCommand.Parameters.AddWithValue("@CLIENT_NAME", client.Name);
            doCommand.Parameters.AddWithValue("@BIRTHDATE", client.BirthDate);
            doCommand.Parameters.AddWithValue("@LOYALTY_POINTS", client.LoyaltyPoints);
        }
    }
}
