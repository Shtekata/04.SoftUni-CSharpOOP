using System;

namespace PersonsInfo
{
    public class Person
    {
        private int age;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age
        {
            get => age;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Invalid Age");
                }
                age = value;
            }
        }
        public decimal Salary { get; private set; }
        public void IncreaseSalary(decimal amount)
        {
            amount = Age < 30 ? amount / 200 : amount / 100;

            Salary += amount * Salary;
        }
        
        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
