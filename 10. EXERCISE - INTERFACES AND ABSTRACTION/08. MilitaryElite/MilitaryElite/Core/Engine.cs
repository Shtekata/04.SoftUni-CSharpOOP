using MilitaryElite.Contracts;
using MilitaryElite.Exceptions;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private readonly List<ISoldier> army;
        public Engine()
        {
            army = new List<ISoldier>();
        }
        public void Run()
        {
            var command = Console.ReadLine();

            while (command!="End")
            {
                var commandArgs = command
                    .Split()
                    .ToArray();

                var type = commandArgs[0];
                var id = commandArgs[1];
                var firstName = commandArgs[2];
                var lastName = commandArgs[3];
                var salary = decimal.Parse(commandArgs[4]);

                if (type == "Private")
                {
                    var soldier = new Private(id, firstName, lastName, salary);

                    army.Add(soldier);
                }
                else if (type == "LieutenantGeneral")
                {
                    var general = new LieutenantGeneral(id, firstName, lastName, salary);

                    var privatesToAddArgs = commandArgs
                        .Skip(5)
                        .ToArray();

                    foreach (var item in privatesToAddArgs)
                    {
                        var privateToAdd = army.First(x => x.Id == item);

                        general.AddPrivate(privateToAdd);
                    }

                    army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        var corps = commandArgs[5];

                        var engineer = new Engineer(id, firstName, lastName, salary, corps);

                        var repearArgs = commandArgs
                            .Skip(6)
                            .ToArray();

                        AddRepears(engineer, repearArgs);

                        army.Add(engineer);
                    }
                    catch (InvalidCorpsException ex)
                    {

                    }
                    
                }
                else if (type == "Commando")
                {
                    try
                    {
                        var corps = commandArgs[5];

                        var commando = new Commando(id, firstName, lastName, salary, corps);

                        var missionsArgs = commandArgs
                            .Skip(6)
                            .ToArray();

                        for (int i = 0; i < missionsArgs.Length; i+=2)
                        {
                            try
                            {
                                var codeName = missionsArgs[i];
                                var state = missionsArgs[i + 1];
                                var mission = new Mission(codeName, state);
                                commando.AddMission(mission);
                            }
                            catch (InvalidStateException)
                            {
                                continue;
                            }
                        }

                        army.Add(commando);
                    }
                    catch (InvalidCorpsException ex)
                    {

                    }
                }
                else if (type == "Spy")
                {
                    var codeNumber = (int)salary;

                    var spy = new Spy(id, firstName, lastName, codeNumber);

                    army.Add(spy);
                }

                command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var item in army)
            {
                var type = item.GetType();

                var actual = Convert.ChangeType(item, type);

                Console.WriteLine(actual.ToString());
            }
        }

        private static void AddRepears(Engineer engineer, string[] repearArgs)
        {
            for (int i = 0; i < repearArgs.Length; i += 2)
            {
                var partName = repearArgs[i];
                var hours = int.Parse(repearArgs[i + 1]);
                var repair = new Repear(partName, hours);
                engineer.AddRepair(repair);
            }
        }
    }
}
