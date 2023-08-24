using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZS
{
    class Program
    {
        static double f(double X)
        {
            double fx;
            fx = X * Math.Sin(X) + 2 * Math.Cos(X);
            return fx;
        }
        static void Main(string[] args)
        {
            double x, a, b, y, z;
            int i = 0;
            a = -6;
            b = -4;
            double k = (3 - Math.Sqrt(5)) / 2;
            double eps = Convert.ToDouble(Console.ReadLine());
            while (true)
            {
                y = a + k * (b - a);
                z = a + b - y;
                if (f(y) <= f(z))
                {
                    b = z;
                    y = a + b - y;
                    z = y;
                }
                else if (f(y) > f(z))
                {
                    a = y;
                    y = z;
                    z = a + b - z;
                }
                x = (a + b) / 2;
                i++;
                if (Math.Round(Math.Abs(b - a), 10, MidpointRounding.ToEven) <= eps)
                {
                    Console.WriteLine($"Значение x = {x}");
                    Console.WriteLine($"Значение функции при = {f(x)}");
                    Console.WriteLine($"Количество итераций при точности {eps} = {i}");
                    Console.WriteLine($"Количество вычислений при точности {eps} = {i * 2}");
                    break;
                }
            }
            Console.ReadKey(true);
            Console.ReadKey();
            Console.ReadLine();
        }
    }
}
