using System;
using System.Text;
using ClassBoxData.Exceptions;

namespace ClassBoxData.Models
{
    public class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.LengthZeroOrNegativeException);
                }
                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.WidthZeroOrNegativeException);
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeightZeroOrNegativeException);
                }

                this.height = value;
            }
        }

        public double LateralSurfaceArea()
        {
            double lateralArea = 2 * this.Length * this.Height + 2 * this.Width * this.Height;

            return lateralArea;
        }
        public double SurfaceArea()
        {
            double area = (2 * this.Length * this.Width) +this.LateralSurfaceArea();

            return area;
        }

        public double Volume()
        {
            double volume = this.Length * this.Height * this.Width;
            return volume;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.Volume():f2}");

            return sb.ToString().TrimEnd();
        }

    }
}
