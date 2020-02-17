namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var list = new RandomList() { "asd", "fgh", "xcv", "dfg", "ert" };

            Console.WriteLine(list.RandomString()); 
        }
    }
}
