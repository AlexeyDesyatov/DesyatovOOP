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

        
        public void Add(Person person)
        {
            _persons.Add(person);
        

        }

        public void Clear() 
        { 
            _persons.Clear();
        
        }
       
        


    }
}
