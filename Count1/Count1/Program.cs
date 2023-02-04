using System.Reflection;

Console.WriteLine($"I have {Assembly.GetExecutingAssembly().GetTypes().Count()} types. They are ...");
foreach (var item in Assembly.GetExecutingAssembly().GetTypes())
{
    Console.WriteLine(item.FullName);
}
