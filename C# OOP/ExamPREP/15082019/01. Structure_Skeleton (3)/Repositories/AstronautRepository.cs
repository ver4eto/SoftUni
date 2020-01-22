using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronauts;
        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models =>/*(IReadOnlyCollection<Astronaut>)*/this.astronauts.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.astronauts.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronaut =this.astronauts.FirstOrDefault(n=>n.Name==name);
            return astronaut;
        }

        public bool Remove(IAstronaut model)
        {
            if (this.astronauts.Contains(model))
            {
                this.astronauts.Remove(model);
                return true;
            }
            return false;
        }
    }
}
