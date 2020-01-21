using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {

        private string name;
        private int age;

        public Person()
        {
            Name = "No name";
            Age = 1;
            
        }
        
        public Person(int age)
            :this()
        {
            Age = age;
        }

        public Person(string name, int age)
            : this(age)
        {
            Name = name;
        }

        private List<Person> allPersons;

        public void AllPersons()
        {
           allPersons = new List<Person>();
        }

        public void AddPersons(Person person)
        {
            allPersons.Add(person);
        }

        //public Person IsOver30(Person person)
        //{
        //    Person over30 = new Person();
        //    bool is30 = false;

        //    if (person.age>30)
        //    {
        //        is30 = true;
        //        over30 = person;
        //    }
        //    if (is30)
        //    {
        //        return over30;
        //    }
           
        //}
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }
    }
}
