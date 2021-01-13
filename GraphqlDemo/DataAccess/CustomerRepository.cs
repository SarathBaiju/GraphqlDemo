using Dapper;
using GraphqlDemo.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GraphqlDemo.DataAccess
{
    public class CustomerRepository
    {
        public List<Customer> GetCustomers()
        {
            string sql = "select * from Customer";

            try
            {
                using (var connection = new SqlConnection(@"Data Source =(LocalDb)\MSSQLLOCALDB;Database=Customer_Db"))
                {
                    return connection.Query<Customer>(sql).ToList();
                }

            }
            catch (System.Exception ex)
            {

                throw;
            }
            return new List<Customer>();
        }

    }
}
