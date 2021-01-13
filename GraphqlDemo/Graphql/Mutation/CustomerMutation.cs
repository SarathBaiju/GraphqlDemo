using GraphQL;
using GraphQL.Types;
using GraphqlDemo.DataAccess;
using GraphqlDemo.Graphql.Types;
using GraphqlDemo.Models;

namespace GraphqlDemo.Graphql.Mutation
{
    public class CustomerMutation : ObjectGraphType
    {
        public CustomerMutation()
        {
            Name = "CustomerMutation";
            Field<CustomerGraphType>("CreateCustomer", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CustomerInputGraphType>>
            { 
                Name = "CustomerInput"
            }), resolve: context => {
                var customer = context.GetArgument<Customer>("CustomerInput");
                InsertIntoCustomerRepository(customer);
                return customer;
            });
        }
        public int InsertIntoCustomerRepository(Customer customer)
        {
            var customerRepository = new CustomerRepository();
            try
            {
                return customerRepository.InsertIntoCustomers(customer);
                
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }
    }
}
