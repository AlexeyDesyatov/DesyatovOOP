using System.Text.RegularExpressions;



namespace LB1
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Имя не может быть пустым!");
                }

                if (!Regex.IsMatch(value,
                    @"^[а-яА-ЯёЁa-zA-Z]+(?:-[а-яА-ЯёЁa-zA-Z]+)?$"))
                {
                    throw new ArgumentException(
                        "Имя может содержать только русские" +
                        " или английские буквы. " +
                        "Запись двойного имени через '-'");
                }

                System.Globalization.TextInfo textInfo =
                    System.Globalization.CultureInfo.CurrentCulture.TextInfo;
                _name = textInfo.ToTitleCase(value.ToLower());
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Фамилия не может быть пустой!");
                }

                if (!Regex.IsMatch(value,
                    @"^[а-яА-ЯёЁa-zA-Z]+(?:-[а-яА-ЯёЁa-zA-Z]+)?$"))
                {
                    throw new ArgumentException(
                        "Фамилия может содержать только русские " +
                        "или английские буквы." +
                        " Запись двойной фамилии через '-'");
                }
                System.Globalization.TextInfo textInfo =
                    System.Globalization.CultureInfo.CurrentCulture.TextInfo;
                _surname = textInfo.ToTitleCase(value.ToLower());
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

        /// <summary>
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

            var gender = random.Next(2) == 0 ? Gender.Male : Gender.Female;

            string name, surname;
            int age = random.Next(0, 123);

            if (gender == Gender.Male)
            {
                name = maleNames[random.Next(maleNames.Length)];
                surname = surnamesMale[random.Next(surnamesMale.Length)];
            }
            else
            {
                name = femaleNames[random.Next(femaleNames.Length)];
                surname = surnamesFemale[random.Next(surnamesFemale.Length)];
            }

            return new Person(name, surname, age, gender);
        }
    }
}