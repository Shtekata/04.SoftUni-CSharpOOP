using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBox
{
    public class Doctor
    {
        public Doctor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Patients = new List<Patient>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
            => FirstName + " " + LastName;
        public List<Patient> Patients { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var patient in Patients.OrderBy(x=>x.Name))
            {
                sb.AppendLine(patient.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
