using LB1;
using System;

class Program
{
    static void Main(string[] args)
    {
        PersonList list1 = new PersonList();
        PersonList list2 = new PersonList();

        Console.WriteLine("Генерация начальных данных с помощью Person.GetRandomPerson()...");

        
        // Заполняем list1 тремя случайными персонами
        
        for (int i = 0; i < 3; i++)
        {
            list1.Add(Person.GetRandomPerson());
        }

        // Заполняем list2 тремя случайными персонами
        for (int i = 0; i < 3; i++)
        {
            list2.Add(Person.GetRandomPerson());
        }

        
        // Пункт b: Выводим исходное состояние
        Console.WriteLine("Нажмите любую клавишу, чтобы показать начальное состояние...");
        Console.ReadKey();
        PersonList.PrintPersonList(list1, "Список 1");
        PersonList.PrintPersonList(list2, "Список 2");

        // Пункт c: Добавляем нового человека в первый список
        Console.WriteLine("\n\nНажмите любую клавишу, чтобы добавить нового человека в Список 1...");
        Console.ReadKey();
        list1.Add(new Person("Ольга", "Смирнова", 27, Gender.Female));
        PersonList.PrintPersonList(list1, "Список 1 (после добавления)");

        // Пункт d: Копируем второго человека из первого списка в конец второго
        Console.WriteLine("\n\nНажмите любую клавишу, чтобы скопировать 2-го человека из Списка 1 в Список 2...");
        Console.ReadKey();
        Person personToCopy = list1.Index(1); // Берем 2-го человека (индекс 1)
        list2.Add(personToCopy);
        PersonList.PrintPersonList(list1, "Список 1 (после копирования)");
        PersonList.PrintPersonList(list2, "Список 2 (после копирования)");

        // Пункт e: Удаляем второго человека из первого списка
        Console.WriteLine("\n\nНажмите любую клавишу, чтобы удалить 2-го человека из Списка 1...");
        Console.ReadKey();
        list1.RemoveAt(1); // Удаляем по индексу
        PersonList.PrintPersonList(list1, "Список 1 (после удаления)");
        PersonList.PrintPersonList(list2, "Список 2 (остался без изменений)");

        // Пункт f: Очищаем второй список
        Console.WriteLine("\n\nНажмите любую клавишу, чтобы очистить Список 2...");
        Console.ReadKey();
        list2.Clear();
        PersonList.PrintPersonList(list2, "Список 2 (очищен)");
        Console.WriteLine("\n\nРабота завершена. Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}