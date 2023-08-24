using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
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

            double xk;
            double a = -6;
            double b = -4;
            double eps = Convert.ToDouble(Console.ReadLine());
            while (true)
            {
                xk = (a + b) / 2;
                if (f(xk) < 0)
                {
                    a = xk;
                }
                else
                {
                    b = xk;
                }
                if ((Math.Abs(b - a) < eps))
                {
                    Console.WriteLine($"Значение x = {xk}");
                    Console.WriteLine($"Значение функции при = {F(xk)}");
                    break;
                }
                Console.ReadKey(true);
                Console.ReadKey();
                Console.ReadLine();
            }
        }
    }
}
