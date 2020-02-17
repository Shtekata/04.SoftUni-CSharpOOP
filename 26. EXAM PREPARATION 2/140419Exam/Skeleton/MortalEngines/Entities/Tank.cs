using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double initialHealthPoints = 100;
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
            ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }
        public void ToggleDefenseMode()
        {
            if (DefenseMode == false)
            {
                DefenseMode = true;
                AttackPoints -= 40;
                DefensePoints += 30;
            }
            else
            {
                DefenseMode = false;
                AttackPoints += 40;
                DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            var defenseOutput = DefenseMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Defense: {defenseOutput}";
        }
    }
}
