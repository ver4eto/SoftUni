
using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {
        private const string offset = "  ";

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
      

        public Car(string model, Engine engine)
        {
            Model = model;
           Engine= engine;
           Weight = -1;
            Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            :this(model, engine)
        {            
            Weight = weight;

        }

        public Car(string model, Engine engine, string color)
            :this (model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            :this(model,engine)
        {           
            Weight = weight;
            Color = color;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");

            sb.AppendLine(this.Engine.ToString());

            sb.AppendLine($"{offset}Weight: {(this.Weight == -1 ? "n/a" : this.Weight.ToString())}") ;

            sb.AppendLine($"{offset}Color: {this.Color}");

            return sb.ToString().TrimEnd();
        }
    }
}
