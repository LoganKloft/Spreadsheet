// <copyright file="Program.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetConsoleApp
{
    using System;

    /// <summary>
    /// The class the holds the entry point to the console application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point to the console application.
        /// </summary>
        /// <param name="args"> List of strings provided from the command line. </param>
        public static void Main(string[] args)
        {
            string expression = "A1-12-C1";
            CptS321.ExpressionTree expressionTree = new CptS321.ExpressionTree(expression);

            string choice = "0";
            while (choice != "4")
            {
                MenuMessage(expressionTree.Expression);
                choice = System.Console.ReadLine();

                if (choice == "1")
                {
                    System.Console.Write("Enter new expression: ");
                    expression = System.Console.ReadLine();
                    expressionTree.Expression = expression;
                }
                else if (choice == "2")
                {
                    System.Console.Write("Enter variable name: ");
                    string variableName = System.Console.ReadLine();
                    System.Console.Write("Enter variable value: ");
                    double variableValue = double.Parse(System.Console.ReadLine());
                    expressionTree.SetVariable(variableName, variableValue);
                }
                else if (choice == "3")
                {
                    System.Console.WriteLine(expressionTree.Evaluate().ToString());
                }
            }

            System.Console.WriteLine("Done");
        }

        /// <summary>
        /// Prints to the screen a menu that gives options for the user to choose from.
        /// </summary>
        /// <param name="expression"> String that is printed at the top of the menu. Represents the current expression. </param>
        public static void MenuMessage(string expression)
        {
            System.Console.WriteLine("Menu (current expression=\"{0}\")", expression);
            System.Console.WriteLine("  1 = Enter a new expression");
            System.Console.WriteLine("  2 = Set a variable value");
            System.Console.WriteLine("  3 = Evaluate tree");
            System.Console.WriteLine("  4 = Quit");
        }
    }
}
