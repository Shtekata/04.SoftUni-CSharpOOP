using System;

namespace PersonsInfo
{
    public class Person
    {
        private int age;
        private string firstName;
        private string lastName;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public string FirstName
        {
            get => firstName;

            private set
            {
                ValidateName(value, "FirstName");
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            private set
            {
                ValidateName(value, "LastName");
                lastName = value;
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }
        public decimal Salary
        {
            get => salary;
            private set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less 460 leva!");
                }
                salary = value;
            }
        }
        public void IncreaseSalary(decimal amount)
        {
            amount = Age < 30 ? amount / 200 : amount / 100;

            Salary += amount * Salary;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
        private static void ValidateName(string value, string a)
        {
            if (value.Length < 3 && a == "FirstName")
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            else if (value.Length < 3 && a == "LastName")
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
        }

    }
}
