using System;

namespace hw_07
{
    abstract class Shape : IComparable<Shape>
    {
        private readonly string name;

        public string Name { get { return name;  } }

        public Shape(string name)
        {
            this.name = name;
        }

        abstract public double Area();

        abstract public double Perimeter();

        public int CompareTo(Shape other)
        {
            return Area().CompareTo(other.Area());
        }

    }
}
