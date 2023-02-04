using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

const string path = @"..\..\..\..\ClassLibrary1\bin\Debug\net7.0\ClassLibrary1.dll";

var paths = Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll").Append(path);
var resolver = new PathAssemblyResolver(paths);

using (var mlc = new MetadataLoadContext(resolver))
{
    var assembly = mlc.LoadFromAssemblyPath(path);
    var stream = assembly.GetManifestResourceStream("ClassLibrary1.TextFile1.txt");
    var bytes = new byte[256];
    stream?.Read(bytes, 0, bytes.Length);
    var s = Encoding.UTF8.GetString(bytes).Substring(1);
    Console.WriteLine(s);
}
