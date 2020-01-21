using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {

        private double radius;
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public override double CalculateArea()
        {
            double area = Math.PI *this.Radius*this.Radius;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeteer = 2 * Math.PI * this.Radius;
            return perimeteer;
        }

        public override string Draw()
        {

            return base.Draw() + "Circle";
        }
    }
}
