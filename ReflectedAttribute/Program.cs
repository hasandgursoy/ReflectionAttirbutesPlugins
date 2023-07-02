using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {

        Person p1 = new Person { Name = "Hasan", Age = "22" };
        Person p2 = new Person { Name = "Selina", Age = "90", ID = "923291" };

        System.Console.WriteLine(Control.Check(p1));
        System.Console.WriteLine(Control.Check(p2));

    }
}


// Burada ki senaryo şu biz bir attribute yazalım ve bu attribute aşşağıda ki değerlerin boş geçilmesini engellesin.
public class Person
{
    [Necessary]
    public string Name;
    [Necessary]
    public string ID;
    [Necessary]
    public string Age;

    public Person()
    {
    }

    public Person(string name, string iD, string age)
    {
        Name = name;
        ID = iD;
        Age = age;
    }
    
}

// Birden fazla aynı attribute'u field'ın üzerine yazabilsin diye bunu yazıyoruz. False'u true'ya set edersek özellik açılacak.
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class NecessaryAttribute : Attribute
{

}

public static class Control
{

    public static bool Check(Person person)
    {
        Type type = person.GetType();

        foreach (var item in type.GetFields())
        {
            object[] attributes = item.GetCustomAttributes(typeof(NecessaryAttribute), true);

            if (attributes.Length != 0)
            {
                object? value = item.GetValue(person);

                if (value == null)
                {
                    return false;
                }
            }

        }
        return true;
    }
}

public interface IPlugin
{
    string Name();
    string Description();
    void Run();
}