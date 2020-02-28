using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using hw_07;

namespace hw_08
{
    class Program
    {
        static readonly string pathToFileWithShapesAreafrom10To100 = "../../shapes-with-area-from-10-to-100.txt";

        static readonly string pathToFileWithShapesNameContainsLetterA = "../../shapes-with-name-contains-letter-a.txt";

        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Circle("My First Circle", 0.1));
            shapes.Add(new Square("My First Square", 0.5));
            shapes.Add(new Circle("My Second Circle", 1));
            shapes.Add(new Square("My Second Square", 2));
            shapes.Add(new Circle("My Third Circle", 3));
            shapes.Add(new Square("My Third Square", 4));

            WriteShapeToFile(pathToFileWithShapesAreafrom10To100, shapes.Where(shape => shape.Area() > 10 && shape.Area() < 100));
            WriteShapeToFile(pathToFileWithShapesNameContainsLetterA, shapes.Where(shape => shape.Name.IndexOf("a") >= 0));

            shapes.RemoveAll(shape => shape.Perimeter() < 5);

            Console.WriteLine("Shape List which contains shapes with perimeter greater than 5:");
            Console.WriteLine();

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Name: {shape.Name}, area: {shape.Area()}, perimeter: {shape.Perimeter()}");
            }

            Console.WriteLine();
            Console.WriteLine("Press Ctrl + C to exit...");
            Console.ReadLine();
        }

        static void WriteShapeToFile(string pathToFile, IEnumerable<Shape> shapes)
        {
            StreamWriter streamWriter = new StreamWriter(pathToFile);

            foreach (Shape shape in shapes)
            {
                streamWriter.WriteLine($"Name: {shape.Name}, area: {shape.Area()}, perimeter: {shape.Perimeter()}");
            }

            streamWriter.Close();
        }
    }
}
