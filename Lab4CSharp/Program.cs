
using Lab4CSharp;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("             Lab 4 ");
        Console.WriteLine("             Task 1");
        Console.WriteLine("             Part 1(Indexer)");


        Trapeze trapeze = new Trapeze();
        //get
        Console.WriteLine(trapeze[0]); 
        Console.WriteLine(trapeze[1]); 
        Console.WriteLine(trapeze[2]);
        Console.WriteLine(trapeze[3]); 
        //set
        trapeze[0] = 10; 
        Console.WriteLine(trapeze[0]);



        Console.WriteLine();
        Console.WriteLine("             Part 2");
        Console.WriteLine("             Operator ++ and operator --");
        Trapeze trapeze1 = new Trapeze(1, 7, 3, 4);
        Console.WriteLine("Original Trapeze:");
        trapeze1.DisplayLengths();

        trapeze1++; // Increment values of 'a' and 'b'
        Console.WriteLine("\nAfter ++ operator:");
        trapeze1.DisplayLengths();

        trapeze1--; // Decrement values of 'a' and 'b'
        Console.WriteLine("\nAfter -- operator:");
        trapeze1.DisplayLengths();


        Console.WriteLine();
        Console.WriteLine("             Operator false and operator true");
        Trapeze trapeze2 = new Trapeze(3, 8, 2, 0);
        if (trapeze2) 
            Console.WriteLine("True");
        else 
            Console.WriteLine("False");

        if (trapeze1) 
            Console.WriteLine("True");
        else 
            Console.WriteLine("False");


        Console.WriteLine();
        Console.WriteLine("             Operator * and scalar");
        int scalar = 3;
        Trapeze result = trapeze1 * scalar;

        Console.WriteLine("Original Trapeze:");
        trapeze1.DisplayLengths();

        Console.WriteLine($"\nTrapeze multiplied by {scalar}:");
        result.DisplayLengths();


        Console.WriteLine();
        Console.WriteLine("             To string and from string");
        string trapezeString = (string)trapeze1;
        Console.WriteLine("To string:" + trapezeString);


        trapezeString = "(1, 2, 3, 4)";
        Trapeze newTrapeze = (Trapeze)trapezeString;

        Console.WriteLine("\nConverted Trapeze from string:");
        newTrapeze.DisplayLengths();
    }
}
