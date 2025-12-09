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

        // Списки имён и фамилий для генерации случайных персон
        private static readonly string[] _maleNames = { "Алексей", "Дмитрий", "Иван", "Сергей", "Андрей", "Максим", "Егор", "Артём" };
        private static readonly string[] _femaleNames = { "Анна", "Елена", "Мария", "Ольга", "Татьяна", "Наталья", "Дарья", "Полина" };
        private static readonly string[] _surnamesMale = { "Иванов", "Смирнов", "Кузнецов", "Попов", "Волков", "Соколов", "Лебедев", "Морозов" };
        private static readonly string[] _surnamesFemale = { "Иванова", "Смирнова", "Кузнецова", "Попова", "Волкова", "Соколова", "Лебедева", "Морозова" };

        private static readonly Random _random = new Random(); 

        /// <summary>
        /// Генерирует случайного человека с данными для тестирования.
        /// </summary>
        public static Person GetRandomPerson()
        {
            var gender = _random.Next(2) == 0 ? Gender.Male : Gender.Female;

            string name, surname;
            int age = _random.Next(0, 123); // от 0 до 123 включительно

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

    }

}