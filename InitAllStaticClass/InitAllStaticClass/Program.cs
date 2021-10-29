foreach (var item in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
{
    if (item.IsInterface) continue;
    Console.WriteLine($"Found static class {item.FullName}");
    System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(item.TypeHandle);
}
A.sub();

static class A
{
    public static void sub() => Console.WriteLine("Use of class A");
    static A() => Console.WriteLine("A initialized");
}
static class B
{
    static B() => Console.WriteLine("B initialized");
}
static class C
{
    static C() => Console.WriteLine("C initialized");
}