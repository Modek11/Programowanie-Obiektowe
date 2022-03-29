using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_zadanie
{
    public abstract class Product : IThing
    {
        private string name;

        public string Name { get => name; }

        public Product(string name)
        {
            this.name = name;
        }

        public abstract void Print(string prefix);
    }
}
