using GraphQL;
using GraphQL.Types;
using GraphQLMemory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<MyQuery>();
builder.Services.AddSingleton<ISchema, MySchema>();
builder.Services
    .AddGraphQL(b => b.AddSystemTextJson());

var app = builder.Build();

app.UseGraphQL<ISchema>();
app.UseGraphQLAltair();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();