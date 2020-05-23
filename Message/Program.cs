using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Message
{
    //Зиновьев А.А.
   /* 2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
Продемонстрируйте работу программы на текстовом файле с вашей программой.*/
    class Message
    {
        string message;

        public Message (string filename)
        {
            StreamReader sr = new StreamReader(filename);
            message = sr.ReadToEnd();
            sr.Close(); 
        }

        //public Message (string message)
        //{
        //    this.message = message;
        //}

        //а) Вывести только те слова сообщения, которые содержат не более n букв.
        public void ShowWords (int letterAmount)
        {
            string[] msg = message.Split(' ', ',', '.', ':', ';', '?', '!');

            foreach (string word in msg)
            {
                if (word.Length <= letterAmount)
                {
                    Console.WriteLine(word);
                }
            }
        }

        //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        public StringBuilder DeleteWords (char c)
        {
            string x = c.ToString();
            string[] msg = message.Split(' ', ',', '.', ':', ';', '?', '!');
            Regex rg = new Regex(x+"$");
            for (int i =0; i<msg.Length; i++)
            {
                if (rg.IsMatch(msg[i]))
                {
                    msg[i] = null;
                }
              
            }
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < msg.Length; i++)
            {
                    sb.Append(msg[i]+" ");
            }
            return sb;
        }

        //в) Найти самое длинное слово сообщения.

        public string LongestWord ()
        {
            string[] msg = message.Split(' ', ',', '.', ':', ';', '?', '!');
            string longest = msg[0];

            for (int i=0;i<msg.Length;i++)
            {
                if (msg[i].Length > longest.Length)
                {
                    longest = msg[i];
                }
            }

            return longest;
        }

        //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.

        public StringBuilder LongString ()
        {
            StringBuilder sb = new StringBuilder("");
            string[] msg = message.Split(' ', ',', '.', ':', ';', '?', '!');
            string longest = msg[0];

            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i].Length >= longest.Length)
                {
                    sb.Append(msg[i]);
                }
            }
            return sb;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Message x = new Message(@"TextFile1.txt");
            Console.WriteLine("Строка из самых длинных слов\n" + x.LongString());
            Console.WriteLine("Слова с не более, чем 5-ю буквами:");
            x.ShowWords(5);
            Console.WriteLine("Самое длинное слово сообщения\n" + x.LongestWord());
            Console.WriteLine("Удалили слова, оканчивающиеся на m\n" + x.DeleteWords('m'));
            
            Console.ReadKey();
        }
    }
}
