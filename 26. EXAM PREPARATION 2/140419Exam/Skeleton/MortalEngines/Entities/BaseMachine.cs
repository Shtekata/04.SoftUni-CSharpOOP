using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Common;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        private BaseMachine()
        {
            targets = new List<string>();
        }

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
            :this()
        {
            Name = name;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            HealthPoints = healthPoints;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                name = value;
            }
        }

        public IPilot Pilot
        {
            get => pilot;
            set
            {
                pilot = value ?? throw new NullReferenceException("Pilot cannot be null.");
            }
        }
        public double HealthPoints
        {
            get => healthPoints;
            set => healthPoints = value;
        }

        public double AttackPoints
        {
            get => attackPoints;
            protected set => attackPoints = value;
        }

        public double DefensePoints
        {
            get => defensePoints;
            protected set => defensePoints = value;
        }

        public IList<string> Targets => targets;

        public void Attack(IMachine target)
        {
            if(target == null) { throw new NullReferenceException("Target cannot be null"); }

            var hpDecreasment = AttackPoints - target.DefensePoints;

            target.HealthPoints -= hpDecreasment;

            if (target.HealthPoints < 0) { target.HealthPoints = 0; }

            targets.Add(target.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var targetsOutput = targets.Count > 0 ? String.Join(",", targets) : "None";

            sb.AppendLine($"- {Name}")
                .AppendLine($" *Type: {GetType().Name}")
                .AppendLine($" *Health: {HealthPoints:f2}")
                .AppendLine($" *Attack: {AttackPoints:f2}")
                .AppendLine($" *Defense: {DefensePoints:f2}")
                .AppendLine($" *Targets: {targetsOutput}");

            return sb.ToString().TrimEnd();
        }
    }
}
