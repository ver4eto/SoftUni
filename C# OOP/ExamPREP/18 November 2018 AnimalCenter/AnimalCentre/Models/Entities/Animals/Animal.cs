using AnimalCentre.Exception;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities
{
    public abstract class Animal : IAnimal
    {
        //private string name;
        private int energy;
        private int happiness;
        private bool isChipped;

        private Animal()
        {
            this.IsAdopt = false;
            this.Owner = "Centre";
            this.IsChipped = false;
            this.IsVaccinated = false;
        }
            

    protected Animal(string name, int energy, int happiness, int procedureTime)
            :this()
    {
        this.Name = name;
        this.Energy = energy;
        this.Happiness = happiness;
        this.ProcedureTime = procedureTime;
    }
    public string Name { get; private set; }


    public int Happiness
    {
        get => this.happiness;
         set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidHappinessException);
            }
            this.happiness = value;
        }
    }

    public int Energy
    {
        get => this.energy;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidEnergyException);
            }
            this.energy = value;
        }
    }

    public int ProcedureTime { get; set; }

    public string Owner { get;  set; }

    public bool IsAdopt { get;  set; }

    public bool IsChipped
        {
            get;set;
        }

       
    public bool IsVaccinated { get;  set; }

        public override string ToString()
        {
            return $"    Animal type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
