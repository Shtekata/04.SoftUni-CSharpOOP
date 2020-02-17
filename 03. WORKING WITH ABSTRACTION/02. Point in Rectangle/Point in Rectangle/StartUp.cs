namespace Point_in_Rectangle
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] coordinates = ParseInput();

            var topLeft = new Point(coordinates[0], coordinates[1]);
            var bottomRight = new Point(coordinates[2], coordinates[3]);

            var rectangle = new Rectangle(topLeft, bottomRight);
            var number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                var input1 = Console.ReadLine();
                var input2 = input1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var input3 = input2.Select(int.Parse);
                var input4 = input3.ToArray();

                var point = new Point(input4[0], input4[1]);

                Console.WriteLine(rectangle.Contains(point));
            }
        }

        private static int[] ParseInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
