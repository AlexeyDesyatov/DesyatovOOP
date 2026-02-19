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
        public static void FillRandomPerson(PersonBase person,
            Gender? gender = null)
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

            person.Gender = gender ?? (Gender)random.Next(2);

            switch (person.Gender)
            {
                case Gender.Male:
                    person.Name = maleNames[random.Next(maleNames.Length)];
                    person.Surname = 
                        surnamesMale[random.Next(surnamesMale.Length)];
                    break;
                case Gender.Female:
                    person.Name = femaleNames[random.Next(femaleNames.Length)];
                    person.Surname = 
                        surnamesFemale[random.Next(surnamesFemale.Length)];
                    break;
            }
        }

        /// <summary>
        /// Заполняет данные для взрослого
        /// </summary>
        /// <param name="adult">Взрослый</param>
        public static void FillAdult(Adult adult)
        {
            int age = random.Next(18, 123);

            string[] workPlaces = {"Газпромнефть", "Росатом", "VK", "Сбербанк",
                                   "X5 Group", "РЖД", "Ростелеком", "АО СО ЕЭС", null};

            string workPlace = workPlaces[random.Next(workPlaces.Length)];

            string passportSeries = random.Next(1000, 10000).ToString();

            string passportNumber = random.Next(100000, 1000000).ToString();

            string passport = $"{passportSeries} {passportNumber}";

            adult.Age = age;
            adult.Passport = passport;
            adult.Workplace = workPlace;

            if (random.Next(2) == 0)
            {
                var partnerGender =
                    adult.Gender == Gender.Male
                    ? Gender.Female
                    : Gender.Male;

                adult.Partner = GetRandomAdult(partnerGender);     
            }
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

            Adult father = GetRandomAdult(Gender.Male);
            child.Father = father;

            Adult mother = GetRandomAdult(Gender.Female);
            child.Mother = mother;

            mother.Surname = father.Surname + "а";

            switch (child.Gender)
            {
                //TODO: {}
                case Gender.Male:
                    child.Surname = father.Surname;
                    break;
                case Gender.Female:
                    child.Surname = mother.Surname;
                    break;
            }
        }

        /// <summary>
        /// Генерирует случайного взрослого
        /// </summary>
        /// <returns></returns>
        public static Adult GetRandomAdult(Gender? gender = null)
        {
            Adult adult = new Adult();
            FillRandomPerson(adult, gender);
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
