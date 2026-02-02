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
            PersonList list = new PersonList();

            Console.WriteLine("Генерация начальных данных");

            for (int i = 0; i < 7; i++)
            {
                list.Add(PersonGenerator.GetRandomPerson());
            }

            Pause("Показать начальное состояние");
            PrintPersonList(list, "Список ");

            Pause("Определить типа четвертого человека");
            if (list.Count() > 3)
            {
                var fourthPerson = list.GetByIndex(3);
                string typeName = fourthPerson is Adult ? "Взрослый" : "Ребенок";
                Console.WriteLine($"Тип четвертого человека: {typeName}");

                switch (fourthPerson)
                {
                    case Adult adult:
                        {
                            Console.WriteLine($"Демонстрация свойства: Место работы - " +
                                $"{adult.Workplace}");
                            break;
                        }
                    case Child child:
                        {
                            Console.WriteLine($"Демонстрация совйства: Место учебы - " +
                                $"{child.Study}");
                            break;
                        }
                }
            }

            Pause("Очистить Список");
            list.Clear();
            PrintPersonList(list, "Список (очищен)");
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
