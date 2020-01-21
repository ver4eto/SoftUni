using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp)
            :base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }
        public string Corp { get; }

        //public decimal Salary { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //public int ID { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //public string FirstName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        //public string LastName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}


