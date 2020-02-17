using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            motorcycles = new List<IMotorcycle>();
        }
        public IMotorcycle GetByName(string model) => motorcycles.FirstOrDefault(x => x.Model == model);

        public IReadOnlyCollection<IMotorcycle> GetAll() => motorcycles.ToList();

        public void Add(IMotorcycle model) => motorcycles.Add(model);

        public bool Remove(IMotorcycle model) => motorcycles.Remove(model);
    }
}
