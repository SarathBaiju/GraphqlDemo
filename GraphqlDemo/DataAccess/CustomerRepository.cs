using Dapper;
using GraphqlDemo.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GraphqlDemo.DataAccess
{
    public class CustomerRepository
    {
        private SqlConnection _sqlConnection = new SqlConnection(@"Data Source =(LocalDb)\MSSQLLOCALDB;Database=Customer_Db");
        public List<Customer> GetCustomers()
        {
            string sql = "select * from Customer";

            try
            {
                return _sqlConnection.Query<Customer>(sql).ToList();
            }
            catch (System.Exception ex)
            {

                throw;
            }
            return new List<Customer>();
        }

        public int InsertIntoCustomers(Customer customer)
        {
            string sql = "insert into Customer values (@name, @age)";
            return _sqlConnection.Execute(sql, param: new { name = customer.Name, age = customer.Age});
        }

    }
}
