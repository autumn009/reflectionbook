using System.Reflection;

foreach (var item in Assembly.GetExecutingAssembly().GetTypes())
{
    var type = item.GetInterface("CommonTypeX");
    if (type != null)
    {
        var x = Activator.CreateInstance(item) as CommonTypeX;
        if (x != null) x.Sub();
    }
}

interface CommonTypeX
{
    void Sub();
}

class A : CommonTypeX
{
    public void Sub() => Console.WriteLine("I'm class A!");
}
class B : CommonTypeX
{
    public void Sub() => Console.WriteLine("I'm class B!");
}
class C
{
    public void Sub() => Console.WriteLine("I'm class C!");
}
