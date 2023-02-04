Console.WriteLine($"found {AppDomain.CurrentDomain.GetAssemblies().Sum(c => c.GetTypes().Count())} types");
foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
{
    var name = item.FullName ?? "(NO NAME),";
    int index = name.IndexOf(',');
    Console.WriteLine($"{item.GetTypes().Count(),4} types in {name.Substring(0,index)}");
}
