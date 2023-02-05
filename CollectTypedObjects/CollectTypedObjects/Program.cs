using System.Reflection;

var persons = CollectTypedObjects<Person>(Assembly.GetExecutingAssembly());
foreach (var person in persons) Console.WriteLine(person.GetName());

TargetType[] CollectTypedObjects<TargetType>(Assembly targetAssembly)
{
    List<TargetType> list = new List<TargetType>();
    foreach (var t in targetAssembly.GetTypes())
    {
        if (t.IsAbstract) continue;
        if (t.IsSubclassOf(typeof(TargetType)))
        {
            if (t.GetCustomAttributes(typeof(ExcludeAttribute), false).Length == 0)
            {
                object? obj = Activator.CreateInstance(t);
                if (obj != null) list.Add((TargetType)obj);
            }
        }
    }
    return list.ToArray();
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class ExcludeAttribute : Attribute { }

abstract class Person
{
    public abstract string GetName();
}

class Taro : Person
{
    public override string GetName() => "たろう";
}

class Jiro : Person
{
    public override string GetName() => "じろう";
}

class Saburo : Person
{
    public override string GetName() => "さぶろう";
}
