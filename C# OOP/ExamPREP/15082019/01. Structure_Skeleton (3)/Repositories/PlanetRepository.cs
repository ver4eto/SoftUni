using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;
        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.planets;

        public void Add(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = this.planets.FirstOrDefault(p=>p.Name==name);
            return planet;
        }

        public bool Remove(IPlanet model)
        {
            
            if (this.planets.Contains(model))
            {
                this.planets.Remove(model);
                return true;
            }
            return false;
        }
    }
}
