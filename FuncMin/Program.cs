using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace FuncMin
{
    //Зиновьев А.А.
   /* 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
      а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
      б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
   */
    public delegate double Function(double x);
    class Program
    {

        //Функции
        public static double Sinus(double x)
        {
            return Math.Sin(x);
        }

        public static double Cosinus(double x)
        {
            return Math.Cos(x);
        }

        public static double Tangens(double x)
        {
            return Math.Tan(x);
        }

        public static double Cotangens(double x)
        {
            return 1.0 / Math.Tan(x);
        }

        public static double SomeFunc(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static void SaveFunc(Function F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        static void Main(string[] args)
        {
            //Создаем список функций (делегатов)
            List<Function> functionlist = new List<Function>();
            Function Sinus1 = new Function(Sinus);
            Function Cosinus1 = new Function(Cosinus);
            Function Tangens1 = new Function(Tangens);
            Function Cotangens1 = new Function(Cotangens);
            functionlist.Add(Sinus1);
            functionlist.Add(Cosinus1);
            functionlist.Add(Tangens1);
            functionlist.Add(Cotangens1);

            //Создаем пустой делегат. Запрашиваем у пользователя цифру пункта меню, в зависимости от выбранного пункта присваиваем делегату значение (одну из функций/делегатов)
            Function F = null;
            Console.WriteLine("Выберите функцию, минимум которой на заданном отрезке Вы хотите подсчитать");
            Console.WriteLine("1 - Синус");
            Console.WriteLine("2 - Косинус");
            Console.WriteLine("3 - Тангенс");
            Console.WriteLine("4 - Котангенс");

            //Проверка корректности значений с помощью TryParse
            bool m = true;
            int menu = 1;
            do
            {
                if (m == false || menu < 1 || menu > 4)
                {
                    Console.WriteLine("Введены недопустимые значения");
                }
                m = int.TryParse(Console.ReadLine(), out int result);
                menu = result;
               
            } while (m == false || menu <1 || menu > 4);


            switch (menu) {
                case 1: F = functionlist[0];
                    break;
                case 2:
                    F = functionlist[1];
                    break;
                case 3:
                    F = functionlist[2];
                    break;
                case 4:
                    F = functionlist[3];
                    break;
            }


            Console.WriteLine("Введите Х-координату начала отрезка");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите Х-координату конца отрезка");
            double x2 = Convert.ToDouble(Console.ReadLine());

            SaveFunc(F, "data.bin", x1, x2, 0.1);
            Console.WriteLine("Минимальное значение функции на заданном отрезке:");
            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();
        }
    }
}

