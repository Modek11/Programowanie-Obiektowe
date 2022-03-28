using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_1
{
    public class Fraction
    {
        private double numerator { get; set; }      //licznik
        private double denominator{ get; set; }     //mianownik

        //konstruktor
        public Fraction()
        {
            numerator = 1;
            denominator = 2;
        }

        //konstruktor dwu argumentowy
        public Fraction(double numerator, double denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        //konstruktor kopiujący
        public Fraction(Fraction previousFraction)
        {
            numerator = previousFraction.numerator;
            denominator = previousFraction.denominator;
        }

        public override string ToString()
        {
            return $"Numerator: {numerator}, denominator: {denominator}";
        }

        public static Fraction operator +(Fraction f1) => f1;
        public static Fraction operator -(Fraction f1) => new Fraction(-f1.numerator,f1.denominator);
        public static Fraction operator +(Fraction f1, Fraction f2) => new Fraction(f1.numerator * f2.denominator + f2.numerator * f1.denominator , f1.denominator * f2.denominator);
        public static Fraction operator -(Fraction f1, Fraction f2) => new Fraction(f1.numerator * f2.denominator - f2.numerator * f1.denominator, f1.denominator * f2.denominator);
        public static Fraction operator *(Fraction f1, Fraction f2) => new Fraction(f1.numerator * f2.numerator, f1.denominator * f2.denominator);
        public static Fraction operator /(Fraction f1, Fraction f2) => new Fraction(f1.numerator * f2.denominator, f2.denominator * f1.numerator);

    }
}
