using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB1
{
    internal class PersonList
    {

        private List<Person> _persons;

        public PersonList()
        {
            _persons = new List<Person>();
        }

        public void Add(Person person)
        {
            _persons.Add(person);
        
        }

        public void Clear() 
        { 
            _persons.Clear();
        
        }

        public void Remove(Person person)
        {
            _persons.Remove(person);

        }

        public void RemoveAt(int index)
        {
            _persons.RemoveAt(index);

        }

        public Person Index(int index)
        {
            return _persons[index];

        }

        public int IndexOf(Person person)
        {
            return _persons.IndexOf(person);

        }

        public int Count()
        {
            return _persons.Count;

        }
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
