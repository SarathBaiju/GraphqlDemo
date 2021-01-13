using GraphQL.Types;
using GraphqlDemo.Models;

namespace GraphqlDemo.Graphql.Types
{
    public class CustomerGraphType : ObjectGraphType<Customer>
    {
        public CustomerGraphType()
        {
            Name = "Customer";
            Field(c => c.Id);
            Field(c => c.Name);
            Field(c => c.Age);
        }
    }
}
