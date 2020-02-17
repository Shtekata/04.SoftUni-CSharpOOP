namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            pilots = new List<IPilot>();
            machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            var result = string.Empty;

            if (pilots.Any(x => x.Name == name))
            {
                result = string.Format(OutputMessages.PilotExists, name);
            }

            if (result == string.Empty)
            {
                var pilot = new Pilot(name);
                pilots.Add(pilot);
                result = string.Format(OutputMessages.PilotHired, name);
            }

            return result;
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var result = string.Empty;

            if (machines.Any(x => x.Name == name))
            {
                result = string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                var tank = new Tank(name, attackPoints, defensePoints);
                machines.Add(tank);
                result = string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
            }

            return result;
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            var result = string.Empty;

            if (machines.Any(x => x.Name == name))
            {
                result = string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                var fighter = new Fighter(name, attackPoints, defensePoints);
                machines.Add(fighter);
                var state = fighter.AggressiveMode ? "ON" : "OFF";
                result = string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, state);
            }

            return result;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var result = string.Empty;
            var pilot = pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            var machine = machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (pilot == null)
            {
                result = string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            else if (machine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            else if (machine.Pilot != null)
            {
                result = string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            else
            {
                pilot.AddMachine(machine);
                machine.Pilot = pilot;
                result = string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            }

            return result;
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var result = string.Empty;

            var attackingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defendingMachine = machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (defendingMachine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            else if (attackingMachine.HealthPoints <= 0)
            {
                result = string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            else if (defendingMachine.HealthPoints <= 0)
            {
                result = string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }
            else
            {
                attackingMachine.Attack(defendingMachine);
                result = string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);
            }

            return result;
        }

        public string PilotReport(string pilotReporting)
        {
            var output = string.Empty;

            var pilotToReport = pilots.FirstOrDefault(x => x.Name == pilotReporting);

            if (pilotReporting == null)
            {
                output = string.Format(OutputMessages.PilotNotFound, pilotReporting);
            }
            else output = pilotToReport.Report();

            return output;
        }

        public string MachineReport(string machineName)
        {
            var result = string.Empty;

            var machine = machines.FirstOrDefault(x => x.Name == machineName);

            if (machine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, machineName);
            }
            else
            {
                result = machine.ToString();
            }

            return result;
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var result = string.Empty;

            var machine = machines.FirstOrDefault(x => x.Name == fighterName);

            if (machine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, fighterName);
            }
            else
            {
                var fighter = (IFighter)machine;
                fighter.ToggleAggressiveMode();
                result = string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }

            return result;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var result = string.Empty;

            var machine = machines.FirstOrDefault(x => x.Name == tankName);

            if (machine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, tankName);
            }
            else
            {
                var tank = (ITank)machine;
                tank.ToggleDefenseMode();
                result = string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }

            return result;
        }
    }
}