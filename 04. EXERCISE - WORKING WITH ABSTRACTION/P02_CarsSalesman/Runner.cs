using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class Runner
    {
        private List<Car> cars;
        private List<Engine> engines;

        public Runner()
        {
            cars = new List<Car>();
            engines = new List<Engine>();
        }
        public void Start()
        {
            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var engine = CreateEngine(parameters);

                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var car = CreateCar(parameters);
                cars.Add(car);

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private Car CreateCar(string[] parameters)
        {
            Car car = null;

            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            if (parameters.Length == 3)
            {
                var isWeight = int.TryParse(parameters[2], out int weight);

                if (isWeight)
                {
                    car = new Car(model, engine, weight);
                }
                else
                {
                    string color = parameters[2];
                    car = new Car(model, engine, color);
                }
            }
            
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                var weight = int.Parse(parameters[2]);
                car = new Car(model, engine, weight, color);
            }

            else
            {
                car = new Car(model, engine);
            }

            return car;
        }

        private Engine CreateEngine(string[] parameters)
        {

            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            var engine = new Engine(model, power);

            if (parameters.Length == 3)
            {
                var isDisplacement = int.TryParse(parameters[2], out int displacement);

                if (isDisplacement)
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    string efficiency = parameters[2];
                    engine.Efficiency = efficiency;
                }
            }
            else if (parameters.Length == 4)
            {
                var displacement = int.Parse(parameters[2]);
                string efficiency = parameters[3];
                engine.Efficiency = efficiency;
                engine.Displacement = displacement;
            }

            return engine;
        }
    }
}

