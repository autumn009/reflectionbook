using System.Reflection;

Console.WriteLine("by new");
var a = new Nemo();
a.Sub();

Console.WriteLine("by reflection");
var type = Type.GetType("Nemo");
if (type != null)
{
    dynamic? instance = Activator.CreateInstance(type);
    instance?.Sub();
}

class Nemo
{
    public void Sub()
    {
        Console.WriteLine("in Nemo.Sub");
    }
}


