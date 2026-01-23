using System;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Summary description for Class1
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

        private Adult _partner;

        public Adult(string name, string surname, int age, Gender gender,
            string passportData, string workplace, Adult partner)
            : base(name, surname, age, gender)
        {
            Passport = passportData;
            Workplace = workplace;
            Partner = partner;
        }

        /// <summary>
        /// Создаение нового экземпляра класса Person по умолчанию.
        /// </summary>
        public Adult() : this("Ivan", "Ivanov", 18, Gender.Male, "1234 123456", "SO.UPS", null ) { }

        public string Passport
        {
            get { return _passportData; }
            set 
            { 
                _passportData = value;
            }
        }

        public string Workplace
        {
            get { return _workplace; }
            set
            {
                _workplace = value;
            }
        }
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
