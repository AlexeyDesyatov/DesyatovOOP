using System;
using System.Reflection;
using Model;

namespace Lb1
{
    /// <summary>
    /// Точка входа в консольное приложение.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Главное тело программы.
        /// </summary>
        /// <param name="args">аргумент</param>
        public static void Main(string[] args)
        {
            PersonList list1 = new PersonList();

            Console.WriteLine("Генерация начальных данных");

            // Заполняем list1 семью случайными персонами
            for (int i = 0; i < 7; i++)
            {
                list1.Add(PersonGenerator.GetRandomPerson());
            }

            // Выводим исходное состояние
            Pause("показать начальное состояние");
            PrintPersonList(list1, "Список ");

            // Очищаем список
            Pause("очистить Список ");
            list1.Clear();
            PrintPersonList(list1, "Список (очищен)");
            Console.WriteLine("\nРабота завершена." +
                " Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// Выводит приглашение
        /// </summary>
        /// <param name="nextAction">описание дальнейшего действия</param>
        static void Pause(string nextAction)
        {
            Console.WriteLine($"\nНажмите любую клавишу," +
                $" чтобы продолжить и {nextAction}");
            Console.ReadKey();
        }

        /// <summary>
        /// Выводит содержимое списка людей в консоль.
        /// </summary>
        /// <param name="list">список людей</param>
        /// <param name="listName">название списка</param>
        public static void PrintPersonList(PersonList list, string listName)
        {
            Console.WriteLine($"\n=== {listName} ===");
            foreach (PersonBase person in list.Persons)
            {
                Console.WriteLine(person.GetInfo());
            }
        }
    }
}
