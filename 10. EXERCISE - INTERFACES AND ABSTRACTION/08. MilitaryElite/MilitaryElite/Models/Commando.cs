using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => missions;

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var item in Missions)
            {
                sb.AppendLine($"  {item.ToString().TrimEnd()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
