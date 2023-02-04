using System.Reflection;

var resolver = new PathAssemblyResolver(new string[] { "ExampleAssembly.dll", typeof(object).Assembly.Location });




var mlc = new MetadataLoadContext(resolver);

using (mlc)
{
    // Load assembly into MetadataLoadContext.
    Assembly assembly = mlc.LoadFromAssemblyPath("ExampleAssembly.dll");
    AssemblyName name = assembly.GetName();

    // Print assembly attribute information.
    Console.WriteLine($"{name.Name} has following attributes: ");

    foreach (CustomAttributeData attr in assembly.GetCustomAttributesData())
    {
        try
        {
            Console.WriteLine(attr.AttributeType);
        }
        catch (FileNotFoundException ex)
        {
            // We are missing the required dependency assembly.
            Console.WriteLine($"Error while getting attribute type: {ex.Message}");
        }
    }
}

