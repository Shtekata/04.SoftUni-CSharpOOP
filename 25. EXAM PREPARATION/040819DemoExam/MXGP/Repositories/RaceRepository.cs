using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> racers;

        public RaceRepository()
        {
            racers = new List<IRace>();
        }
        public IRace GetByName(string name) => racers.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRace> GetAll() => racers.ToList();

        public void Add(IRace name) => racers.Add(name);

        public bool Remove(IRace name) => racers.Remove(name);
    }
}
