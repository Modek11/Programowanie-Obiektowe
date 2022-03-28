using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    class Teacher : Person
    {
        public Teacher(string name, int age) : base(name,age)
        {

        }

        public override string ToString()
        {
            return $"Teacher: {base.ToString()}";
        }
    }
}