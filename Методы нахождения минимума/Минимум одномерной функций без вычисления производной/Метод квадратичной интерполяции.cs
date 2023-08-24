using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Метод_квадратичной_интерполяции
{
    class Program
    {
        static double f(double X)
        {
            return X * Math.Sin(X) + 2 * Math.Cos(X);
        }
        static double Find(double xs, double h, double eps1, double eps2, int max_step)
        {

            double[] x = new double[3];
            double[] f_x = new double[3];
            int k;
            int i_min = 0, i_max = 0;
            double xn, f_xn, a1, a2;
            xn = 0;
            //   Задаём начальную точку 
            //  Вычисляем точки x0, x1, x2
            x[0] = xs;
            x[1] = xs + h;
            if (f(x[0]) > f(x[1]))
            {
                x[2] = xs + 2 * h;
            }
            else
            {
                x[2] = xs - h;
            }
            //    Вычисляем значения функции в этих точках
            f_x[0] = f(x[0]);
            f_x[1] = f(x[1]);
            f_x[2] = f(x[2]);
            /// находим F_min = min(f1, f2, f3)
            for (k = 0; k < max_step; k++)
            {
                if (f_x[0] < f_x[1])
                {
                    if (f_x[0] < f_x[2]) i_min = 0;
                    else i_min = 2;
                }
                else
                {
                    if (f_x[1] < f_x[2]) i_min = 1;
                    else i_min = 2;
                }
                a1 = (f_x[1] - f_x[0]) / (x[1] - x[0]);
                a2 = 1.0 / (x[2] - x[1]) * ((f_x[2] - f_x[0]) / (x[2] - x[0]) - (f_x[1] - f_x[0]) / (x[1] - x[0]));
                xn = (x[1] + x[0]) * 0.5 - a1 / (2 * a2);
                f_xn = f(xn);
                //   Проверяем условия окончания. Если оба условия выполнены, то процедура окончена
                if ((Math.Abs((xn - x[i_min]) / xn) < eps1) && (Math.Abs((f_xn - f_x[i_min]) / f_xn) < eps2))
                {
                    Console.WriteLine($"Значение x = {xn}");
                    Console.WriteLine($"Значение функции при = {f(xn)}");
                    Console.WriteLine($"Количество итераций при точности {eps1} = {k}");
                    Console.WriteLine($"Количество вычислений при точности {eps1} = {k * 3}");
                    return xn;
                }
                // Выбираем наилучшую точку
                //	и две точки по обе стороны от нее. Переобозначить эти точки в порядке возрастания
                if (f_x[0] >= f_x[1])
                {

                    if (f_x[0] > f_x[2]) i_max = 0;
                    else i_max = 2;


                    if (f_x[1] > f_x[2]) i_max = 1;
                    else i_max = 2;
                }
                if (f_xn < f_x[i_min])
                {
                    x[i_max] = xn;
                    f_x[i_max] = f_xn;
                }
                else
                {
                    x[i_max] = 2 * x[i_min] - xn;
                    f_x[i_max] = f(x[i_max]);
                }
            }
            Console.WriteLine($"Значение x = {xn}");
            Console.WriteLine($"Значение функции при = {f(xn)}");
            Console.WriteLine($"Количество итераций при точности {eps1} = {k}");
            Console.WriteLine($"Количество вычислений при точности {eps1} = {k * 2}");
            return xn;
        }
        static void Main(string[] args)
        {
            double x;
            x = Find(-6, 0.5, 0.001, 0.001, 100);

            Console.ReadKey(true);
            Console.ReadKey();
            Console.ReadLine();
        }

    }
}