using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Basics
{
//1. Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку.
//а) используя склеивание;
//б) используя форматированный вывод;
//в) * используя вывод со знаком $.
//Зиновьев Александр Алексеевич

    class Program
    {
        private static string AskQuestion(string userParameter)
        {
            Console.WriteLine("Введите " + userParameter);
            string userInput = Console.ReadLine();
            return userInput;

        }
        static void Main(string[] args)
        {
            
            string name = (AskQuestion("имя"));
            string surname = (AskQuestion("фамилию"));
            string age = (AskQuestion("возраст"));
            string height = (AskQuestion("рост"));
            string weight = (AskQuestion("вес"));

            Console.WriteLine(name + " " + surname + " " + age + " " + height + " " + weight);
            Console.WriteLine("{0} {1} {2} {3} {4}", name, surname, age, height, weight);
            Console.WriteLine($"{name} {surname} {age} {height} {weight}");
            Console.ReadLine();
        }

    


    }
}
