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
        PrintPersonList(list1, "Список 1");
        PrintPersonList(list2, "Список 2");

        // Пункт c: Добавляем нового человека в первый список
        Console.WriteLine("\n\nНажмите любую клавишу, чтобы добавить нового человека в Список 1...");
        Console.ReadKey();
        list1.Add(new Person("Ольга", "Смирнова", 27, Gender.Female));
        PrintPersonList(list1, "Список 1 (после добавления)");

        // Пункт d: Копируем второго человека из первого списка в конец второго
        Console.WriteLine("\n\nНажмите любую клавишу, чтобы скопировать 2-го человека из Списка 1 в Список 2...");
        Console.ReadKey();
        Person personToCopy = list1.Index(1); 
        list2.Add(personToCopy);
        PrintPersonList(list1, "Список 1 (после копирования)");
        PrintPersonList(list2, "Список 2 (после копирования)");

        // Пункт e: Удаляем второго человека из первого списка
        Console.WriteLine("\n\nНажмите любую клавишу, чтобы удалить 2-го человека из Списка 1...");
        Console.ReadKey();
        list1.RemoveAt(1); // Удаляем по индексу
        PrintPersonList(list1, "Список 1 (после удаления)");
        PrintPersonList(list2, "Список 2 (остался без изменений)");

        // Пункт f: Очищаем второй список
        Console.WriteLine("\n\nНажмите любую клавишу, чтобы очистить Список 2...");
        Console.ReadKey();
        list2.Clear();
        PrintPersonList(list2, "Список 2 (очищен)");
        Console.WriteLine("\n\nРабота завершена. Нажмите любую клавишу для выхода...");
        Console.ReadKey();

        // ввод - добавление в список - вывод
        Console.WriteLine("\n\nДобавим человека вручную в Список 1:");
        Person newperson = ReadFromConsole();  
        list1.Add(newperson);                     
        PrintPersonList(list1, "Список 1 (после ручного добавления)");
        Console.WriteLine("\nГотово! Нажмите любую клавишу для завершения.");
        Console.ReadKey();

    }

    /// <summary>
    /// Выводит содержимое списка людей в консоль.
    /// </summary>
    public static void PrintPersonList(PersonList list, string listName)
    {
        Console.WriteLine($"\n=== {listName} ===");
        foreach (Person person in list.Persons)
        {
            string genderStr = person.Gender switch
            {
                Gender.Male => "Мужчина",
                Gender.Female => "Женщина",
                _ => "Неизвестно"
            };

            Console.WriteLine($"Имя: {person.Name}, Фамилия: {person.Surname}," +
                              $" Возраст: {person.Age}, Пол: {genderStr}");
        }
    }

    public static Person ReadFromConsole()
    {
        var person = new Person();

        var actionDictionary = new Dictionary<string, Action>()

            {
                {
                    "имя",
                    new Action(() =>
                    {
                        person.Name = Console.ReadLine();
                    })
                },
                {
                     "фамилию",
                     new Action(() =>
                     {
                         person.Surname = Console.ReadLine();                        
                     })
                },
                {
                     "возраст",
                     new Action(() =>
                     {
                         if (int.TryParse(Console.ReadLine(), out int age))
                         {
                             person.Age = age;
                         }
                         else
                         {
                             throw new Exception("Введённая строка" +
                                 "не может быть преобразована в целое число!");
                         }
                     })
                },
                {
                     "пол (1 — Мужчина, 2 — Женщина)",
                      new Action(() =>
                      {
                          string input = Console.ReadLine();
                          switch (input)
                          {
                              case "1":
                                  person.Gender = Gender.Male;
                                  break;
                              case "2":
                                  person.Gender = Gender.Female;
                                  break;
                              default:
                                  throw new Exception("Некорректный ввод пола!" +
                                      " Введите 1 или 2.");
                          }
                      })
                }
            };

        foreach (var actionHandler in actionDictionary)
        {
            ActionHandler(actionHandler.Value, actionHandler.Key);
        }

        return person;
    }
    private static void ActionHandler(Action action, string fieldName)
    {
        while (true)
        {
            try
            {
                Console.Write($"Введите {fieldName}: ");
                action.Invoke();
                return;
            }
            catch (Exception exception)
            {
                Console.WriteLine($" Ошибка: {exception.Message}" +
                    $" Попробуйте снова.");
            }
        }
    }


}