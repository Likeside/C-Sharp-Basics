using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udvoitel.Model
{
    enum StatusGame
    {
        Win, Lose, Play
    }


    delegate void Action();

    class GameDoubler
    {
        int current;
        int totalMoves;
        public Action action;

        public int Finish { get; private set; }
        Stack<int> history = new Stack<int>();


        /// <summary>
        /// Текущее число
        /// </summary>
        public int Current
        {
            get { return current; }
        }

        public int TotalMoves
        {
            get { return totalMoves; }
        }

        /// <summary>
        /// Кол-во ходов
        /// </summary>
        public int Count
        {
            get
            {
                return history.Count;
            }
        }
            

        public int Steps//минимальное кол-во шагов
        {
            get
            {
                int f = Finish;//50
                int i = 0;
                while (f != 1)
                {
                    if (f % 2 == 0) f = f / 2;
                      else f--;
                    //f = f % 2 == 0 ? f / 2 : f - 1;
                    i++;
                }
                return i;
            }
        }

        public GameDoubler(int min, int max)
        {
            Finish = new Random().Next(min, max + 1);
            current = 1;
            totalMoves = 0;
        }

        public GameDoubler()
        {
            Finish = new Random().Next(10, 101);
            current = 1;
            totalMoves = 0;
        }

        public GameDoubler(int finish)
        {
            this.Finish = finish;
            current = 1;
            totalMoves = 0;
        }


        public int Plus()
        {
            history.Push(current);
            current++;
            totalMoves++;
            action();
            return current;
        }

        public int Multi()
        {
            history.Push(current);
            current *= 2;
            totalMoves++;
            action();
            return current;
        }

        public void Reset()
        {
            current = 1;
            totalMoves++;
            action();
            history.Clear();            
        }

        public int Back()
        {
            totalMoves++;
            action();
            //if (history.Count != 0) return history.Pop(); else return 1;

            if (history.Count != 0)
            {
                current = history.Pop();
                return current;
            }
            else
            {
                return 1;
            }
        }

        public override string ToString()
        {
            return current.ToString();
        }

        
    }
}
