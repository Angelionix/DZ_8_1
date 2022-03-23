using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Homework_8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            int choise = 0;
            do
            {
                Console.WriteLine("Добрый день выберите пункт");
                Console.WriteLine("1.Task 1\n2.Task 2\n3.Task 3\n4.Task 4\n5.Exit");
                choise = SafeInputing(1, 5);

                switch (choise)
                {
                    case 1:
                        #region Task 1
                        List<int> numbers = new List<int>();
                        int count = 100;
                        int min = 25;
                        int max = 50;
                        Zadanie1 zadanie1 = new Zadanie1();
                        zadanie1.ListFiller(count, numbers);
                        zadanie1.PrintToConsole(numbers);

                        Console.ReadLine();

                        zadanie1.Syatel(min, max, numbers);
                        zadanie1.PrintToConsole(numbers);
                        Console.ReadLine();
                        #endregion
                        break;
                    case 2:
                        #region Task 2
                        bool isExit = false;
                        bool t = true;
                        bool isSearching = true;
                        int number = 0;
                        string name = string.Empty;
                        PhoneBook pb = new PhoneBook();

                        do
                        {
                            Console.WriteLine("Введите пожалуйста Имя");
                            do
                            {
                                name = Console.ReadLine();
                                if (name == "")
                                {
                                    isExit = true;
                                    break;
                                }
                                else
                                {
                                    t = false;
                                }
                            } while (t);

                            if (isExit)
                            {
                                break;
                            }
                            Console.WriteLine("Введите пожалуйста номер от 100000 до 999999999");
                            number = SafeInputing(100000, 999999999);
                            if (pb.book.ContainsKey(number))
                            {
                                Console.WriteLine("У номера может быть только один владелец");
                            }
                            else
                            {
                                pb.book.Add(number, name);
                            }
                        }
                        while (!isExit);
                        if (pb.book.Count == 0)
                        {
                            Console.WriteLine("К сожаленю вы не добавили не одного номера, всего доброго");
                            Console.ReadLine();
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Давайте найдем владельца номера, укажите номер телефона");

                                number = SafeInputing(100000, 999999999);
                                Console.Write(pb.FindOwnre(number));

                                Console.WriteLine("\n Хотите провести еще один поиск?\n1.Да\n2.Нет");
                                if (SafeInputing(1,2)==2)
                                {
                                    isSearching = false;
                                }
                            } while (isSearching);

                            Console.WriteLine("Спасибо за пользование нашими авиалиниями");
                        }
                        #endregion
                        break;
                    case 3:
                        #region Task 3
                        HashSet<int> coll = new HashSet<int>();
                        bool goOut = true;
                        bool notCorrect = true;

                        do
                        {
                            Console.WriteLine("Введите пожалуйста новое число");
                            do
                            {
                                if (int.TryParse(Console.ReadLine(), out number))
                                {
                                    if (!coll.Add(number))
                                    {
                                        Console.WriteLine("Это число уже вводилось попробуйте ввести новое");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Число успешно соранено");
                                        notCorrect = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Введите пожалуйста число, а не какой либо иной символ");
                                }
                            } while (notCorrect);

                            Console.WriteLine("Если хотиете продолжить просто нажмите ентер");
                            if (Console.ReadLine() != "")
                            {
                                goOut = false;
                            }
                        } while (goOut);
                        #endregion
                        break;
                    case 4:
                        #region Task 4

                        Contact person = new Contact();

                        Console.WriteLine("Добрый день");

                        Console.WriteLine("Пожалуйста введите ФИО контакта");
                        person.FIO = Console.ReadLine();

                        Console.WriteLine("Пожалуйста введите улицу проживания");
                        person.Street = Console.ReadLine();

                        Console.WriteLine("Пожалуйста введите номер дома");
                        person.HomeNumber = SafeInputing(1, 1000);

                        Console.WriteLine("Пожалуйста введите номер квартиры");
                        person.Apartment = SafeInputing(1, 1000);

                        Console.WriteLine("Пожалуйста введите номер мобильного телефона");
                        person.MobileNUmber = SafeInputing(10000000000, 999999999999);

                        Console.WriteLine("Пожалцуйста введите домашний номер телефона");
                        person.HomePhoneNumber = SafeInputing(10000, 999999999);

                        ContactXMLSerializer(person);
                        #endregion
                        break;
                    case 5:
                        Console.WriteLine("Good Bye!");
                        isWorking = false;
                        break;
                }
            } while (isWorking);
        }

        /// <summary>
        /// Метод для сериализации в xml даныых контакта
        /// </summary>
        /// <param name="contact"> Экземпляр типа контакт, хранящий в себе данные</param>
        public static void ContactXMLSerializer(Contact contact)
        {
            XElement person = new XElement("Person");
            XElement address = new XElement("Address");
            XElement phones = new XElement("Phones");
            XElement street = new XElement("Street");
            XElement homeNumber = new XElement("HouseNumber");
            XElement flatNumber = new XElement("FlatNumber");
            XElement mobileNumber = new XElement("MobilePhone");
            XElement homePhoneNumber = new XElement("FlatPhone");

            XAttribute name = new XAttribute("name", contact.FIO);
            person.Add(name);

            address.Add(street, contact.Street);
            address.Add(homeNumber, contact.HomeNumber);
            address.Add(flatNumber, contact.Apartment);
            person.Add(address);

            phones.Add(mobileNumber, contact.MobileNUmber);
            phones.Add(homePhoneNumber, contact.HomePhoneNumber);
            person.Add(phones);

            person.Save("_contact.xml");
        }

        /// <summary>
        ///  Метод для безопасного ввода числа
        /// </summary>
        /// <param name="min">мин значение</param>
        /// <param name="max">макс значение</param>
        /// <returns>чилсо типа int </returns>
        public static int SafeInputing(int min, int max)
        {
            bool correctAnswer = true;
            int choise = 0;
            do                                                                                                      // защищенны ввод того как будем вводить данные для рассчетов
            {                                                                                                       //
                if (int.TryParse(Console.ReadLine(), out choise))                                                   // Чекаем что ввели число, а не другой символ
                {                                                                                                   //
                    if (choise < min || choise > max)                                                                   // Чекаем что чило в корректном диапазоне
                    {                                                                                               //
                        Console.WriteLine($"Пожалуйста введите число от {min} до {max}");                                   // Если число не корректное просим ввести заново
                        correctAnswer = false;                                                                        // переменная райтасер делаем false чтобы заново запустить цикл ввода
                    }                                                                                               //
                    else                                                                                            //
                    {                                                                                               // Если число коректное, то переменной rightAnswer присваиваем true
                        correctAnswer = true;                                                                         // и идем дальше
                    }                                                                                               //
                }                                                                                                   //
                else                                                                                                //
                {                                                                                                   //
                    Console.WriteLine("Пожалуйста введите число, а не какой либо иной символ");                    // Если ввели не число просим ввести корректное чилсо 
                    correctAnswer = false;                                                                            // и запускаем цикл ввода заново
                }                                                                                                   //
            }                                                                                                       //
            while (!correctAnswer);
            return choise;
        }

        /// <summary>
        ///  Метод для безопасного ввода большиз числе в определенром интервале
        /// </summary>
        /// <param name="min">мин значение</param>
        /// <param name="max">макс значение</param>
        /// <returns>чилсо типа ulong </returns>
        public static ulong SafeInputing(ulong min, ulong max)
        {
            bool correctAnswer = true;
            ulong choise = 0;
            do                                                                                                      // защищенны ввод того как будем вводить данные для рассчетов
            {                                                                                                       //
                if (ulong.TryParse(Console.ReadLine(), out choise))                                                   // Чекаем что ввели число, а не другой символ
                {                                                                                                   //
                    if (choise < min || choise > max)                                                                   // Чекаем что чило в корректном диапазоне
                    {                                                                                               //
                        Console.WriteLine($"Пожалуйста введите число от {min} до {max}");                                   // Если число не корректное просим ввести заново
                        correctAnswer = false;                                                                        // переменная райтасер делаем false чтобы заново запустить цикл ввода
                    }                                                                                               //
                    else                                                                                            //
                    {                                                                                               // Если число коректное, то переменной rightAnswer присваиваем true
                        correctAnswer = true;                                                                         // и идем дальше
                    }                                                                                               //
                }                                                                                                   //
                else                                                                                                //
                {                                                                                                   //
                    Console.WriteLine("Пожалуйста введите число, а не какой либо иной символ");                    // Если ввели не число просим ввести корректное чилсо 
                    correctAnswer = false;                                                                            // и запускаем цикл ввода заново
                }                                                                                                   //
            }                                                                                                       //
            while (!correctAnswer);
            return choise;
        }
    }
}
