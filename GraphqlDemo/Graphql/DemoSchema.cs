using GraphQL.Types;
using GraphQL.Utilities;
using GraphqlDemo.Graphql.Mutation;
using GraphqlDemo.Graphql.Query;
using System;

namespace GraphqlDemo.Graphql
{
    public class DemoSchema : Schema
    {
        public DemoSchema(IServiceProvider provider):base(provider)
        {
            Query = new CustomerQuery();
            Mutation = new CustomerMutation();
        }
    }
}
