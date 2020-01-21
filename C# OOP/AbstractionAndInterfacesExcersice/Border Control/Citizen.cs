
namespace BorderControl
{
    public class Citizen : Model, IModel, IBuyer
    {
        public Citizen(string name,string age, string id, string birthDay)
            :base(id)
        {
            this.Name = name;
            this.Age = age;
            this.BirthDay = birthDay;
        }

        public string BirthDay { get; private set; }
        public string Age { get; private set; }
        public string Name { get;  set; }
        public int Food { get; set; }

        public override bool LastDigitOfID(string lastDigit)
        {
            if (this.Id.EndsWith(lastDigit))
            {
                return true;
            }
            return false;
        }

       
        public bool FindYear(string year)
        {
            if (this.BirthDay.EndsWith(year))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return this.BirthDay.ToString().TrimEnd();
        }

        public void BuyFood()
        {
            this.Food += 10;
        }

     
    }
}
