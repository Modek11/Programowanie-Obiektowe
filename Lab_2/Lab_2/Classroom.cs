using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    class Classroom
    {
        private string name;
        private Person[] persons;

        public string Name { get => name; }

        public Classroom(string name,Person[] persons)
        {
            this.name = name;
            this.persons = persons;
        }

        public override string ToString()
        {
            string classroom = $"Classroom: {Name}\n\n";
            foreach (Person person in persons)
            {
                classroom += $"{person.ToString()}\n\n";
            }
            
            return classroom;
        }

    }
}
