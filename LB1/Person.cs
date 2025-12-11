using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Хранение и обработка персональных данных.
    /// </summary>
    public class Person
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
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender; 
        }

        /// <summary>
        /// Создаение нового экземпляра класса Person по умолчанию.
        /// </summary>
        public Person() : this("Ivan", "Ivanov", 18, Gender.Male) { }

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
            }
        }

        /// <summary>
        /// Получение и валидация возраста.
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                const int minAge = 0;
                const int maxAge = 123;
                if (value < minAge || value > maxAge)
                {
                    throw new Exception($"{nameof(Age)} должен быть от " +
                        $"{minAge} до {maxAge}!");
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

        //TODO: XML
        private const string RussianPattern = @"^[а-яА-ЯёЁ]+(?:-[а-яА-ЯёЁ]+)?$";

        //TODO: XML
        private const string LatinPattern = @"^[a-zA-Z]+(?:-[a-zA-Z]+)?$";

        //TODO: XML
        private static string Validate(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(
                    $"{fieldName} не может быть пустым " +
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

        /// <summary>pattern
        /// Генерирует случайного человека с данными для тестирования.
        /// </summary>
        /// <returns>Возвращает новый экземпляр класса Person</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();

            string[] maleNames = { "Алексей", "Дмитрий", "Иван", "Сергей",
                                    "Андрей", "Максим", "Егор", "Артём" };

            string[] femaleNames = { "Анна", "Елена", "Мария",
                                      "Ольга", "Татьяна", "Наталья",
                                      "Дарья", "Полина" };

            string[] surnamesMale = { "Иванов", "Смирнов", "Кузнецов",
                                       "Попов", "Волков", "Соколов", 
                                       "Лебедев", "Морозов" };

            string[] surnamesFemale = { "Иванова", "Смирнова", "Кузнецова",
                                         "Попова", "Волкова", "Соколова", 
                                         "Лебедева", "Морозова" };

            var gender = random.Next(2) == 0 
                ? Gender.Male 
                : Gender.Female;

            int age = random.Next(0, 123);

            string name = gender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string surname = gender == Gender.Male
                ? surnamesMale[random.Next(surnamesMale.Length)]
                : surnamesFemale[random.Next(surnamesFemale.Length)];

            return new Person(name, surname, age, gender);
        }
    }
}