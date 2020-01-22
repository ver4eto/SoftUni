using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Entities.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected IList<IAnimal> procedureHistory;
        protected List<IAnimal> animals { get; }

        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
            this.animals = new List<IAnimal>();
        }
        public virtual void DoService(IAnimal animal, int procedureTime)
        {
           
        }

        public  string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);

            string[] animalsInfo = procedureHistory
                 .OrderBy(a => a.Name)
                 .Select(a => a.ToString())
                 .ToArray();

            sb.AppendLine(string.Join(Environment.NewLine, animalsInfo));

            return sb.ToString().TrimEnd();


            ////sb.AppendLine($"{this.GetType().Name}");
            //foreach (IAnimal animal in animals)
            //{
            //    sb.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            //}

            //return sb.ToString().TrimEnd();
        }
    }
}
