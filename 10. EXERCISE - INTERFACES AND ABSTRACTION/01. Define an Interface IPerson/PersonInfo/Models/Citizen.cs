namespace PersonInfo
{
    using System;
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Name { get; private set; }
        
        public int Age { get; private set; }
        
        public string Id { get; private set; }
        
        public string Birthdate { get; private set; }
        
    }
}
