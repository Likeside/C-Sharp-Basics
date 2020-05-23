using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginCheck
{
    //Зиновьев А.А. 
//1. Создать программу, которая будет проверять корректность ввода логина.Корректным логином будет строка от 2 до 10 символов,
//содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
//а) без использования регулярных выражений;
//б) с использованием регулярных выражений.


 /*Вероятно, правильнее было реализовать через цикл do/while, а не через рекурсию, т.к. иначе выводит сообщение "логин соответствует правилам" 
  * столько раз, сколько он был введен до этого
  */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка без регулярных выражений");
            
            void AskLogin ()
            {
                string login;
                Console.WriteLine("Введите логин");
                login = Console.ReadLine();
                bool correct = true;
                //a) Проверка без регулярных выражений
                if (login.Length < 2 || login.Length > 10)
                {
                    Console.WriteLine("Ваш логин должен быть от 2-х до 10-ти символов");
                    AskLogin();
                }
                else if (Char.IsDigit(login[0]))
                {
                    Console.WriteLine("Первый символ логина не может быть цифрой");
                    AskLogin();
                }
                else
                {
                    //Проходим по каждому символу строки, проверям на соответствие таблице юникод
                    foreach (char ch in login)
                    {
                        if ((int)ch < 30 || (int)ch > 122)
                        {        
                            correct = false;
                        }
                    }
                }
                if (correct == false)
                {
                    Console.WriteLine("Допустимо вводить только латинские символы");
                    AskLogin();
                }
                else
                {
                    Console.WriteLine("Логин соответствует правилам");
                }

            }

            AskLogin();

            //Проверка с регулярными выражениями
            Console.WriteLine("Проверка с регулярными выражениями");

            void RegExLogin() {
                string login;
                Console.WriteLine("Введите логин");
                login = Console.ReadLine();


                Regex loginName = new Regex("^[a-zA-Z][a-zA-Z0-9]{2,9}");
                if (loginName.IsMatch(login))
                {
                    Console.WriteLine("Логин соответствует правилам");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Логин не соответствует правилам");
                    RegExLogin();
                }
            }

            RegExLogin();
        }
    }
}
