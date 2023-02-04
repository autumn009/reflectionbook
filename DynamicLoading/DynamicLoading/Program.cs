using System.Reflection;

checkSub();
Console.WriteLine("Loading");
var assembly = Assembly.LoadFrom(@"..\..\..\..\ClassLibrary1\bin\Debug\net7.0\ClassLibrary1.dll");
checkSub();

void checkSub()
{
    foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
    {
        var type = item.GetType("ClassLibrary1.Class1");
        if( type != null )
        {
            var method = type.GetMethod("Sub", BindingFlags.Static| BindingFlags.Public);
            if( method != null)
            {
                Console.WriteLine("Found");
                method?.Invoke(null, null);
                return;
            }
        }
    }
    Console.WriteLine("Not Found");
}
