using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    class PhoneBook
    {
        public Dictionary<int, string> book;

        public PhoneBook()
        {
          book = new Dictionary<int, string>();
        }

        /// <summary>
        /// Метод поиска владельца телефона по номеру, если владелец не найден, то ввыводит о сообщение об этом
        /// </summary>
        /// <param name="number">Номер по которому осуществялем поиск</param>
        /// <returns>Возвращает имя пользователя</returns>
        public string FindOwnre(int number)
        {
            string name;
            if (!book.TryGetValue(number, out name))
            {
                Console.WriteLine("Пользователь с таким номером не зарегистрирован");
            }
            return name;
        }

        /// <summary>
        /// Метод дял вывода в консоль всего словаря
        /// </summary>
        public void PrintToConsolePhoneBook()
        {
            foreach (KeyValuePair<int,string> e in book)
            {
                Console.WriteLine($"Номер {e.Key} принадлежит {e.Value}");
            }
               
        }
    }
}
