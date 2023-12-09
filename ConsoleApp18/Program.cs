using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type consoleType = typeof(Console);
            MethodInfo[] methods = consoleType.GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }
            MyClass myObject = new MyClass { MyProperty1 = 42, MyProperty2 = "Рефлексия" };

            Type myType = myObject.GetType();
            var properties = myType.GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(myObject);
                Console.WriteLine($"{property.Name}: {value}");
            }
            string myString = "Рефлексия";
            Type stringType = typeof(string);
            MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            if (substringMethod != null)
            {
                object[] parameters = { 7, 5 }; // Starting index and length
                object result = substringMethod.Invoke(myString, parameters);
                Console.WriteLine(result);
            }
            Type listType = typeof(List<>);
            Type genericArgument = typeof(int); // Specify the type argument if List<T>

            Type specificListType = listType.MakeGenericType(genericArgument);
            ConstructorInfo[] constructors = specificListType.GetConstructors();

            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor);
            }
            Console.ReadKey();
        }
    }
}
