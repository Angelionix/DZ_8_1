using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    class Zadanie1
    {
        /// <summary>
        /// Метод для заполнения списка чисел
        /// </summary>
        /// <param name="count"> количество элементов в листе</param>
        /// <param name="numbers">Сылка на сам лист </param>
        public void ListFiller( int count, List<int> numbers)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(rnd.Next(0, 101));
            }
        }

        /// <summary>
        /// Метод для вывода элементов списка на консоль
        /// </summary>
        /// <param name="numbers">Список с числами</param>
        public void PrintToConsole(List<int> numbers)
        {
            foreach (int i in numbers)
            {
                Console.Write(i+ ", ");
            }
            Console.WriteLine($"\n Лист содержит - {numbers.Count} элементов");
        }

        /// <summary>
        /// Метод для отсеивания списка в заданном интервале
        /// </summary>
        /// <param name="min">Минимум интервала</param>
        /// <param name="max">Максимум интервала</param>
        /// <param name="numbers">Список</param>
        public void Syatel(int min, int max, List<int> numbers)
        {
            int c;
            int i = 0;
            do
            {
                c = numbers[i];
                if (c >= min && c <= max)
                {
                    numbers.Remove(numbers[i]);
                }
                else
                {
                    i++;
                }
            }
            while (i < numbers.Count);
        }
    }
}
