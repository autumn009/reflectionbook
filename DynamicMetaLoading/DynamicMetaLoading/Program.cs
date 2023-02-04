using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;

const string path = @"..\..\..\..\ClassLibrary1\bin\Debug\net7.0\ClassLibrary1.dll";

string[] runtimeAssemblies = Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll");
var paths = new List<string>(runtimeAssemblies);
paths.Add(Path.GetFileName(path));
var resolver = new PathAssemblyResolver(paths);

using (var mlc = new MetadataLoadContext(resolver))
{
    var assembly =  mlc.LoadFromAssemblyPath(path);
    var stream = assembly.GetManifestResourceStream("ClassLibrary1.TextFile1.txt");
    var bytes = new byte[256];
    stream?.Read(bytes, 0, bytes.Length);
    var s = Encoding.UTF8.GetString(bytes);
    Console.WriteLine(s);
}
