using System;

namespace hw_09
{
    class Triangle
    {
        public Point vertex1;

        public Point vertex2;

        public Point vertex3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            vertex1.x = x1;
            vertex1.y = y1;

            vertex2.x = x2;
            vertex2.y = y2;

            vertex3.x = x3;
            vertex3.y = y3;
        }

        private double Perimeter()
        {
            return vertex1.Distance(vertex2) + vertex2.Distance(vertex3) + vertex3.Distance(vertex1);
        }

        private double Square()
        {
            double halfPerimeter = Perimeter() / 2;

            double sideA = vertex1.Distance(vertex2);

            double sideB = vertex2.Distance(vertex3);

            double sideC = vertex3.Distance(vertex1);

            return Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
        }

        public string Print()
        {
            return $"Perimeter: {Perimeter()}, square: {Square()}";
        }
    }
}
