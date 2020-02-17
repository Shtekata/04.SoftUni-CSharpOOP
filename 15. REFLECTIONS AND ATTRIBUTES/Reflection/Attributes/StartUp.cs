namespace Attributes
{
    using System;
    using System.Linq;

    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        public static void Main()
        {
            //var tp = typeof(StartUp);
            //
            //var attributes = tp.CustomAttributes;
            //
            //foreach (var item in attributes)
            //{
            //    if (item.AttributeType == typeof(AuthorAttribute))
            //    {
            //        Console.WriteLine(item.ConstructorArguments.First().Value);
            //    }
            //}
            //
            //var methods = tp.GetMethods(System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Static);
            //
            //foreach (var item in methods)
            //{
            //    var methodAttributes = item.CustomAttributes;
            //
            //    foreach (var item2 in methodAttributes)
            //    {
            //        if (item2.AttributeType == typeof(AuthorAttribute))
            //        {
            //            Console.WriteLine(item2.ConstructorArguments.First().Value);
            //        }
            //    }
            //
            //    
            //}
            //var tracker = new Tracker();
            Tracker.PrintMethodsByAuthor();
        }
    }
}
