using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Хранение и обработка персональных данных.
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия человека
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст человека
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол человека
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Инициализируем новый экземпляр класса Person.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public PersonBase(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender; 
        }

        /// <summary>
        /// Создание нового экземпляра класса Person по умолчанию.
        /// </summary>
        public PersonBase() : this("Ivan", "Ivanov", 18, Gender.Male) { }

        /// <summary>
        /// Получение и валидация имени.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = Validate(value, "Имя");
            }
        }

        /// <summary>
        /// Получение и валидация фамилии.
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = Validate(value, "Фамилия");
                EnsureLanguage();
            }
        }

        /// <summary>
        /// Минимальный возраст
        /// </summary>
        public virtual int MinAge { get; } = 0;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        public virtual int MaxAge { get; } = 123;

        /// <summary>
        /// Возраст совершеннолетия
        /// </summary>
        protected const int AdultAge = 18;

        /// <summary>
        /// Получение и валидация возраста.
        /// </summary>
        public virtual int Age
        {
            get { return _age; }
            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new Exception($"{nameof(Age)} должен быть от " +
                        $"{MinAge} до {MaxAge}!");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Получение и валидация пола.
        /// </summary>
        public Gender Gender
        {
            get { return _gender; }
            set
            {               
                _gender = value;
            }
        }

        /// <summary>
        /// Определение пола
        /// </summary>
        protected abstract string GenderRole { get; }

        /// <summary>
        /// Проверка строки, содержащей только кириллические символы
        /// </summary>
        private const string RussianPattern = @"^[а-яА-ЯёЁ]+(?:-[а-яА-ЯёЁ]+)?$";

        /// <summary>
        /// Проверка строки, содержащей только латинские символы
        /// </summary>
        private const string LatinPattern = @"^[a-zA-Z]+(?:-[a-zA-Z]+)?$";

        /// <summary>
        /// Проверяет корректность входной строки по заданным правилам
        /// </summary>
        /// <param name="value">Проверяемая строка</param>
        /// <param name="fieldName">Название поля</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">при неверном вводе</exception>
        private static string Validate(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(
                    $"Поле {fieldName} не может быть пустым " +
                    $"или состоять только из пробелов.");

            bool isRussian = Regex.IsMatch(value, RussianPattern);
            bool isLatin = Regex.IsMatch(value, LatinPattern);

            if (!isRussian && !isLatin)
            {
                throw new ArgumentException(
                    $"{fieldName} может содержать только русские буквы" +
                    $" ИЛИ только английские буквы. " +
                    $"Двойное имя/фамилия допускается через дефис.");
            }

            var textInfo = 
                System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(value.ToLowerInvariant());
        }

        /// <summary>
        /// Проверяет корректность языка
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        private void EnsureLanguage()
        {
            bool nameIsRussian = Regex.IsMatch(_name, RussianPattern);
            bool surnameIsRussian = Regex.IsMatch(_surname, RussianPattern);

            if (nameIsRussian != surnameIsRussian)
            {
                throw new InvalidOperationException(
                    $"Язык имени и фамилии не совпадает. " +
                    "Имя и фамилия должны быть на одном языке.");
            }
        }

        protected static string ValidateText(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(
                    $"Поле {fieldName} не может быть пустым " +
                    $"или состоять только из пробелов.");

            return value;
        }

        /// <summary>
        /// Получение информации
        /// </summary>
        /// <returns></returns>
        public abstract string GetInfo();

        /// <summary>
        /// Формирование строки с базовой информацией
        /// </summary>
        /// <returns></returns>
        protected string GetBasicInfo()
        {
            return $"- пол: {GenderRole}) {Name} {Surname}, возраст: {Age}";
        }
    }
}