﻿using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Repear : IRepair
    {
        public Repear(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }
        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
