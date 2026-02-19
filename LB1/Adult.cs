using System;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Хранение и обработка данных взрослого человека
    /// </summary>
    public class Adult : PersonBase
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
        /// Возраст совершеннолетия
        /// </summary>
        public override int MinAge { get; } = 18;

        /// <summary>
        /// Создание нового экземпляра класса Adult по умолчанию.
        /// </summary>
        public Adult() : this("Ivan", "Ivanov", 18, Gender.Male, "1234 123456",
                              "SO.UPS", null ) { }

        /// <summary>
        /// Получение и валидация паспортных данных
        /// </summary>
        public string Passport
        {
            get { return _passportData; }
            set 
            {
                _passportData = ValidatePassport(value);
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
                _workplace = string.IsNullOrEmpty(value)
                ? "Безработный"
                : $"{value}";
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
                if (value == this)
                {
                    throw new ArgumentException("Нельзя установить себя" +
                                            " в качестве партнёра");
                }

                if (value != null && value.Gender == this.Gender)
                {
                    throw new ArgumentException("Партнёр " +
                        "должен быть противоположного пола");
                }

                _partner = value;

                if (value != null)
                {
                    value._partner = this;
                }
            }
        }

        /// <summary>
        /// Получение и валидация возраста
        /// </summary>
        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value < MinAge)
                {
                    throw new ArgumentException($"Возраст взрослого" +
                        $" должен быть от {MinAge} лет");
                }
                base.Age = value;   
            }
        }
        
        /// <summary>
        /// Получение названия пола
        /// </summary>
        protected override string GenderRole => Gender switch
        {
            Gender.Male => "Мужчина",
            Gender.Female => "Женщина"
        };

        /// <summary>
        /// Получение информации
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override string GetInfo()
        {
            string basic = GetBasicInfo();

            string workplaceInfo = Workplace;

            string status = Partner != null
                ? $"женат/замужем за {Partner.Name} {Partner.Surname}"
                : " не состоит в браке";

            return $" Взрослый \n {basic}\n Паспорт: {Passport}," +
                $" \n Место работы: {workplaceInfo} \n " +
                $"Семейный статус: {status}";
        }

        /// <summary>
        /// Проверка корректности ввода паспортных данных
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static string ValidatePassport(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Паспортные данные" +
                    " не могут быть пустыми.");

            if (!Regex.IsMatch(value, @"^\d{4} \d{6}$"))
                throw new ArgumentException(
                    "Неверный формат паспорта." +
                    " Пример корректного значения: '1234 123456'");

            return value;
        }

        /// <summary>
        /// Получение информации о хобби
        /// </summary>
        /// <returns></returns>
        public override string GetHobby() => " путешествия";
    }
}
