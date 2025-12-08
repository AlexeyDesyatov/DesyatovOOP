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

        public void Index(Person person)
        {
            Console.WriteLine(_persons[index]);

        }

        public void IndexOf(Person person)
        {
            _persons.IndexOf(person);

        }

        public void Count()
        {
            Console.WriteLine(_persons.Count);

        }
    }
}
