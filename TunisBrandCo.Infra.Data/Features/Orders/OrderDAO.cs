using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TunisBrandCo.Domain.Features.Orders;

namespace TunisBrandCo.Infra.Data.Features.Orders
{
    public class OrderDAO
    {
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;initial catalog=TUNISBRANDCO_DB;uid=sa;pwd=tunico;";

        public void AddOrder(Order newOrder)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"INSERT INTO ORDERS (PRODUCT_ID, CLIENT_ID, CLIENT_NAME, PRODUCT_QUANTITY, TOTAL_PRICE, ORDER_DATE) VALUES (@PRODUCT_ID, @CLIENT_ID, @CLIENT_NAME, @PRODUCT_QUANTITY, @TOTAL_PRICE, @ORDER_DATE);";
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
                    string sql = @"SELECT * FROM ORDERS WHERE ID = @ID";
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
                    string sql = @"DELETE FROM ORDERS WHERE ID = @ID;";
                    DoCommand.Parameters.AddWithValue("@ID", orderId);
                    DoCommand.CommandText = sql;
                    DoCommand.ExecuteNonQuery();
                }
            }
        }

        public Order GetStatusById(int Orderid)
        {
            var order = new Order();
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    string sql = @"SELECT STATUS FROM ORDERS WHERE ID = @ID";
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

        public List<Order> GetAllOrders()
        {
            var orderList = new List<Order>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"SELECT * FROM ORDERS";
                    DoCommand.CommandText = sql;
                    SqlDataReader reader = DoCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Order wanterOrder = ConvertSqlToObjetc(reader);
                        orderList.Add(wanterOrder);
                    }
                }
            }
            return orderList;
        }

        public void UpdateStatus(int orderId, int status)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"UPDATE ORDERS SET            
                                        ORDER_STATUS = @ORDER_STATUS
                                        WHERE ID = @ID;";
                    DoCommand.Parameters.AddWithValue("@ID", orderId);
                    DoCommand.Parameters.AddWithValue("@ORDER_STATUS", status);
                    DoCommand.CommandText = sql;
                    DoCommand.ExecuteNonQuery();
                }
            }
        }

            private Order ConvertSqlToObjetc(SqlDataReader reader)
            {
                Order order = new Order();

                order.Id = Convert.ToInt32(reader["ID"].ToString());
                order.ClientName = reader["CLIENT_NAME"].ToString();
                order.ProductQuantity = Convert.ToInt32(reader["PRODUCT_QUANTITY"].ToString());
                order.TotalPrice = Convert.ToDecimal(reader["TOTAL_PRICE"].ToString());
                order.OrderDate = Convert.ToDateTime(reader["ORDER_DATE"].ToString());
                order.Status = Convert.ToInt32(reader["ORDER_STATUS"].ToString());
                return order;
            }

            private void ConvertObjectToSql(Order order, SqlCommand doCommand)
            {
                doCommand.Parameters.AddWithValue("@PRODUCT_ID", order.Product.Id);
                doCommand.Parameters.AddWithValue("@CLIENT_ID", order.Client.Id);
                 doCommand.Parameters.AddWithValue("@CLIENT_NAME", order.ClientName);
                doCommand.Parameters.AddWithValue("@PRODUCT_QUANTITY", order.ProductQuantity);
                doCommand.Parameters.AddWithValue("@TOTAL_PRICE", order.TotalPrice);
                doCommand.Parameters.AddWithValue("@ORDER_DATE", order.OrderDate);
            }


        }
    }
