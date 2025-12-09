using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB1
{
    /// <summary>
    /// Хранение и обработка персональных данных
    /// </summary>
    public class Person
    {

        private string _name;
        private string _surname;
        private int _age;
        private Gender _gender;

        /// <summary>
        /// Инициализируем новый класс
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender; 
        }

        /// <summary>
        /// Получение и валидация имени
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Получение и валидация фамилии
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
            }
        }

        /// <summary>
        /// Получение и валидация возраста
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
            }
        }

        /// <summary>
        /// Получение и валидация пола
        /// </summary>
        public Gender Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
            }
        }

        private static readonly Random _random = new Random(); 

        /// <summary>
        /// Генерирует случайного человека с данными для тестирования.
        /// </summary>
        public static Person GetRandomPerson()
        {
            string[] _maleNames = { "Алексей", "Дмитрий", "Иван", "Сергей",
                                    "Андрей", "Максим", "Егор", "Артём" };

            string[] _femaleNames = { "Анна", "Елена", "Мария",
                                      "Ольга", "Татьяна", "Наталья",
                                      "Дарья", "Полина" };

            string[] _surnamesMale = { "Иванов", "Смирнов", "Кузнецов",
                                       "Попов", "Волков", "Соколов", 
                                       "Лебедев", "Морозов" };

            string[] _surnamesFemale = { "Иванова", "Смирнова", "Кузнецова",
                                         "Попова", "Волкова", "Соколова", 
                                         "Лебедева", "Морозова" };

            var gender = _random.Next(2) == 0 ? Gender.Male : Gender.Female;

            string name, surname;
            int age = _random.Next(0, 123);

            if (gender == Gender.Male)
            {
                name = _maleNames[_random.Next(_maleNames.Length)];
                surname = _surnamesMale[_random.Next(_surnamesMale.Length)];
            }
            else
            {
                name = _femaleNames[_random.Next(_femaleNames.Length)];
                surname = _surnamesFemale[_random.Next(_surnamesFemale.Length)];
            }

            return new Person(name, surname, age, gender);
        }


        public static Person ReadFromConsole()
        {
            var person = new Person("Заглушка", "Заглушка", 0, Gender.Male);

            var actionDictionary = new Dictionary<string, Action>()

            {
                {
                    "имя",
                    new Action(() =>
                    {
                        string input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                            throw new Exception("Имя не может быть пустым!");
                        person._name = input.Trim();
                    })
                },
                {
                     "фамилию",
                     new Action(() =>
                     {
                         string input = Console.ReadLine();
                         if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                             throw new Exception("Фамилия не может быть пустой!");
                         person._surname = input.Trim();
                     })
                },
                {
                     "возраст",
                     new Action(() =>
                     {
                         if (int.TryParse(Console.ReadLine(), out int age))
                         {
                             if (age < 0 || age > 123)
                                 throw new Exception("Возраст должен быть от 0 до 123!");
                             person._age = age;
                         }
                         else
                         {
                             throw new Exception("Введённая строка не может быть преобразована в целое число!");
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
                                  person._gender = Gender.Male;
                                  break;
                              case "2":
                                  person._gender = Gender.Female;
                                  break;
                              default:
                                  throw new Exception("Некорректный ввод пола! Введите 1 или 2.");
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
                    Console.WriteLine($"❌ Ошибка: {exception.Message} Попробуйте снова.");
                }
            }
        }


    }
}