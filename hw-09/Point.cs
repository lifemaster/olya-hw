using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_09
{
    struct Point
    {
        public double x;

        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double Distance(Point point)
        {
            double diffX = point.x - x;
            double diffY = point.y - y;

            return Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
        }

        override public string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
