using System;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static PointList points = new PointList();

        static void Main(string[] args)
        {
            // Event args section
            points.Changed += delegate (object sender, PointListChangedEventArgs e)
            {
                Console.WriteLine($"The Points object has changed. {e.Operation}");
            };

            points.Add(new Point(-4, -7));
            points.Add(new Point(0, 0));
            points.Add(new Point(1, 2));
            points.Add(new Point(-4, 5));
            points.Insert(2, new Point(3, 1));
            points.Add(new Point(7, -2));
            points[0] = new Point(2, 1);
            points.RemoveAt(2);

            Console.WriteLine();
            Console.WriteLine(new string('=', 40));
            Console.WriteLine();

            // Functional programming section            

            Func<Point, bool> AtOrigin = (p) =>
            {
                return p.X == 0 && p.Y == 0;
            };

            Console.WriteLine($"The points list contains a point at the origin: {points.Any(AtOrigin)}");

            Console.WriteLine();
            Console.WriteLine(new string('=', 40));
            Console.WriteLine();

            foreach (Point p in points.Where(PointList.InFirstQuadrant))
            {
                Console.WriteLine($"Point {p} is in the first quadrant.");
            }

            Console.WriteLine();
            Console.WriteLine(new string('=', 40));
            Console.WriteLine();

            Func<Point, bool> BothNegative = (p) =>
            {
                return p.X < 0 && p.Y < 0;
            };

            Console.WriteLine($"The points list contains only points in the third quadrant: {points.All(BothNegative)}");

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to quit...");
            Console.ReadLine();
        }
    }
}
