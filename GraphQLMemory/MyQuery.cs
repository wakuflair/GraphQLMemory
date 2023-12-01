using GraphQL;
using GraphQL.Types;

namespace GraphQLMemory;

public class MyQuery : ObjectGraphType
{
    public MyQuery()
    {
        Field<ListGraphType<AutoRegisteringObjectGraphType<Person>>, List<Person>>("getPeople")
            .Resolve(Resolve!)
            ;
    }

    private List<Person> Resolve(IResolveFieldContext<object> arg)
    {
        var people = new List<Person>();
        for (int i = 0; i < 10000; i++)
        {
           people.Add(new Person{Name = $"Person{i}", Age = i}); 
        }

        return people;
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}