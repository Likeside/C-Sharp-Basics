using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class Homework2
    {
        //Зиновьев Александр Алексеевич
        public static void Task1()
        {
            //1. Написать метод, возвращающий минимальное из трех чисел.
            

            /* Метод принимает 3 целых числа в качестве аргументов, создает из них массив, присваивает значение первого числа переменной "min",  
            сравнивает "min" с каждым числом массива с помощью цикла foreach, и если число массива меньше, чем "min" - 
            записывает его значение в "min", потом возвращает его */
            int MinValue(int a, int b, int c)
            {
                int[] Arr = { a, b, c};
                int min = a;

                foreach (int s in Arr)
                {                    
                    if (s < min)
                    {
                        min = s;
                    }
                }

                return min; 
            }

            /* Метод принимает строку в качестве аргумента (которая отвечает за вывод вопроса пользователю) и переменную, которой с помощью 
            ключевого слова "out" будет присвоено значение, которое введет пользователь */
            void AskNumber(string indexOfNumber, out int assignedToVariable)
            {
                Console.WriteLine("Введите " + indexOfNumber + " число");
                assignedToVariable = Convert.ToInt32(Console.ReadLine());
               
            }

            //Объявляем переменные, чтобы исползовать их в методе AskNumber()
            int x = 0;
            int y = 0;
            int z = 0;

            //Используем методы
            AskNumber("1-ое", out x);
            AskNumber("2-ое", out y);
            AskNumber("3-е", out z);
            Console.WriteLine("Минимальное число: " + MinValue(x, y, z));

        }

        public static void Task2()
        {
            //2.Написать метод подсчета количества цифр числа.

            // Принимаем значение от пользователя, поэтому переводим число туда-сюда

            Console.WriteLine("Введите число");
            string userInput1 = Console.ReadLine();
            int charAmount;
            long CountSymbols (string x)
            {
                long userNumber = Convert.ToInt64(x);
                charAmount = (userNumber.ToString()).Length;
                return charAmount;
            }
            CountSymbols(userInput1);
            Console.WriteLine("В числе " + charAmount + "цифр");
        }
       public static void Task3()
        {
            //3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.

            int userNumber1;
            int sum = 0;
            do
            {
                Console.WriteLine("Введите число");
                userNumber1 = Convert.ToInt32(Console.ReadLine());
               

                if (userNumber1 % 2 != 0 && userNumber1 > 0)
                    sum += userNumber1;
            } while (userNumber1 != 0);

            Console.WriteLine("Cумма чисел равна: " + sum);

        }
        public static void Task4()
        {
            //5.а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме
            void showImt()
            {
                try
                {
                    Console.WriteLine("Введите вес в килограммах");
                    string weightStr = Console.ReadLine();
                    double weightKg = Convert.ToDouble(weightStr);
                    Console.WriteLine("Введите рост в сантиметрах");
                    string heightCM = Console.ReadLine();
                    double heightM = Convert.ToDouble(heightCM) / 100;
                    double imt = weightKg / (heightM * heightM);
                    Console.WriteLine("Ваш индекс массы тела: " + imt);
                    if (imt < 25 && imt >= 19)
                    {
                        Console.WriteLine("Вы в норме(наверное)");
                    }
                    if (imt >= 25) 
                    {
                        Console.WriteLine("Вам нужно сбросить вес");
                    }
                    if (imt < 19)
                    {
                        Console.WriteLine("Вам нужно набрать вес");
                    }
                }
                catch
                {
                    Console.WriteLine("Введены недопустимые значения");
                }
                finally
                {
                    
                }
            }
            showImt();
        }

    }

    
}
