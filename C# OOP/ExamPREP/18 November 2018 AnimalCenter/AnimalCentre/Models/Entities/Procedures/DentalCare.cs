﻿using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Exception;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Entities.Procedures
{
   public class DentalCare : Procedure
    {

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime>=procedureTime)
            {
                animal.ProcedureTime -= procedureTime;
                animal.Happiness += 12;
                animal.Energy += 10;
                base.procedureHistory.Add(animal);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTimeException);
            }
        }
    }
}
