
namespace BorderControl
{
    public class Pet : IModel
    {
        public Pet(string name, string birthDay)           
        {
            this.Name = name;
            this.BirthDay = birthDay;
        }
        public string BirthDay { get; private set; }
        public string Name { get; private set; }
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
    }
}
