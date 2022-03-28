using System;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction();
            Fraction f2 = new Fraction(1, 3);
            Console.WriteLine(f1); Console.WriteLine(f2); Console.WriteLine();
            Console.WriteLine(-f1);
            Console.WriteLine(f1+f2);

        }
        string Konstruktory()
        {
            //Żeby działało trzeba przekopiować do main
            Fraction f1 = new Fraction();
            Console.WriteLine(f1);

            Fraction f2 = new Fraction(5,7);
            Console.WriteLine(f2);

            Fraction f3 = new Fraction(f2);
            Console.WriteLine(f3);
            return "";
        }
    }
}
