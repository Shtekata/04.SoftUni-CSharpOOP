namespace SimpleSnake
{
    using NAudio.Wave;
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using System;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            using (var wavOut=new WaveOutEvent())
            {
                using (var wavReader = new WaveFileReader(@"D:\OneDrive\Projects\04. SoftUni - C# OOP\20. WORKSHOP 2\SimpleSnake\track.wav"))
                {
                    wavOut.Init(wavReader);
                    wavOut.Play();
                }
            }

            var wall = new Wall(60, 20);
            var snake = new Snake(wall);

            var copyRightText = "Snake by SoftUni @ C# OOP";

            Console.SetCursorPosition(wall.LeftX - copyRightText.Length, wall.TopY + 1);
            Console.Write(copyRightText);

            var engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}
