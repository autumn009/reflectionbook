var x = new X();
x.DumpProps();
Console.WriteLine("Rewriting to 999...");
foreach (var prop in x.GetType().GetProperties())
{
    if (prop.CanWrite) prop.SetValue(x, 999);
}
x.DumpProps();

class X
{
    public int MyProperty1 { get; set; } = 1;
    public int MyProperty2 { get; set; } = 2;
    public int MyProperty3 { get; } = 3;
    public void DumpProps()
    {
        Console.WriteLine($"MyProperty1={MyProperty1}");
        Console.WriteLine($"MyProperty2={MyProperty2}");
        Console.WriteLine($"MyProperty3={MyProperty3}");
    }
}
