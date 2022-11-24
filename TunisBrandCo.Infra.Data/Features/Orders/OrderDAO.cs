using System;
using System.Data.SqlClient;
using TunisBrandCo.Domain.Features.Orders;

namespace TunisBrandCo.Infra.Data.Features.Orders
{
    public class OrderDAO
    {
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;initial catalog=SERRALINHASAEREASDB;uid=sa;pwd=tunico;";

        public void AddOrder(Order newOrder)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"INSERT ORDER VALUES (@PRODUCT_ID, @CLIENT_ID, @PRODUCT_QUANTITY, @TOTAL_PRICE, @ORDER_DATE, @STATUS);";
                    ConvertObjectToSql(newOrder, DoCommand);
                    DoCommand.CommandText = sql;
                    DoCommand.ExecuteNonQuery();
                }
            }
        }

        public Order GetOrderById(int ordertId)
        {
            var order = new Order();
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    string sql = @"SELECT * FROM ORDER WHERE ID = @ID";
                    comando.CommandText = sql;
                    comando.Parameters.AddWithValue("@ID", ordertId);
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        order = ConvertSqlToObjetc(reader);
                    };
                    return order;
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"DELETE FROM ORDER WHERE ID = @ID;";
                    DoCommand.Parameters.AddWithValue("@CPF", orderId);
                    DoCommand.CommandText = sql;
                    DoCommand.ExecuteNonQuery();
                }
            }
        }

        internal Order GetStatusById(int Orderid)
        {
            var order = new Order();
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    string sql = @"SELECT STATUS FROM ORDER WHERE ID = @ID";
                    comando.CommandText = sql;
                    comando.Parameters.AddWithValue("@ID", Orderid);
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        order = ConvertSqlToObjetc(reader);
                    };
                    return order;
                }
            }
        }

        //public void UpdateStatus(Order order)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        using (var DoCommand = new SqlCommand())
        //        {
        //            DoCommand.Connection = connection;
        //            string sql = @"UPDATE PRODUCT SET            
        //                                ??
        //                                WHERE ID = @ID;";
        //            DoCommand.Parameters.AddWithValue("@ID", order.Id);
        //            ConvertObjectToSql(order, DoCommand);
        //            DoCommand.CommandText = sql;
        //            DoCommand.ExecuteNonQuery();
        //        }
        //    }

        //    ID INT IDENTITY(1,1) NOT NULL,
        //PRODUCT_ID INT NOT NULL,
        //CLIENT_ID VARCHAR(11) NULL,
        //PRODUCT_QUANTITY INT NOT NULL,
        //TOTAL_PRICE DECIMAL(10,2) NOT NULL,
        //ORDER_DATE DATETIME NOT NULL,
        //STATUS BIT NOT NULL,
        //CONSTRAINT PK_ORDER PRIMARY KEY(ID),
        //CONSTRAINT FK_PRODUCT FOREIGN KEY(PRODUCT_ID) REFERENCES PRODUCT(ID)

        private Order ConvertSqlToObjetc(SqlDataReader reader)
        {
            Order order = new Order();
            order.Id = Convert.ToInt32(reader["ID"].ToString());
            order.Product.Id = Convert.ToInt32(reader["PRODUCT_ID"].ToString());
            order.Client.Id = Convert.ToInt32(reader["CLIENT_ID"].ToString());
            order.ProductQuantity = Convert.ToInt32(reader["PRODUCT_QUANTITY"].ToString());
            order.TotalPrice = Convert.ToDecimal(reader["TOTAL_PRICE"].ToString());
            order.OrderDate = Convert.ToDateTime(reader["ORDER_DATE"].ToString());
            order.Status = Convert.ToInt32(reader["STATUS"].ToString());

            return order;
        }

        private void ConvertObjectToSql(Order order, SqlCommand doCommand)
        {
            doCommand.Parameters.AddWithValue("@PRODUCT_ID", order.Product.Id);
            doCommand.Parameters.AddWithValue("@CLIENT_ID", order.Client.Id);
            doCommand.Parameters.AddWithValue("@PRODUCT_QUANTITY", order.ProductQuantity);
            doCommand.Parameters.AddWithValue("@TOTAL_PRICE", order.TotalPrice);
            doCommand.Parameters.AddWithValue("@ORDER_DATE", order.OrderDate);
            doCommand.Parameters.AddWithValue("@STATUS", order.Status);
        }

    }
}
