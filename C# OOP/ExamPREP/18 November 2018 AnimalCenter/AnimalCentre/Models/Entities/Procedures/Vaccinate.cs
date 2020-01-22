using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Exception;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Entities.Procedures
{
   public class Vaccinate: Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime>=procedureTime)
            {
                animal.Energy -= 8;
                animal.ProcedureTime -= procedureTime;
                animal.IsVaccinated = true;
                base.procedureHistory.Add(animal);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTimeException);
            }
        }
    }
}
