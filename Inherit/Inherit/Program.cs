var type = typeof(object).GetType();
Console.WriteLine($"type.IsSubclassOf(typeof(Type))={type.IsSubclassOf(typeof(Type))}");
for (; ; )
{
    Console.WriteLine($"type.FullName={type.FullName}");
    type = type.BaseType;
    if (type == null) break;
}
