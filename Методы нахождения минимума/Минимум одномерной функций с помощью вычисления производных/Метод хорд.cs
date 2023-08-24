using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {

        static double F(double X)
        {
            double fx;
            fx = X * Math.Sin(X) + 2 * Math.Cos(X);
            return fx;
        }
        static double f(double X)
        {
            double fx;
            fx = X * Math.Cos(X) - Math.Sin(X);
            return fx;
        }
        static void Main(string[] args)
        {
            double a = -6;
            double b = -4;
            double xI, Xzv, i;
            i = 0;
            xI = a - f(a) / (f(a) - f(b)) * (a - b);
            double eps = Convert.ToDouble(Console.ReadLine());
            while (true)
            {
                xI = a - f(a) / (f(a) - f(b)) * (a - b);
                if (f(xI) > 0)
                {
                    b = xI;
                }
                else
                {
                    a = xI;
                }
                i++;
                if ((Math.Abs(b - a) < eps))
                {
                    Console.WriteLine($"Значение x = {xI}");
                    Console.WriteLine($"Значение функции при = {F(xI)}");
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

