var type = typeof(object).GetType();
for (; ; )
{
    Console.WriteLine($"type.FullName={type.FullName}");
    type = type.BaseType;
    if (type == null) break;
}
