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
        /// <summary>
        /// Варианты пола
        /// </summary>

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
        /// <param name="gendr"></param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gendr = gender; 
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
        public Gender Gendr
        {
            get { return _gender; }
            set
            {
                _gender = value;
            }
        }

        public string Introduce()
        {
            string genderStr = Gendr switch
            {
                Gender.Male => "Мужчина",
                Gender.Female => "Женщина",
                _ => "Неизвестно"
            };

            return $"Person {Name} {Surname} my friend!\nGender is {genderStr}";
        }
    }

}