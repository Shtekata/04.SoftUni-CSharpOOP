using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBox
{
    public class Engine
    {
        private Hospital hospital;
        public Engine()
        {
            hospital = new Hospital();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] inputArgs = command.Split();

                var departament = inputArgs[0];
                var firstName = inputArgs[1];
                var lastName = inputArgs[2];
                var patient = inputArgs[3];

                var fullName = firstName + " " + lastName;

                hospital.AddDoctor(firstName, lastName);
                hospital.AddDepartnent(departament);
                hospital.AddPatient(fullName, departament, patient);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 1)
                {
                    var departmenName = args[0];
                    var department = hospital.Departments.FirstOrDefault(x => x.Name == departmenName);
                    Console.WriteLine(department);
                }
                else if (args.Length == 2)
                {
                    var isRoom = int.TryParse(args[1], out int targetRoom);

                    if (isRoom)
                    {
                        var departmenName = args[0];

                        var room = hospital.Departments.FirstOrDefault(x => x.Name == departmenName).Rooms[targetRoom - 1];
                        Console.WriteLine(room);
                    }
                    else
                    {
                        var fullName = args[0] + " " + args[1];
                        var doctor = hospital.Doctors.FirstOrDefault(x => x.FullName == fullName);
                        Console.WriteLine(doctor);
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
