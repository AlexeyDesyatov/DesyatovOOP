using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB1
{
    /// <summary>
    /// Представляет список объектов и базовые операции управления.
    /// </summary>
    internal class PersonList
    {

        private List<Person> _persons;

        /// <summary>
        /// Инициализирует новый экземпляр класса с пустым списком.
        /// </summary>
        public PersonList()
        {
            _persons = new List<Person>();
        }

        /// <summary>
        /// Добавляет указанного человека в конец списка.
        /// </summary>
        public void Add(Person person)
        {
            _persons.Add(person);
        
        }

        /// <summary>
        /// Удаляет все элементы из списка.
        /// </summary>
        public void Clear() 
        { 
            _persons.Clear();
        
        }

        /// <summary>
        /// Удаляет первое вхождение указанного человека из списка.
        /// </summary>
        public void Remove(Person person)
        {
            _persons.Remove(person);

        }

        /// <summary>
        /// Удаляет человека по указанному индексу.
        /// </summary>
        public void RemoveAt(int index)
        {
            _persons.RemoveAt(index);

        }

        /// <summary>
        /// Возвращает человека по указанному индексу.
        /// </summary>
        public Person Index(int index)
        {
            return _persons[index];

        }

        /// <summary>
        /// Определяет индекс первого вхождения указанного человека в списке.
        /// </summary>
        public int IndexOf(Person person)
        {
            return _persons.IndexOf(person);

        }

        /// <summary>
        /// Возвращает количество людей в списке.
        /// </summary>
        public int Count()
        {
            return _persons.Count;

        }

        /// <summary>
        /// Выводит содержимое списка людей в консоль в человекочитаемом формате.
        /// </summary>
        public static void PrintPersonList(PersonList list, string listName)
        {
            Console.WriteLine($"\n=== {listName} ===");
            for (int i = 0; i < list.Count(); i++)
            {
                Person p = list.Index(i);
                string genderStr = p.Gender switch
                {
                    Gender.Male => "Мужчина",
                    Gender.Female => "Женщина",
                    _ => "Неизвестно"
                };

                Console.WriteLine($"Имя: {p.Name}, Фамилия: {p.Surname}, Возраст: {p.Age}, Пол: {genderStr}");
            }
        }
    }
    
}
