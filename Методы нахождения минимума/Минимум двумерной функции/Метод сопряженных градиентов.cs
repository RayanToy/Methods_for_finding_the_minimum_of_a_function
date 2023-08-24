using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
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
        static void Main(string[] args)
        {
            double t = 0;
            double x1, x2;
            x1 = 0;
            x2 = 0;
            double x1pred, x2pred;
            int M = 10000;
            int j = 0;
            int n = 2;
            double eps1 = Convert.ToDouble(Console.ReadLine());
            double eps2 = Convert.ToDouble(Console.ReadLine());
            int k = 0;
            double tk = 0.01;
            while (true)
            {
                if (j >= M)
                {
                    Console.WriteLine($"Значения x1 = {x1}, x2 = {x2}");
                    Console.WriteLine($"Значение функции при = {f(x1, x2)}");
                    Console.WriteLine($"Количество итераций при точности {eps1} = {t}");
                    Console.WriteLine($"Количество вычислений при точности {eps1} = {j + t}");
                    break;
                }
                else
                {
                    k = 0;
                }
                if (k <= n - 1)
                {
                    if (Math.Sqrt(Math.Pow(grad1(x1, x2), 2) + Math.Pow(grad2(x1, x2), 2)) < eps1)
                    {
                        Console.WriteLine($"Значения x1 = {x1}, x2 = {x2}");
                        Console.WriteLine($"Значение функции при = {f(x1, x2)}");
                        Console.WriteLine($"Количество итераций при точности {eps1} = {t}");
                        Console.WriteLine($"Количество вычислений при точности {eps1} = {j + t}");
                        break;
                    }
                    else
                    {
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
                                Console.WriteLine($"Количество итераций при точности {eps1} = {t}");
                                Console.WriteLine($"Количество вычислений при точности {eps1} = {j + t}");
                                break;
                            }
                            else
                            {
                                k++;
                            }
                        }
                        else
                        {
                            tk = tk / 2;
                        }
                    }
                }
                else if (k == n)
                {
                    j++;
                }
                t++;
            }
            Console.ReadKey(true);
            Console.ReadKey();
            Console.ReadLine();
        }
    }
}
