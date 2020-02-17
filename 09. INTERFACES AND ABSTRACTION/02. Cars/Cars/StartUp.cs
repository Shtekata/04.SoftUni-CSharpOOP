namespace Cars
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICar seat = new Seat("Leon", "Grey");
            var tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat);
            Console.WriteLine(tesla);
        }
    }
}
