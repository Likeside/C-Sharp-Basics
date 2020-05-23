using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    //а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
    //б) * Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода;
    //Зиновьев Александр Алексеевич
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите X-координату первой точки");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите Y-координату первой точки");
            double y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите X-координату второй точки");
            double x2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите Y-координату второй точки");
            double y2 = Convert.ToDouble(Console.ReadLine());


            void CalcDistance (double a1, double a2, double b1, double b2)
            {

                double distance = (Math.Sqrt(Math.Pow(a2 - a1, 2) + Math.Pow(b2 - b1, 2)));
                Console.WriteLine("Расстояние между точками равно: {0:F2}", distance);
                Console.ReadLine();
            }

            CalcDistance(x1, x2, y1, y2);
        }
    }
}
