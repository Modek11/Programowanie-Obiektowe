using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    public class Person
    {
        string Name { get; set; }
        int Age { get; set; }

        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }

        public bool Equals(Person person)
        {
            if(Name == person.Name && Age == person.Age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

}
