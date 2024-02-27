using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class Trapeze
    {
        //поля
        private int a;
        private int b;
        private int h;
        private int c;

        //конструктори
        public Trapeze()
        {
            this.a = 3;
            this.b = 5;
            this.h = 2;
            this.c = 0;
        }

        public Trapeze(int osnova1, int osnova2, int height, int color)
        {
            this.a = osnova1;
            this.b = osnova2;
            this.h = height;
            this.c = color;
        }

        //get i set
        //public int A { get => this.a; set => this.a = value;}
        public int A
        {
            get { return this.a; }
            set { this.a = value; }
        }

        public int B
        {
            get { return this.b; }
            set { this.b = value; }
        }

        public int H
        {
            get { return this.h; }
            set { this.h = value; }
        }

        public int C
        {
            get { return this.c; }
        }

        // Indexer
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.a;
                    case 1:
                        return this.b;
                    case 2:
                        return this.h;
                    case 3:
                        return this.c;
                    default:
                        Console.WriteLine("Error: Invalid index");
                        return -1;
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.a = value;
                        break;
                    case 1:
                        this.b = value;
                        break;
                    case 2:
                        this.h = value;
                        break;
                    case 3:
                        Console.WriteLine("Error: Cannot modify color through the indexer");
                        break;
                    default:
                        Console.WriteLine("Error: Invalid index");
                        break;
                }
            }
        }

        //методи
        public void DisplayLengths()
        {
            Console.WriteLine($"Base 1: {A}");
            Console.WriteLine($"Base 2: {B}");
            Console.WriteLine($"Height: {H}");
        }

        public double CalculatePerimeter()
        {
            double P = a + b + 2 * Math.Sqrt(Math.Pow((b - a) / 2, 2) + Math.Pow(h, 2));
            return P;
        }

        public double CalculateArea()
        {
            double S = ((double)this.a + this.b) / 2 * this.h;
            return S;
        }

        public bool IsSquare()
        {
            return this.a == this.b && this.a == this.h;
        }

        //++
        public static Trapeze operator ++(Trapeze trapeze)
        {
            trapeze.A++;
            trapeze.B++;
            return trapeze;
        }

        //-- 
        public static Trapeze operator --(Trapeze trapeze)
        {
            trapeze.A--;
            trapeze.B--;
            return trapeze;
        }

        //true
        public static bool operator true(Trapeze trapeze)
        {
            return trapeze.a == trapeze.A && trapeze.b == trapeze.B && trapeze.h == trapeze.H && trapeze.c == trapeze.C;
        }

        //false
        public static bool operator false(Trapeze trapeze)
        {
            return trapeze.a != trapeze.A || trapeze.b != trapeze.B || trapeze.h != trapeze.H || trapeze.c != trapeze.C;
        }

        //*
        public static Trapeze operator *(Trapeze trapeze, int scalar)
        {
            return new Trapeze(trapeze.A * scalar, trapeze.B, trapeze.H * scalar, trapeze.C);
        }

        // from trapeze to string
        public static explicit operator string(Trapeze trapeze)
        {
            return $"({trapeze.a}, {trapeze.b}, {trapeze.h}, {trapeze.c})";
        }

        // from string to trapeze
        public static explicit operator Trapeze(string trapezeString)
        {
            string[] coordinates = trapezeString.Trim('(', ')').Split(',');

            int a = int.Parse(coordinates[0]);
            int b = int.Parse(coordinates[1]);
            int h = int.Parse(coordinates[2]);
            int c = int.Parse(coordinates[3]);

            return new Trapeze(a, b, h, c);
        }
    }
}
