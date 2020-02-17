namespace CustomStack
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty()); 
            stack.AddRange(new List<string>() { "sdf", "yuyi", "bnm" });
            Console.WriteLine(stack.IsEmpty()); 
        }
    }
}
