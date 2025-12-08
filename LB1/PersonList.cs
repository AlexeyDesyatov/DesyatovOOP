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
        int index;

        public PersonList()
        {
            _persons = new List<Person>();
            index = 0;
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

        public void RemoveAt()
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
    }
}
