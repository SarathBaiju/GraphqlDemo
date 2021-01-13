using GraphQL.Types;

namespace GraphqlDemo.Graphql.Types
{
    public class CustomerInputGraphType : InputObjectGraphType
    {
        public CustomerInputGraphType()
        {
            Name = "CustomerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("age");
        }
    }
}
