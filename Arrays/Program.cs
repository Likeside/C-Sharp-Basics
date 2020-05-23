using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
//Зиновьев А.А.
//2. а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив заданной размерности и заполняющий 
//        массив числами от начального значения с заданным шагом.Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse,
//        меняющий знаки у всех элементов массива, метод Multi, умножающий каждый элемент массива на определенное число, свойство MaxCount, 
//        возвращающее количество максимальных элементов.В Main продемонстрировать работу класса.

    class OwnArray
    {
        int[] a;

        public int this[int index]
        {
            get
            {
                return a[index];
            }
        }

        //Конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом
        public OwnArray (int length, int start, int step, string filler)
        {
            a = new int[length];
            a[0] = start;
            for (int i = 1; i < a.Length; i++)
            {
                a[i] += a[0] + step*i;  
            }
        }


        public OwnArray (int length)
        {
            a = new int[length];
        }

        public OwnArray (int length, int min, int max): this (length)
        {
            Random random = new Random();
            for (int i = 0; i <a.Length; i++)
            {
                a[i] = random.Next(min, max + 1);
            }

        }

        public OwnArray (string filename)
        {
            if (File.Exists(filename)== false)
            {
                a = new int[10];
                return;
            }
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(filename);
                string s = sr.ReadLine();
                int length = int.Parse(s);
                a = new int[length];
                for (int i = 0; i < length; i++)
                {
                    s = sr.ReadLine();
                    a[i] = int.Parse(s);
                }
 
            }
            catch (Exception ex)
            {
                a = new int[10];
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        public void WriteToFile (string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(a.Length);
            foreach (int element in a)
            {
                sw.WriteLine(element.ToString());
            }
            sw.Close();
        }

        public override string ToString()
        {
            string s = "";
            foreach (int element in a)
            {
                s += element.ToString() + " ";
            }

            return s;
        }


        public int SumEven()
        {
            int s = 0;
            foreach (int element in a)
            {
                if (element % 2 == 0)
                {
                    s += element;
                }

            }
            return s;
        }

        //Cвойство Sum, которые возвращают сумму элементов массива
        public int Sum 
        {
            get
            {
                int sum = 0;
                foreach (int element in a)
                {
                    sum += element;
                }
                return sum;
            }
        }


        //Метод Inverse, меняющий знаки у всех элементов массива
        public void Inverse()
        {
            for (int i = 0; i < a.Length; i ++)
            {
                a[i] = -a[i];
            }
        }

        //Метод Multi, умножающий каждый элемент массива на определенное число
        public void Multi(int multiplier)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = a[i] * multiplier;
            }
        }

        //Свойство MaxCount, возвращающее количество максимальных элементов
        public int MaxCount
        {
            get
            {
                int maxelement = a[0];
                int counter = 0;

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > maxelement)
                    {
                        maxelement = a[i];
                    }

                }

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == maxelement)
                        counter++;
                }


                    return counter;
            }
        }

    }






    class Program
    {
        static void Main(string[] args)
        {
            OwnArray arr = new OwnArray(10, 1, 2, "строка-филлер(так как параметры конструктора иначе дублируются с другим конструктором)");

            Console.WriteLine("Созданный массив: " + arr.ToString());
            Console.WriteLine("Сумма элементов массива: " + arr.Sum.ToString());
            arr.Inverse();
            Console.WriteLine("Инверсированный массив: " + arr.ToString());
            arr.Multi(5);
            Console.WriteLine("Массив, умноженный на 5: " + arr.ToString());
            Console.WriteLine("Количество максимальных элементов массива: " + arr.MaxCount.ToString());


            Console.ReadLine();
            
        }
    }
}
