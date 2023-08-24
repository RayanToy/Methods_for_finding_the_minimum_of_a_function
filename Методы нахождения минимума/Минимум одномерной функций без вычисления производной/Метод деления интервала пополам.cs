using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        // Минимум одномерной функции методом деления интервала пополам
        static double f(double X)
        {
            double fx;
            fx = X * Math.Sin(X) + 2 * Math.Cos(X);
            return fx;
        }
        static void Main(string[] args)
        {
            double x, y, z, i;
            i = 0;
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double eps = Convert.ToDouble(Console.ReadLine());
            while (true)
            {
                x = (a + b) / 2;
                y = (a + x) / 2;
                z = (x + b) / 2;
                if (f(y) < f(x))
                {
                    b = x;
                }
                if (f(z) < f(x))
                {
                    a = x;
                }
                if (f(y) >= f(x) && f(z) >= f(x))
                {
                    a = y;
                    b = z;
                }
                i++;
                if (Math.Round(Math.Abs(b - a), 10, MidpointRounding.ToEven) <= eps)
                {
                    Console.WriteLine($"Значение x = {x}");
                    Console.WriteLine($"Значение функции при = {f(x)}");
                    Console.WriteLine($"Количество итераций при точности {eps} = {i}");
                    Console.WriteLine($"Количество вычислений при точности {eps} = {i * 3}");
                    break;
                }
            }
            Console.ReadKey(true);
            Console.ReadKey();
            Console.ReadLine();
        }
    }
}
