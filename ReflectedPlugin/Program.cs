using System.Reflection;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {

        foreach (var item in Directory.GetFiles("bin/Debug/plugins", "*.dll"))
        {
            Assembly assembly = Assembly.LoadFrom(item);

            foreach (var type in assembly.GetTypes())
            {
                var dd1  = type.FullName;
                System.Console.WriteLine(dd1);
                var dd = type.GetInterfaces();
                System.Console.WriteLine(dd);

                if (type.GetInterface("IPlugin") != null)
                {
                    // Activator.CreateInstance(T Type) içindeki type 'A göre bir tane nesne oluşturur.
                    dynamic ins = Activator.CreateInstance(type);

                    System.Console.WriteLine(ins.Name());
                    System.Console.WriteLine(ins.Description());
                    ins.Run();

                }
            }
        }
    }
}

public class HellloPlugin : IPlugin
{
    public string Description()
    {
        return "Bu bir eklenti description'ıdır.";
    }

    public string Name()
    {
        return "Selam verme eklentisi";
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}