namespace Animals
{
    using System;
    public class StartUp
    {
        public  static void Main(string[] args)
        {
            Animal dog = new Dog("Gosho", "Meat");
            Animal cat = new Cat("Pesho", "Whiskas");

            Console.WriteLine(dog.ExplainSelf());
            Console.WriteLine(cat.ExplainSelf());
        }
    }
}
