using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunisBrandCo.Domain.Features.Products;
using System.Data.SqlClient;
using System.Data;
using System.Security.Principal;


namespace TunisBrandCo.Infra.Data.Features.Products
{
    public class ProductDAO
    {
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;initial catalog=SERRALINHASAEREASDB;uid=sa;pwd=tunico;";

        public void AddProduct(Product newProduct)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"INSERT PRODUCT VALUES (@PRICE, @EXPIRYDATE, @PRODUCT_DESCRIPTION, @STOCK_QUANTITY, @ISACTIVE);";
                    ConvertObjectToSql(newProduct, DoCommand);
                    DoCommand.CommandText = sql;
                    DoCommand.ExecuteNonQuery();
                }
            }
        }
        
        public void UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"UPDATE PRODUCT SET            
                                        PRICE = @PRICE,
                                        EXPIRYDATE = @EXPIRYDATE,
                                        PRODUCT_DESCRIPTION = @PRODUCT_DESCRIPTION,
                                        STOCK_QUANTITY = @STOCK_QUANTITY,
                                        ISACTIVE = @ISACTIVE,
                                        WHERE ID = @ID;";
                    DoCommand.Parameters.AddWithValue("@ID", product.Id);
                    ConvertObjectToSql(product, DoCommand);
                    DoCommand.CommandText = sql;
                    DoCommand.ExecuteNonQuery();
                }
            }
        }

        //public void UpdateStatus(Product product)
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
        //            DoCommand.Parameters.AddWithValue("@ID", product.Id);
        //            ConvertObjectToSql(product, DoCommand);
        //            DoCommand.CommandText = sql;
        //            DoCommand.ExecuteNonQuery();
        //        }
        //    }
        //}

        public void AddStock(Product product, int quantity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var DoCommand = new SqlCommand())
                {
                    DoCommand.Connection = connection;
                    string sql = @"UPDATE PRODUCT SET            
                                        STOCK_QUANTITY = @STOCK_QUANTITY,
                                        WHERE ID = @ID;";
                    DoCommand.Parameters.AddWithValue("@ID", product.Id);
                    DoCommand.Parameters.AddWithValue("@STOCK_QUANTITY", quantity);
                    ConvertObjectToSql(product, DoCommand);
                    DoCommand.CommandText = sql;
                    DoCommand.ExecuteNonQuery();
                }
            }
        }

        private Product ConvertSqlToObjetc(SqlDataReader reader)
        {
            Product product = new Product();
            product.Id = Convert.ToInt32(reader["ID"].ToString());
            product.Price = Convert.ToDecimal(reader["PRICE"].ToString());
            product.ExpiryDate = Convert.ToDateTime(reader["EXPIRYDATE"].ToString());
            product.Description = reader["PRODUCT_DESCRIPTION"].ToString();
            product.StockQuantity = Convert.ToInt32(reader["STOCK_QUANTITY"].ToString());
            product.IsActive = Convert.ToBoolean(reader["ISACTIVE"].ToString());

            return product;
        }

        private void ConvertObjectToSql(Product product, SqlCommand doCommand)
        {
            doCommand.Parameters.AddWithValue("@PRICE", product.Price);
            doCommand.Parameters.AddWithValue("@EXPIRYDATE", product.ExpiryDate);
            doCommand.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", product.Description);
            doCommand.Parameters.AddWithValue("@STOCK_QUANTITY", product.StockQuantity);
            doCommand.Parameters.AddWithValue("@ISACTIVE", product.IsActive);
        }
    }
}
