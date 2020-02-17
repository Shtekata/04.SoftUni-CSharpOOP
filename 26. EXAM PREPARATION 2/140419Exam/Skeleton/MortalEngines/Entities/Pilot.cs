using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        private Pilot()
        {
            machines = new List<IMachine>();
        }

        public Pilot(string name)
            :this()
        {
            Name = name;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException("Pilot name cannot be null or empty string."); }

                name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null) { throw new NullReferenceException("Null machine cannot be added to the pilot."); }

            machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Name} - {machines.Count} machines");

            foreach (var item in machines)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
