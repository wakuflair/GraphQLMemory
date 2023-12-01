using GraphQL.Types;

namespace GraphQLMemory;

public class MySchema : Schema
{
    public MySchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<MyQuery>();
    }
}