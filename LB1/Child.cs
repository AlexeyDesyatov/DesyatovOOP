using System;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Хранение и обработка данных ребенка
    /// </summary>
    public class Child : Person
    {
        /// <summary>
        /// Мать
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Отец
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Место учебы
        /// </summary>
        private string _studyPlace;

        /// <summary>
        /// Новый экземпляр класса Child
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="mother">Мать</param>
        /// <param name="father">Отец</param>
        /// <param name="study">Место учебы</param>
        public Child(string name, string surname, int age, Gender gender,
            Adult mother, Adult father, string study)
            : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            Study = study;
        }

        /// <summary>
        /// Создание нового экземпляра класса Child по умолчанию.
        /// </summary>
        public Child() : this("Ivan", "Ivanov", 10, Gender.Male, null, null, "Школа 31") { }

        /// <summary>
        /// Получение и валидация матери
        /// </summary>
        public Adult Mother
        {
            get { return _mother; }
            set
            {
                _mother = value;
            }
        }

        /// <summary>
        /// Получение и валидация отца
        /// </summary>
        public Adult Father
        {
            get { return _father; }
            set
            {
                _father = value;
            }
        }

        /// <summary>
        /// Получение и валидация места учебы
        /// </summary>
        public string Study
        {
            get { return _studyPlace; }
            set
            {
                _studyPlace = value;
            }
        }
    }

}
