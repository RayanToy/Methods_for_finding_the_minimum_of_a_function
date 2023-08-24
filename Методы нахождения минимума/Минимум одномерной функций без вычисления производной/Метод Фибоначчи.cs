using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Метод_Фибоначчи
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
            double x, nye;
            double a = -6;
            double b = -4;
            double[] ch_fib = new double[5000];
            double lyambda;
            int i = 0;
            double eps = Convert.ToDouble(Console.ReadLine());
            double Fn = (Math.Abs(a - b)) / eps;
            ch_fib[0] = 1;
            ch_fib[1] = 1;
            long m;
            for (m = 2; m <= 400; m++)
            {
                ch_fib[m] = ch_fib[m - 1] + ch_fib[m - 2];
            }
            m = m - 1;
            lyambda = a + (ch_fib[m - 2] / ch_fib[m]) * (b - a);
            nye = a + (ch_fib[m - 1] / ch_fib[m]) * (b - a);
            while (true)
            {
                if (f(lyambda) > f(nye))
                {
                    a = lyambda;
                    lyambda = nye;
                    nye = a + ch_fib[m - i - 1] / ch_fib[m - i] * (b - a);
                }
                else if (f(lyambda) < f(nye))
                {
                    b = nye;
                    nye = lyambda;
                    lyambda = a + ch_fib[m - i - 2] / ch_fib[m - i] * (b - a);
                }
                x = (a + b) / 2;
                i++;
                if (Fn - 3 < i || Math.Round(Math.Abs(b - a), 10, MidpointRounding.ToEven) <= eps)
                {
                    Console.WriteLine($"Значение x = {x}");
                    Console.WriteLine($"Значение функции при = {f(x)}");
                    Console.WriteLine($"Количество итераций при точности {eps} = {i}");
                    Console.WriteLine($"Количество вычислений при точности {eps} = {i}");
                    break;
                }
                Console.WriteLine(ch_fib[i]);
            }
            Console.ReadKey(true);
            Console.ReadKey();
            Console.ReadLine();
        }
    }

}
