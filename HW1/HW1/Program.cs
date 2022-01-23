using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            LineReader lR = new LineReader();

            System.Console.Write("Enter integer numbers: ");
            lR.ReadLine();
            lR.Split();

            BST<int> t = new BST<int>();

            for(int i = 0; i < lR.Length; i++)
            {
                t.Insert(lR[i]);
            }

            System.Console.Write("Display: ");
            t.Display();
            System.Console.WriteLine();

            System.Console.WriteLine("Statistics: ");
            System.Console.WriteLine("Count: " + t.Count());
            System.Console.WriteLine("Levels: " + t.Levels());
            System.Console.WriteLine("Theoretical Minimum Levels: "+ t.MinimumLevels());

        }
    }
}
