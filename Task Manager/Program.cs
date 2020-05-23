using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_Manager
{
    class Program
    {
        //Зиновьев А.А.
        static int Menu()
        {
            int menuItem;
            do
            {

                Console.WriteLine("Выберете один из пунктов меню");
                Console.WriteLine("1 - Task1");
                Console.WriteLine("2 - Task2");
                Console.WriteLine("3 - Task3");
                Console.WriteLine("4 - Task4");
                Console.WriteLine("0 - Выйти из программы");
                menuItem = Convert.ToInt32(Console.ReadLine());
                
            } while (menuItem < 0 && menuItem > 3);
            return menuItem;
        }

        static void Main(string[] args)
        {
            int menu;
            do
            {
                menu = Menu();
                switch(menu)
                {
                    case 1: 
                        Homework2.Task1();
                        break;
                    case 2:
                        Homework2.Task2();
                        break;
                    case 3: 
                        Homework2.Task3();
                        break;
                    case 4:
                        Homework2.Task4();
                        break;
                    default:
                        Console.WriteLine("Завершение программы");
                        break;
                }
            } while (menu != 0);
            


        }
    }
}
