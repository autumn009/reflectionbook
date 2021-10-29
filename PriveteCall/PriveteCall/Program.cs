var s = new MyClass();
var mytype = s.GetType();
var subMethod = mytype.GetMethod("sub", System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance);
subMethod?.Invoke(s,null);

class MyClass
{
    private void sub()
    {
        Console.WriteLine("Hello I'm Private");
    }
}