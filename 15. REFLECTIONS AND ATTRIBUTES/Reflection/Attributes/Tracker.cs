using System;
using System.Linq;
using System.Reflection;

namespace Attributes
{
    public class Tracker
    {
        public static void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var item in methods)
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = item.GetCustomAttributes(false);
                    foreach (AuthorAttribute item2 in attributes)
                    {
                        System.Console.WriteLine($"{item.Name} is written by {item2.Name}");
                    }
                }
            }
        }
    }
}
