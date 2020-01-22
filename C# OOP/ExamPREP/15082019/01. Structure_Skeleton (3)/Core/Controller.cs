using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        int exploredPlanetCounnt;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.exploredPlanetCounnt = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            string result;
            IAstronaut astronaut;

            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
                result = string.Format(Utilities.Messages.OutputMessages.AstronautAdded, type, astronautName);
                astronauts.Add((Astronaut)astronaut);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
                result = string.Format(Utilities.Messages.OutputMessages.AstronautAdded, type, astronautName);
                astronauts.Add((Astronaut)astronaut);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
                result = string.Format(Utilities.Messages.OutputMessages.AstronautAdded, type, astronautName);
                astronauts.Add((Astronaut)astronaut);
            }
            else
            {
                result = Utilities.Messages.ExceptionMessages.InvalidAstronautType;
            }

            return result;
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);
            planets.Add(planet);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            string result = string.Format(Utilities.Messages.OutputMessages.PlanetAdded, planet.Name);
            return result;
        }

        public string ExplorePlanet(string planetName)
        {
            IList<IAstronaut> availableAtsra = new List<IAstronaut>();

            foreach (var item in astronauts.Models)
            {
                if (item.Oxygen > 60)
                {
                    availableAtsra.Add(item);
                }
            }

            if (availableAtsra.Count == 0)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.InvalidAstronautCount));

            }

            Mission mission = new Mission();
            string result;

            this.exploredPlanetCounnt++;

            IPlanet planet = planets.Models.FirstOrDefault(n => n.Name == planetName);
            mission.Explore(planet, (IList<IAstronaut>)availableAtsra);
            int countOfDeadAstro = availableAtsra.Where(a => a.CanBreath == false).Count();
            result = string.Format(Utilities.Messages.OutputMessages.PlanetExplored, planet.Name, countOfDeadAstro);


            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.exploredPlanetCounnt} planets were explored!");

            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models/*.Where(a=>a.Bag.Items.Count>0)*/)
            {
                sb.AppendLine($"Name: { astronaut.Name}");
                sb.AppendLine($"Oxygen: { astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count > 0)
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items.ToList())}");

                }
                else
                {
                    sb.AppendLine("Bag items: none");

                }

            }

            //foreach (var astronaut in astronauts.Models.Where(a => a.Bag.Items.Count == 0))
            //{
            //    sb.AppendLine($"Name: { astronaut.Name}");
            //    sb.AppendLine($"Oxygen: { astronaut.Oxygen}");

            //}

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            string result;
            IAstronaut currentAstro = astronauts.FindByName(astronautName);

            if (currentAstro == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove((Astronaut)currentAstro);

            result = string.Format(Utilities.Messages.OutputMessages.AstronautRetired, astronautName);


            return result;
        }
    }
}
