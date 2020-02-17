using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char foodSymbol;

        public Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = points;
            random = new Random();
        }

        public int FoodPoints { get; set; }
        public bool IsFoodPoint(Point snakeHead)
        {
            return LeftX == snakeHead.LeftX && TopY == snakeHead.TopY;
        }
        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool isPointOnTheSnake = snakeElements
                .Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isPointOnTheSnake)
            {
                LeftX = random.Next(2, LeftX - 2);
                TopY = random.Next(2, TopY - 2);

                isPointOnTheSnake = snakeElements
                .Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
