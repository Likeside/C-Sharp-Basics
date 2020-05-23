using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsDelegate
{
    //Зиновьев А.А.
   //1. Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double, double). Продемонстрировать работу на функции с функцией a* x^2 и функцией a* sin(x).
    delegate double Function(double x1, double x2);
    class Program
    {
        public static void Table(Function F, double a1, double a2, double b, double h)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (a1<=b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", a1, F?.Invoke(a1, a2));
                a1 += h;
            }
            Console.WriteLine("---------------------");
        }



        public static double ASinus(double a1, double a2)
        {
            return a2 * Math.Sin(a1);
        }

        public static double ExpFun (double a1, double a2)
        {
            return a2 * Math.Pow(a1,2);
        }
        static void Main(string[] args)
        {
          


            Function ASinusfun = new Function(ASinus);
            
            Table(ASinusfun, 1, 2, 3, 1);
            Table(ExpFun, 1, 2, 3, 1);
            Console.ReadKey();

        }
    }
}
