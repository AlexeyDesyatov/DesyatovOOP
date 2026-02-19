using System;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Хранение и обработка данных ребенка
    /// </summary>
    public class Child : PersonBase
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
        /// Возраст совершеннолетия
        /// </summary>
        public override int MaxAge { get; } = 18;

        /// <summary>
        /// Создание нового экземпляра класса Child по умолчанию.
        /// </summary>
        public Child() : this("Ivan", "Ivanov", 10, Gender.Male, null, null,
            "Школа 31") { }

        /// <summary>
        /// Получение и валидация матери
        /// </summary>
        public Adult Mother
        {
            get { return _mother; }
            set
            {
                if (value != null && value.Gender != Gender.Female)
                {
                    throw new ArgumentException(
                        $"Некорректный пол матери: ожидается женский пол");
                }
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
                if (value != null && value.Gender != Gender.Male)
                {
                    throw new ArgumentException(
                        $"Некорректный пол отца: ожидается мужской пол");
                }
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
                _studyPlace = ValidateText(value, "Место учебы");
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
                if (value >= MaxAge)
                {
                    throw new ArgumentException($"Возраст ребенка" +
                        $" должен быть менее {MaxAge} лет ");
                }
                base.Age = value;
            }
        }

        /// <summary>
        /// Получение названия пола
        /// </summary>
        protected override string GenderRole => Gender switch
        {
            Gender.Male => "Мальчик",
            Gender.Female => "Девочка"
        };

        /// <summary>
        /// Получение информации 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override string GetInfo()
        {
            string basic = GetBasicInfo();

            string motherInfo = Mother != null
                ? $"{Mother.Name} {Mother.Surname}"
                : "не указана";

            string fatherInfo = Father != null
                ? $"{Father.Name} {Father.Surname}"
                : "не указан";

            return $" Ребёнок \n {basic}, \n Мать: {motherInfo} " +
                $" \n Отец: {fatherInfo} \n Место учебы: { Study}";
        }

        /// <summary>
        /// Получение информации о хобби
        /// </summary>
        /// <returns></returns>
        public override string GetHobby() => "шахматы";
    }
}