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
            PersonList list2 = new PersonList();

            Console.WriteLine("Генерация начальных данных");

            // Заполняем list1 тремя случайными персонами
            for (int i = 0; i < 3; i++)
            {
                list1.Add(PersonGenerator.GetRandomPerson());
            }

            // Заполняем list2 тремя случайными персонами
            for (int i = 0; i < 3; i++)
            {
                list2.Add(PersonGenerator.GetRandomPerson());
            }

            // Выводим исходное состояние
            Pause("показать начальное состояние");
            PrintPersonList(list1, "Список 1");
            PrintPersonList(list2, "Список 2");

            // Добавляем нового человека в первый список
            Pause("добавить нового человека в Список 1");
            list1.Add(new Adult("Ольга", "Смирнова", 27, Gender.Female,
                "1234 123456", "TPU", null));
            PrintPersonList(list1, "Список 1 (после добавления)");

            // Копируем второго человека из первого списка в конец второго
            Pause("скопировать 2-го человека из Списка 1 в Список 2");
            PersonBase personToCopy = list1.GetByIndex(1);
            list2.Add(personToCopy);
            PrintPersonList(list1, "Список 1 (после копирования)");
            PrintPersonList(list2, "Список 2 (после копирования)");

            // Удаляем второго человека из первого списка
            Pause("удалить 2-го человека из Списка 1");
            list1.RemoveAt(1); // Удаляем по индексу
            PrintPersonList(list1, "Список 1 (после удаления)");
            PrintPersonList(list2, "Список 2 (остался без изменений)");

            // Очищаем второй список
            Pause("очистить Список 2");
            list2.Clear();
            PrintPersonList(list2, "Список 2 (очищен)");
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
