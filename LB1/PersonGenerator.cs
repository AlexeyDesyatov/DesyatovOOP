using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonGenerator
    {
        private static Random random = new Random();

        /// <summary>pattern
        /// Генерирует случайного человека с данными для тестирования.
        /// </summary>
        /// <returns>Возвращает новый экземпляр класса Person</returns>
        public static void GetRandomPerson(PersonBase person)
        {
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

            person.Name = name;
            person.Surname = surname;
            person.Age = age;
            person.Gender = gender;

        }

        public static Adult GetRandomAdult()
        {
            Adult adult = new Adult();

            string[] workPlaces = {"Газпромнефть", "Росатом", "VK", "Сбер",
                                   "X5 Group", "РЖД", "Ростелеком", "АО СО ЕЭС"};

            string workPlace = workPlaces[random.Next(workPlaces.Length)];

            string passportSeries = random.Next(1000, 10000).ToString();

            string passportNumber = random.Next(100000, 1000000).ToString();

            string passport = $"{passportSeries} {passportNumber}";

            adult.Passport = passport;
            adult.Workplace = workPlace;
            adult.Partner = null;

            return adult;

        }

        public static PersonBase GetRandomChild()
        {
            Child child = new Child();

            string[] studyPlaces = {"Школа 31", "Детский сад Ладушки", "Школа 1",
                                    "МАОУ СОШ 25", "Лицей ТПУ", "Детский сад 96",
                                    "Детский сад Солнышко"};

            string studyPlace = studyPlaces[random.Next(studyPlaces.Length)];

            child.Study = studyPlace;
            child.Mother = null;
            child.Father = null;

            return child;

        }
    }
}
