using System;

namespace _07.AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;

            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                area = side * side;
            }
            else if (figure == "rectangle")
            {
                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                area = lenght * width;
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                area = Math.PI * radius *radius;
            }
            else if (figure == "triangle")
            {
                double lenght = double.Parse(Console.ReadLine());
                double hight = double.Parse(Console.ReadLine());
                area = lenght * hight / 2;
            }
            Console.WriteLine($"{area:F3}");
        }
    }
}
