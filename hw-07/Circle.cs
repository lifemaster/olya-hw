using System;

namespace hw_07
{
    class Circle : Shape
    {
        public double Radius { get; }

        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
