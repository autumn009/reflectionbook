using System.Reflection;

foreach (var item in Assembly.GetExecutingAssembly().GetTypes())
{
    if (item.IsSubclassOf(typeof(Base)))
    {
        var type = item.GetCustomAttribute<ExcludeAttribute>();
        if (type == null) Console.WriteLine($"Found Type {item.FullName}");
    }
}

class Base { }

class A: Base { }

class B: Base { }

[Exclude]
class C: Base { }

class ExcludeAttribute : Attribute { }
