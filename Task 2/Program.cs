using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    //2. Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h* h); где m — масса тела в килограммах, h — рост в метрах
    //Зиновьев Александр Алексеевич
    class Program
    {
        static void Main(string[] args)
        {
            void showImt () {
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
                }
                catch
                {
                    Console.WriteLine("Введены недопустимые значения");
                }
                finally
                {
                    showImt();
                }
            }
            showImt();
        }
    }
}
