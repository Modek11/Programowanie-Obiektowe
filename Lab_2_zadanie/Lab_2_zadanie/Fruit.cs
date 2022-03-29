using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_zadanie
{
    public class Fruit : Product
    {
        private int count;

        public int Count { get => count; }
        
        public Fruit (string name, int count) : base(name)
        {
            this.count = count;
        }

        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}{this.Name} ({this.Count} fruits)");
        }
    }
}
