using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
   public class Animal
    {

        public string Name { get; private set; }

        public string FavoriteFood { get; private set; }

        public Animal(string name, string favFood)
        {
            this.Name = name;
            this.FavoriteFood = favFood;
        }

        public  virtual string ExplainSelf()
        {
            return $"I am {Name} and my favourite food is Whiskas {FavoriteFood}";
        }
    }
}
