using System;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Хранение и обработка данных взрослого человека
    /// </summary>
    public class Adult : Person
    {
        /// <summary>
        /// Серия и номер паспорта
        /// </summary>
        private string _passportData;

        /// <summary>
        /// Место работы
        /// </summary>
        private string _workplace;

        /// <summary>
        /// Семейное положение
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Новый экземпляр класса Adult
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="passportData">Паспортные данные</param>
        /// <param name="workplace">Место работы</param>
        /// <param name="partner">Семейное положение</param>
        public Adult(string name, string surname, int age, Gender gender,
            string passportData, string workplace, Adult partner)
            : base(name, surname, age, gender)
        {
            Passport = passportData;
            Workplace = workplace;
            Partner = partner;
        }

        /// <summary>
        /// Создание нового экземпляра класса Adult по умолчанию.
        /// </summary>
        public Adult() : this("Ivan", "Ivanov", 18, Gender.Male, "1234 123456", "SO.UPS", null ) { }

        /// <summary>
        /// Получение и валидация паспортных данных
        /// </summary>
        public string Passport
        {
            get { return _passportData; }
            set 
            { 
                _passportData = value;
            }
        }

        /// <summary>
        /// Получение и валидация места работы
        /// </summary>
        public string Workplace
        {
            get { return _workplace; }
            set
            {
                _workplace = value;
            }
        }
        
        /// <summary>
        /// Получение и валидация семейного положения
        /// </summary>
        public Adult Partner
        {
            get { return _partner; }
            set
            {
                _partner = value;
            }
        }
    }

}
