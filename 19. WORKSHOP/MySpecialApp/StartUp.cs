namespace MySpecialApp
{
    using SoftUniTestingFramework.Runner;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var testRunner = new TestRunner();
            var resultSet = testRunner.Run(@"D:\OneDrive\Projects\04. SoftUni - C# OOP\19. WORKSHOP\MySpecialApp.Test\bin\Debug\netcoreapp2.2\MySpecialApp.Test.dll");
            
            foreach (var item in resultSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
