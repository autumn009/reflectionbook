object a = 1;
object b = "Text";
ISample c = new X();
sub(nameof(a), a);
sub(nameof(b), b);
sub(nameof(c), c);

void sub<T>(string label, T x)
{
    var s = IsBoxed(x) ? "" : "not ";
    Console.WriteLine($"{label} is {s}boxed");
}

bool IsBoxed<T>(T value)
{
#if DUMP
    Console.WriteLine($"typeof(T).IsInterface={typeof(T).IsInterface}");
    Console.WriteLine($"typeof(T) == typeof(object)={typeof(T) == typeof(object)}");
    Console.WriteLine($"value != null={value != null}");
    Console.WriteLine($"value.GetType().IsValueType={value.GetType().IsValueType}");
#endif
    return
        (typeof(T).IsInterface || typeof(T) == typeof(object)) &&
        value != null &&
        value.GetType().IsValueType;
}

interface ISample
{
    void DummySub();
}

struct X : ISample
{
    public void DummySub() => Console.WriteLine("I'm X.Sub!");
}