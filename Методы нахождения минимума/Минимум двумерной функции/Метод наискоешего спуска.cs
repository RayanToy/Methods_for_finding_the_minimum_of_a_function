using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        static double f(double X1, double X2)
        {
            double fx;
            fx = 194 * Math.Pow(X1, 2) + 376 * X1 * X2 + 194 * Math.Pow(X2, 2) + 31 * X1 - 229 * X2 + 4;
            return fx;
        }
        static double grad1(double X1, double X2)
        {
            double gradX1;
            gradX1 = 388 * X1 + 376 * X2 + 31;
            return gradX1;
        }
        static double grad2(double X1, double X2)
        {
            double gradX2;
            gradX2 = 376 * X1 + 388 * X2 - 229;
            return gradX2;
        }
        static double ff(double tk, double x1, double x2)
        {
            return f(x1 - tk * grad1(x1, x2), x2 - tk * grad2(x1, x2));
        }
        static double min(double eps, double a, double b, double x1, double x2)
        {
            double x = 0;
            double y1, y2, x11, x22;
            while (Math.Abs(b - a) > eps)
            {
                x11 = b - (b - a) / 1.618;
                x22 = a + (b - a) / 1.618;
                y1 = ff(x1, x2, x11);
                y2 = ff(x1, x2, x22);
                if (y1 >= y2)
                {
                    a = x11;
                }
                else
                {
                    b = x22;
                }
                x = (a + b) / 2;
            }
            return x;
        }
        static void Main(string[] args)
        {
            double a = 0.2;
            double b = 0;
            double x1, x2;
            x1 = 0;
            x2 = 0;
            double x1pred, x2pred;
            double M = 20000;
            double eps1 = Convert.ToDouble(Console.ReadLine());
            double eps2 = Convert.ToDouble(Console.ReadLine());
            int k = 0;
            double tk = 0.1;
            while (true)
            {
                if (Math.Sqrt(Math.Pow(grad1(x1, x2), 2) + Math.Pow(grad2(x1, x2), 2)) < eps1)
                {
                    Console.WriteLine($"Значения x1 = {x1}, x2 = {x2}");
                    Console.WriteLine($"Значение функции при = {f(x1, x2)}");
                    Console.WriteLine($"Количество итераций при точности {eps1} = {k}");
                    Console.WriteLine($"Количество вычислений при точности {eps1} = {k}");
                    break;

                }
                if (k >= M)
                {
                    Console.WriteLine($"Значения x1 = {x1}, x2 = {x2}");
                    Console.WriteLine($"Значение функции при = {f(x1, x2)}");
                    Console.WriteLine($"Количество итераций при точности {eps1} = {k}");
                    Console.WriteLine($"Количество вычислений при точности {eps1} = {k}");
                    break;
                }
                tk = min(eps1, a, b, x1, x2);
                x1pred = x1;
                x2pred = x2;
                x1 = x1 - tk * grad1(x1, x2);
                x2 = x2 - tk * grad2(x1, x2);
                if (f(x1, x2) - f(x1pred, x2pred) < 0)
                {
                    if (Math.Sqrt(Math.Pow((x1 - x1pred), 2) + Math.Pow((x2 - x2pred), 2)) < eps1 && Math.Abs(f(x1, x2) - f(x1pred, x2pred)) < eps2)
                    {
                        Console.WriteLine($"Значения x1 = {x1}, x2 = {x2}");
                        Console.WriteLine($"Значение функции при = {f(x1, x2)}");
                        Console.WriteLine($"Количество итераций при точности {eps1} = {k}");
                        Console.WriteLine($"Количество вычислений при точности {eps1} = {k}");
                        break;
                    }
                }
                k++;
            }
            Console.ReadKey(true);
            Console.ReadKey();
            Console.ReadLine();

        }
    }
