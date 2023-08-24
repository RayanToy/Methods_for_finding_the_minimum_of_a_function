
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
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
        static double ff(double X)
        {
            double fx;
            fx = -X * Math.Sin(X);
            return fx;
        }
        static void Main(string[] args)
        {

            double x, i, dx;
            x = -5;
            dx = F(x);
            i = 0;
            double eps = Convert.ToDouble(Console.ReadLine());
            while ((Math.Abs(F(x)) > eps))
            {
                x = x - dx / ff(x);
                i++;
                dx = f(x);
                if (Math.Round(Math.Abs(f(x)), 10, MidpointRounding.ToEven) <= eps)
                {
                    Console.WriteLine($"Значение x = {x}");
                    Console.WriteLine($"Значение функции при = {F(x)}");
                    Console.WriteLine($"Количество итераций при точности {eps} = {i}");
                    Console.WriteLine($"Количество вычислений при точности {eps} = {i}");
                    break;
                }
            }
            Console.ReadKey(true);
            Console.ReadKey();
            Console.ReadLine();
        }
    }
}
