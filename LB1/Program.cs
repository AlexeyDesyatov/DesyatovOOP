using LB1;
using System;

class Program
{
    static void Main(string[] args)
    {
        PersonList list1 = new PersonList();
        PersonList list2 = new PersonList();

        Person person1 = new Person("Ivan", "Ivanov", 22, Gender.Male);
        Person person2 = new Person("Dmitriy", "Dmitriev", 25, Gender.Male);
        Person person3 = new Person("Dmi", "Dmiev", 25, Gender.Male);

        Person person4 = new Person("Елена", "Кузнецова", 35, Gender.Female);
        Person person5 = new Person("Дмитрий", "Попов", 40, Gender.Male);
        Person person6 = new Person("Ольга", "Смирнова", 22, Gender.Female);

        list1.Add(person1);
        list1.Add(person2);
        list1.Add(person3);

        list2.Add(person4);
        list2.Add(person5);
        list2.Add(person6);

        Console.WriteLine("=== Список 1 ===");
        for (int i = 0; i < list1.Count(); i++)
        {
            Console.WriteLine(list1.Index(i).Introduce());
        }

        // Выводим содержимое второго списка
        Console.WriteLine("\n=== Список 2 ===");
        for (int i = 0; i < list2.Count(); i++)
        {
            Console.WriteLine(list2.Index(i).Introduce());
        }
    }
}