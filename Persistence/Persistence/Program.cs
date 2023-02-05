using System.Reflection;

Console.WriteLine("セーブします");
// セーブ
using (var writer = File.CreateText("Test.txt"))
{
    walkAll((type, prop) =>
    {
        writer.WriteLine(type.FullName);
        writer.WriteLine(prop.Name);
        writer.WriteLine(prop.GetValue(null));
    });
}
// ダンプ
dumpAll();
// ゼロクリア
Console.WriteLine("ゼロクリアします");
walkAll((type, prop) => prop.SetValue(null,0));
// ダンプ
dumpAll();
// ロード
Console.WriteLine("ロードします");
using (var reader = File.OpenText("Test.txt"))
{
    for (; ; )
    {
        var typeName = reader.ReadLine();
        if (typeName == null) break;
        var propName = reader.ReadLine();
        var propValue = reader.ReadLine();
        walkAll((type, prop) =>
        {
            if (typeName == type.FullName && propName == prop.Name)
            {
                prop.SetValue(null, int.Parse(propValue ?? "0"));
            }
        });
    }
}
// ダンプ
dumpAll();

void dumpAll()
{
    walkAll((type,prop) => Console.WriteLine($"{prop.Name}={prop.GetValue(null)}"));
}

void walkAll(Action<Type,PropertyInfo>act)
{
    foreach (var item2 in Assembly.GetExecutingAssembly().GetTypes())
    {
        foreach (var item3 in item2.GetProperties(BindingFlags.Public | BindingFlags.Static))
        {
            if (item3 != null) act(item2,item3);
        }
    }
}

static class A
{
    public static int MyProperty1 { get; set; } = 123;
}

static class B
{
    public static int MyProperty1 { get; set; } = 456;
    public static int MyProperty2 { get; set; } = 789;
}
