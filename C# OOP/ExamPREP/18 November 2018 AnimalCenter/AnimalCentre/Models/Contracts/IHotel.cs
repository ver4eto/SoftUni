﻿namespace AnimalCentre.Models.Contracts
{
    using AnimalCentre.Models.Entities;
    using System.Collections.Generic;

    public interface IHotel
    {
        IReadOnlyDictionary<string,IAnimal> Animals { get; }
        //int Capacity { get; }

        void Accommodate(IAnimal animal);
        void Adopt(string animalName, string owner);
    }
}
