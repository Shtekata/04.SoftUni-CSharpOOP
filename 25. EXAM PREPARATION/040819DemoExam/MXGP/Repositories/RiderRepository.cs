using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> riders;

        public RiderRepository()
        {
            riders = new List<IRider>();
        }
        public IRider GetByName(string name) => riders.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRider> GetAll() => riders.ToList();

        public void Add(IRider name) => riders.Add(name);

        public bool Remove(IRider name) => riders.Remove(name);
    }
}
