using System;

namespace PersonInfo
{
    public class Engine
    {
        public void Run()
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var id = Console.ReadLine();
            var birthdate = Console.ReadLine();

            IPerson person = new Citizen(name, age, id, birthdate);
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);

            var citisen = new Citizen(name, age, id, birthdate);

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
            Console.WriteLine();
            Console.WriteLine(identifiable.Id);
            Console.WriteLine();
            Console.WriteLine(birthable.Birthdate);
            Console.WriteLine();
            Console.WriteLine(citisen.Name);
            Console.WriteLine(citisen.Age);
            Console.WriteLine(citisen.Id);
            Console.WriteLine(citisen.Birthdate);
        }
    }
}
