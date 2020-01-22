using AnimalCentre.Exception;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime >= procedureTime)
            {
                
                    if (animal.IsChipped == false)
                    {
                        animal.ProcedureTime -= procedureTime;
                        animal.IsChipped = true;
                        animal.Happiness -= 5;
                        base.procedureHistory.Add(animal);
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(ExceptionMessages.AnimalIsAlreadyChippenException, animal.Name));

                    }

                
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTimeException);
            }

        }
    }
}
