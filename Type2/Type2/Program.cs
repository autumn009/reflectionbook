// 型から直接取得する
var a = typeof(MySampleClass);
Console.WriteLine(a.FullName);

// インスタンスから取得する
var instance = new MySampleClass();
var b = instance.GetType();
Console.WriteLine(b.FullName);

// 名前から取得する
var c = Type.GetType("MySampleClass");
Console.WriteLine(c?.FullName);

class MySampleClass { }
