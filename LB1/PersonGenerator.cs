using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Представляет статические методы для генерации взрослого или ребенка
    /// </summary>
    public class PersonGenerator
    {
        /// <summary>
        /// Общий экземпляр класса Random
        /// </summary>
        private static Random random = new Random();

        /// <summary>pattern
        /// Заполняет данные для случайного человека
        /// <param name="person"></param>
        public static void FillRandomPerson(PersonBase person)
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

            string name = gender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string surname = gender == Gender.Male
                ? surnamesMale[random.Next(surnamesMale.Length)]
                : surnamesFemale[random.Next(surnamesFemale.Length)];

            person.Name = name;
            person.Surname = surname;
            person.Gender = gender;

        }

        /// <summary>
        /// Заполняет данные для взрослого
        /// </summary>
        /// <param name="adult">Взрослый</param>
        public static void FillAdult(Adult adult)
        {
            int age = random.Next(18, 123);

            string[] workPlaces = {"Газпромнефть", "Росатом", "VK", "Сбер",
                                   "X5 Group", "РЖД", "Ростелеком", "АО СО ЕЭС"};

            string workPlace = workPlaces[random.Next(workPlaces.Length)];

            string passportSeries = random.Next(1000, 10000).ToString();

            string passportNumber = random.Next(100000, 1000000).ToString();

            string passport = $"{passportSeries} {passportNumber}";

            adult.Age = age;
            adult.Passport = passport;
            adult.Workplace = workPlace;
            adult.Partner = null;
        }

        /// <summary>
        /// Заполняет данные для ребенка
        /// </summary>
        /// <param name="child">Ребенок</param>
        public static void FillChild(Child child)
        {
            int age = random.Next(0, 18);

            string[] studyPlaces = {"Школа 31", "Детский сад Ладушки", "Школа 1",
                                    "МАОУ СОШ 25", "Лицей ТПУ", "Детский сад 96",
                                    "Детский сад Солнышко"};

            string studyPlace = studyPlaces[random.Next(studyPlaces.Length)];

            child.Age = age;
            child.Study = studyPlace;
            child.Mother = null;
            child.Father = null;
        }

        /// <summary>
        /// Генерирует случайного взрослого
        /// </summary>
        /// <returns></returns>
        public static Adult GetRandomAdult()
        {
            Adult adult = new Adult();
            FillRandomPerson(adult);
            FillAdult(adult);   
            return adult;
        }

        /// <summary>
        /// Генерирует случайного ребенка
        /// </summary>
        /// <returns></returns>
        public static Child GetRandomChild()
        {
            Child child = new Child();
            FillRandomPerson(child); 
            FillChild(child);
            return child;
        }

        /// <summary>
        /// Генерирует случайную персону
        /// </summary>
        /// <returns></returns>
        public static PersonBase GetRandomPerson()
        {
            return random.Next(2) == 0
            ? GetRandomAdult()
            : GetRandomChild();
        }
    }
}
