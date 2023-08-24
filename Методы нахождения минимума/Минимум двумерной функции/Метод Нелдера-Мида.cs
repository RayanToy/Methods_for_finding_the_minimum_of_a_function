using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Program
    {
        static double f(double X1, double X2)
        {
            double fx;
            fx = 194 * Math.Pow(X1, 2) + 376 * X1 * X2 + 194 * Math.Pow(X2, 2) + 31 * X1 - 229 * X2 + 4;
            return fx;
        }
        static void Main(string[] args)
        {
            double[] x1 = new double[3];
            double[] x2 = new double[3];
            double midx1, midx2;
            double x1r, x2r, x1e, x2e, x1s, x2s;
            x1[0] = -10;
            x2[0] = 10;
            x1[2] = 20;
            x2[2] = 20;
            x1[1] = 30;
            x2[1] = 30;
            int koorbest = 0;
            int koorworst = 0;
            int koorgood = 0;
            double alpha, beta, gamma;
            alpha = 1;
            beta = 0.5;
            gamma = 2;
            double eps = Convert.ToDouble(Console.ReadLine());
            double k = 0;
            double tempx1;
            double tempx2;
            double best, worst, good;
            best = 0;
            worst = 0;
            while (true)
            {

                if (f(x1[0], x2[0]) < f(x1[1], x2[1]))
                {
                    if (f(x1[0], x2[0]) < f(x1[2], x2[2]))
                    {
                        best = f(x1[0], x2[0]);
                        koorbest = 0;
                    }
                    else
                    {
                        best = f(x1[2], x2[2]);
                        koorbest = 2;
                    }
                }
                else
                {
                    if (f(x1[1], x2[1]) < f(x1[2], x2[2]))
                    {
                        best = f(x1[1], x2[1]);
                        koorbest = 1;
                    }
                    else
                    {
                        best = f(x1[2], x2[2]);
                        koorbest = 2;
                    }
                }

                if (f(x1[0], x2[0]) > f(x1[1], x2[1]))
                {
                    if (f(x1[0], x2[0]) > f(x1[2], x2[2]))
                    {
                        worst = f(x1[0], x2[0]);
                        koorworst = 0;
                    }
                    else
                    {
                        worst = f(x1[2], x2[2]);
                        koorworst = 2;
                    }
                }
                else
                {
                    if (f(x1[1], x2[1]) > f(x1[2], x2[2]))
                    {
                        worst = f(x1[1], x2[1]);
                        koorworst = 1;
                    }
                    else
                    {
                        worst = f(x1[2], x2[2]);
                        koorworst = 2;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    if (i != koorbest && i != koorworst)
                    {
                        good = f(x1[i], x2[i]);
                        koorgood = i;
                    }
                }

                midx1 = (x1[koorgood] + x1[koorbest]) / 2;
                midx2 = (x2[koorgood] + x2[koorbest]) / 2;
                x1r = (1 + alpha) * midx1 - alpha * x1[koorworst];
                x2r = (1 + alpha) * midx2 - alpha * x2[koorworst];
                if (f(x1r, x2r) < f(x1[koorbest], x2[koorbest]))
                {
                    x1e = (1 - gamma) * midx1 + gamma * x1r;
                    x2e = (1 - gamma) * midx2 + gamma * x2r;
                    if (f(x1e, x2e) < f(x1r, x2r))
                    {
                        x1[koorworst] = x1e;
                        x2[koorworst] = x2e;
                    }
                    else
                    {
                        x1[koorworst] = x1r;
                        x2[koorworst] = x2r;
                    }
                }
                if (f(x1[koorbest], x2[koorbest]) < f(x1r, x2r) && f(x1r, x2r) < f(x1[koorgood], x2[koorgood]))
                {
                    x1[koorworst] = x1r;
                    x2[koorworst] = x2r;
                }
                if (f(x1[koorgood], x2[koorgood]) < f(x1r, x2r) && f(x1r, x2r) < f(x1[koorworst], x2[koorworst]))
                {
                    tempx1 = x1r;
                    tempx2 = x2r;
                    x1r = x1[koorworst];
                    x2r = x2[koorworst];
                    x1[koorworst] = tempx1;
                    x2[koorworst] = tempx2;
                }
                x1s = (1 - beta) * x1[koorworst] + beta * midx1;
                x2s = (1 - beta) * x2[koorworst] + beta * midx2;
                if (f(x1s, x2s) < f(x1[koorworst], x2[koorworst]))
                {
                    x1[koorworst] = x1s;
                    x2[koorworst] = x2s;
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        x1[i] = x1[koorbest] + (x1[i] - x1[koorbest]) / 2;
                        x2[i] = x2[koorbest] + (x2[i] - x2[koorbest]) / 2;
                    }
                }
                if (Math.Round(Math.Sqrt(Math.Pow((x1[koorbest] - x1[koorgood]), 2) + Math.Pow((x2[koorbest] - x2[koorgood]), 2)), 10, MidpointRounding.ToEven) <= eps && Math.Round(Math.Abs(f(x1[koorbest], x2[koorbest]) - f(x1[koorgood], x2[koorgood])), 10, MidpointRounding.ToEven) < eps && Math.Round(Math.Sqrt(Math.Pow((x1[koorgood] - x1[koorworst]), 2) + Math.Pow((x2[koorgood] - x2[koorworst]), 2)), 10, MidpointRounding.ToEven) <= eps && Math.Round(Math.Sqrt(Math.Pow((x1[koorbest] - x1[koorworst]), 2) + Math.Pow((x2[koorbest] - x2[koorworst]), 2)), 10, MidpointRounding.ToEven) <= eps)
                {
                    Console.WriteLine($"Значения x1 = {x1[koorbest]}, x2 = {x2[koorbest]}");
                    Console.WriteLine($"Значение функции при = {best}");
                    Console.WriteLine($"Значение функции при = {k}");
                    Console.WriteLine($"Количество итераций при точности {eps} = {k}");
                    Console.WriteLine($"Количество вычислений при точности {eps} = {3 * k}");
                    break;
                }
                k++;
            }
            Console.ReadKey(true);
            Console.ReadKey();
            Console.ReadLine();
        }
    }
}
