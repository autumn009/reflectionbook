using System.Reflection;

Console.WriteLine("by new");
var a = new Nemo();
a.Sub();

Console.WriteLine("by reflection");
var type = Type.GetType("Nemo");
if (type != null)
{
    object? instance = System.Activator.CreateInstance(type);
    if( instance != null )
    {
        var method = type.GetMethod("Sub",BindingFlags.Instance|BindingFlags.Public);
        method?.Invoke(instance, null);
    }
}

class Nemo
{
    public void Sub()
    {
        Console.WriteLine("in Nemo.Sub");
    }
}


