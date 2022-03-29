using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_zadanie
{
    internal class Seller : Person
    {
        public Seller(string name, int age) : base(name, age)
        {

        }

        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}Seller: {this.Name} ({this.Age} y.o.)");
        }
    }
}
