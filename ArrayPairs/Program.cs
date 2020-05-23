using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPairs
{
    //Зиновьев А.А.
    /*1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
     * Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.
     * В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] Arr = new int[20];

            /*
             Не работает данный код (i не увеличивается), не могу понять, почему
              
             foreach (int i in Arr)
             {
             Arr[i] = random.Next(-10000, 10001);
             }
             */

            Console.WriteLine("Сформированный массив:");
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = random.Next(-10000, 10001);
                Console.WriteLine(Arr[i].ToString());
            }

            int counter = 0;

            for (int i = 1; i < Arr.Length; i++)
            {   
                if (Arr[i]%3 == 0 || Arr[i-1]%3 == 0)
                {
                    counter++;
                }
            }
           
            Console.WriteLine("Количество пар элементов массива, в которых хотя бы одно из чисел делится на три без остатка: " + counter.ToString());
            Console.ReadLine();

        }
    }
}
