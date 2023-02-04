using System.Reflection;

foreach (var item in Assembly.GetExecutingAssembly().GetTypes())
{
    var type = item.GetCustomAttribute<MyTargetAttribute>();
    if (type != null) Console.WriteLine($"Found Type {item.FullName}");
}

[MyTarget]
class A { }

[MyTarget]
class B { }

class C { }

class MyTargetAttribute : Attribute { }