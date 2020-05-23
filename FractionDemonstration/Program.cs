using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionDemonstration
{
//Зиновьев Александр Алексеевич
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Данная программа демонстрирует возможности класса дробей");

                Console.WriteLine("Введите числитель первой дроби:");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите знаменатель первой дроби:");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите числитель второй дроби:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите знаменатель второй дроби:");
                int y = Convert.ToInt32(Console.ReadLine());


            Fraction one = new Fraction(a, b);
            Fraction two = new Fraction(x, y);

            Console.WriteLine("Результат сложения: ");
            Fraction three = Fraction.Sum(one, two);
            Console.WriteLine(three.n + "/" + three.m);

            Console.WriteLine("Результат вычитания: ");
            three = Fraction.Subtract(one, two);
            Console.WriteLine(three.n + "/" + three.m);

            Console.WriteLine("Результат умножения: ");
            three = Fraction.Multiple(one, two);
            Console.WriteLine(three.n + "/" + three.m);

            Console.WriteLine("Результат деления: ");
            three = Fraction.Divide(one, two);
            Console.WriteLine(three.n + "/" + three.m);

            Console.ReadLine();

        }
    }
}
