using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';

        private int nextLeftX;
        private int nextTopY;

        private int foodIndex;

        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;

        public Snake(Wall wall)
        {
            this.wall = wall;
            foods = new Food[3];
            snakeElements = new Queue<Point>();
            foodIndex = RandomFoodNumber;
            GetFoods();
            CreateSnake();
        }
        public int RandomFoodNumber => new Random().Next(0, foods.Length);
        public bool IsMoving(Point direction)
        {
            var snakeHead = snakeElements.Last();

            GetNextPoint(direction, snakeHead);

            var IsPointOfSnake = snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (IsPointOfSnake)
            {
                return false;
            }

            var snakeNewHead = new Point(nextLeftX, nextTopY);

            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                Eat(direction, snakeHead);
            }

            var snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(' ');

            return true;
        }

        public void Eat(Point direction, Point currentSnakeHead)
        {
            var length = foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            foodIndex = RandomFoodNumber;
            foods[foodIndex].SetRandomPosition(snakeElements);

        }
        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }

            foods[foodIndex].SetRandomPosition(snakeElements);
        }
        private void GetFoods()
        {
            foods[0] = new FoodAsterisk(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodHash(wall);
        }
    }
}
