using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var tests = Assembly.GetCallingAssembly()
               .GetTypes()
               .Where(t => !t.IsAbstract)
               .Where(t => t.IsClass)
               .Where(t => t.IsPublic)
               .SelectMany(t => t.GetMethods())
               .Where(m => m.IsPublic)
               .Where(m => m.GetCustomAttribute<AwesomeTestAttribute>() != null);

            foreach (var test in tests)
            {
                Console.WriteLine($"found test: {test.Name}");
            }



        }



      
    }

    public class AwesomeTestAttribute : Attribute
    {
    }

    public static class MyAsserts
    {
        public static void IsEqual(string expected, string result)
        {
            var c = Console.ForegroundColor;

            if (expected.Equals(result))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = c;
        }
    }
}
