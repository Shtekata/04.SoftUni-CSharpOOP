namespace Farm
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
        }
    }
}
