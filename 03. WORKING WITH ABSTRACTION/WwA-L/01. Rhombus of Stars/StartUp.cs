namespace _01._Rhombus_of_Stars
{
    using System;
    public class Program
    {
        private static int number;
        public static void Main(string[] args)
        {
            number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                DrawLine(i);
            }

            for (int i = number - 1; i >= 1; i--)
            {
                DrawLine(i);
            }
        }

        private static void DrawLine(int i)
        {
            var space = number - i;
            Console.Write(new string(' ', space));
            for (int j = 0; j < i - 1; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine('*');
        }
    }
}
