using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    public class Person
    {
        private string name;
        private int age;
        
        public string Name { get => name; }
        public int Age { get => age; }

        public Person(string name, int age)
        {
            this.age = age;
            this.name = name;
        }

        public bool Equals(Person other)
        {
            return Name == other.Name && Age == other.Age ? true : false;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

}
