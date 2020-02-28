using System;

namespace hw_07
{
    class Square : Shape
    {
        public double Side { get; }

        public Square(string name, double side) : base(name)
        {
            Side = side;
        }

        public override double Area()
        {
            return Math.Pow(Side, 2);
        }

        public override double Perimeter()
        {
            return 4 * Side;
        }
    }
}
