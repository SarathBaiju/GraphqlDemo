using GraphQL;
using GraphQL.Types;
using GraphqlDemo.DataAccess;
using GraphqlDemo.Graphql.Types;
using GraphqlDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphqlDemo.Graphql.Query
{
    public class CustomerQuery : ObjectGraphType
    {
        public CustomerQuery()
        {
            Name = "CustomerQuery";
            Field<ListGraphType<CustomerGraphType>>("customers", "to get list of customer", resolve: context => GetDummyCustomer());
            Field<CustomerGraphType>("customer","to get a single customer by id", new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "Id",
                        Description = "Customer Id"
                    }
                ), resolve: context => GetDummyCustomer().Single(s => s.Id == context.Arguments["id"].GetPropertyValue<int>()));
        }
        private List<Customer> GetDummyCustomer()
        {
            var customerRepository = new CustomerRepository();
            return customerRepository.GetCustomers();
        }
    }

}
