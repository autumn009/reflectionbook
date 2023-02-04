object a = 1;
object b = "2";
sub(nameof(a), a);
sub(nameof(b), b);

void sub(string label, object x)
{
    Console.WriteLine($"{label} is {IsBoxed(x)}");
}

bool IsBoxed<T>(T value)
{
    return
        (typeof(T).IsInterface || typeof(T) == typeof(object)) &&
        value != null &&
        value.GetType().IsValueType;
}
