using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TickTackToe
{
    /*Зиновьев А.А.
    Крестики-нолики.
    Возникли сложности с выведением массива на экран построчно, возможно, использовал не самый рациональный способ.
    Игра проверяет 4 условия победы. Если строка, столбец, диагональ от [0,0] до [2,2] или диагональ от [2,0] до [0,2] равны "ххх" или "000" - выводит на экран слово "Победа".
    Если было сделано 9 ходов, но не был определен победитель - выводит слово "Ничья". */
    class Program
    {
        static void Main(string[] args)
        {
            //Задаем игровое поле - двумерный массив 3х3
            string[,] playField = new string[3, 3];


            //Заполняем его точками 
            for (int a = 0; a < playField.GetLength(0); a++)
            {
                for (int b = 0; b < playField.GetLength(1); b++)
                {
                    playField[a, b] = ".";
                }
            }

            Console.WriteLine("Поле для игры в крестики-нолики:");

            //Функция выводит одну строку массива на экран
            void ShowPlayFieldString (int a, int b)
            {
                int stringCounter;
                for (stringCounter = a, b = 0; b < playField.GetLength(1); b++)
                {
                    Console.Write(playField[a, b] + "  ");
                }
                Console.WriteLine("\n");
            }


            //Функция выводит каждую строку массива на экран
            void ShowPlayField()
            {
                for (int a = 0; a < playField.GetLength(0); a++)
                {
                    ShowPlayFieldString(a, 0);
                }
            }
            ShowPlayField();

            //Создаем строковую переменную, которая хранит либо крестик, либо нолик, в зависимости от того, какое значение имеет переменная flag типа bool
         
                string ticktack;
                bool flag = true;

            //Функция запрашивает у пользователя номер строки и номер столбца, где он хочет поставить крестик или нолик, устанавливает его в качестве элемента массива,
            //потом меняет значение крестика/нолика и показывает игровое поле
            void SetTickTack ()
            {
                if (flag == true)
                {
                    ticktack = "x";
                }
                else
                {
                    ticktack = "0";
                }

                try
                {
                    Console.WriteLine("Введите номер строки, в который хотите поставить " + ticktack);
                    int stroka = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine("Введите номер столбца, в который хотите поставить " + ticktack);
                    int stolbets = Convert.ToInt32(Console.ReadLine()) - 1;

                    //проверяем, что введены подходящие значения
                    if (stroka < 0 || stroka > 2 || stolbets < 0 || stolbets > 2)
                    {
                        Console.WriteLine("Введены недопустимые значения");
                        SetTickTack();
                    }
                    //Проверяем, что место не занято
                    else if (playField[stroka, stolbets] == "x" || playField[stroka, stolbets] == "0")
                    {
                        Console.WriteLine("Введены недопустимые значения");
                        SetTickTack();
                    }
                    else
                    {
                        playField[stroka, stolbets] = ticktack;
                        ShowPlayField();
                        flag = !flag;

                    }
                }
                catch
                {
                    //Ловим исключения, если введены не целочисленные значения
                    Console.WriteLine("Введены недопустимые значения");
                    SetTickTack();
                }


            }

            //Счётчик, для того, чтобы отслеживать ничью (если равен 9 и при этом никто не победил - будет ничья)
            int drawCounter = 0;
            //Переменная для отслеживания победы
            bool win = false;
            //Функция, возвращающая строку из элементов массива в одной строке. 
            string CheckWinStroka (int a, int b)
            {
                int stringCounter;
                string checkwin = "";
                for (stringCounter = a, b = 0; b < playField.GetLength(1); b++)
                {
                    checkwin += playField[a, b];
                }
                return checkwin;
            }
            //Функция, возвращающая строку из элементов массива в одном столбце
            string CheckWinStolbets(int a, int b)
            {
                int stringCounter;
                string checkwin = "";
                for (stringCounter = b, a = 0; a < playField.GetLength(1); a++)
                {
                    checkwin += playField[a, b];
                }
                return checkwin;
            }

            //Функция проверяет, равна ли "диагональ" массива от элемента [0,0] до [2,2] = "xxx" или "000"
            bool CheckWinDiagonal1 ()
            {
                string checkwin = "";
                for (int a = 0; a < playField.GetLength(0); a++)
                {
                    checkwin += playField[a, a];
                }
                if (checkwin == "000" || checkwin == "xxx")
                {
                    win = true;
                }
                return win;
            }

            //Функция проверяет, равна ли "диагональ" массива от элемента [0,2] до [2,0] = "xxx" или "000"
            bool CheckWinDiagonal2()
            {
                string checkwin = "";
                for (int a = 0, b = 2; a < playField.GetLength(0) && b >=0; a++, b--)
                {

                        checkwin += playField[a, b];

                }

                if (checkwin == "000" || checkwin == "xxx")
                {
                    win = true;
                }
                return win;
            }

            //Функция, проверяющая, равна ли какая-либо строка массива = "xxx" или "000"
            bool CheckWin1 ()
            {
                for (int a = 0; a < playField.GetLength(0); a++)
                {
                    if (CheckWinStroka(a, 0) == "xxx" || CheckWinStroka(a,0) == "000")
                    {
                        win = true;
                    }
                     
                }
                return win;
            }

            //Функция, проверяющая, равен ли какой-либо столбец массива = "xxx" или "000"
            bool CheckWin2 ()
            {
                for (int b = 0; b < playField.GetLength(1); b++)
                {
                    if (CheckWinStolbets(0, b) == "xxx" || CheckWinStolbets(0, b) == "000")
                    {
                        win = true;
                    }

                }
                return win;
            }

            //Сама игра - цикл, проверяющий на каждом этапе, не равна ли перменная win = true;
            do
            {
                SetTickTack();
                drawCounter++;
                CheckWin1();
                CheckWin2();
                CheckWinDiagonal1();
                CheckWinDiagonal2();
            } while
            (drawCounter < 9 && win == false);

            if (win == true)
            {
                Console.WriteLine("Победа");
            }
            if (drawCounter == 9 && win == false)
            {
                Console.WriteLine("Ничья");
            }



            Console.ReadLine();


        }
    }
}
