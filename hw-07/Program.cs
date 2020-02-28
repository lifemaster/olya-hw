using System;
using System.Collections.Generic;

namespace hw_07
{
    class Program
    {
        static void Main(string[] args)
        {
            List <Shape> shapeList = new List<Shape>();

            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();

                int randomNumber = random.Next(1, 3);

                if (i > 0)
                {
                    Console.WriteLine();
                }

                if (randomNumber == 1)
                {
                    shapeList.Add(GetCircle());
                }
                else if (randomNumber == 2)
                {
                    shapeList.Add(GetSquare());
                }
            }

            foreach (Shape shape in shapeList)
            {
                Console.WriteLine();
                Console.WriteLine($"Shape name: {shape.Name}");
                Console.WriteLine($"Shape area: {shape.Area()}");
                Console.WriteLine($"Shape perimeter: {shape.Perimeter()}");
            }

            Shape shapeWithMaxPerimeter = GetShapeWithMaxPerimeter(shapeList);

            Console.WriteLine();
            Console.WriteLine($"Shape \"{shapeWithMaxPerimeter.Name}\" has the largest perimeter: {shapeWithMaxPerimeter.Perimeter()}");

            shapeList.Sort();

            Console.WriteLine();
            Console.WriteLine("Shapes after sort by area:");

            for (int i = 0; i <= shapeList.Count - 1; i++)
            {
                Console.WriteLine($"Shape name: {shapeList[i].Name}, shape perimeter: {shapeList[i].Perimeter()}, shape area: {shapeList[i].Area().ToString()}");
            }

            Console.WriteLine();
            Console.WriteLine("Press Ctrl + C to exit...");
            Console.ReadLine();
        }

        static Circle GetCircle()
        {
            Console.Write($"Enter name for circle: ");
            string circleName = Console.ReadLine();

            Console.Write($"Enter radius for circle: ");
            double circleRadius = double.Parse(Console.ReadLine());

            return new Circle(circleName, circleRadius);
        }

        static Square GetSquare()
        {
            Console.Write($"Enter name for square: ");
            string squareName = Console.ReadLine();

            Console.Write($"Enter side for square: ");
            double squareSide = double.Parse(Console.ReadLine());

            return new Square(squareName, squareSide);
        }

        static Shape GetShapeWithMaxPerimeter(List<Shape> shapeList)
        {
            Shape result = shapeList[0];

            double maxPerimeter = shapeList[0].Perimeter();

            for (int i = 1; i < shapeList.Count; i++)
            {
                if (shapeList[i].Perimeter() > maxPerimeter)
                {
                    result = shapeList[i];
                    maxPerimeter = shapeList[i].Perimeter();
                }
            }

            return result;
        }
    }
}
