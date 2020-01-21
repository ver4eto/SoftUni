using System;

namespace Shapes
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());

            IDrawable shape = new Circle(radius);

            shape.Draw();

            Console.WriteLine();
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            shape = new Rectangle(width,height);

            shape.Draw();
        }
    }
}
