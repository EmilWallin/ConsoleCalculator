using System;
using System.Collections.Generic;

namespace EmilWallin_Miniräknare
{
    class Program
    {
        private static List<string> calculatorHistory = new List<string>();

        static void Main(string[] args)
        {
            Calculator();
        }

        //Main method for the calculator
        private static void Calculator()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("Enter your name:");
            string username = Console.ReadLine();

            bool applicationClosing = false;
            while (!applicationClosing)
            {
                PrintMenu(username);
                Console.Write("Your choice: ");
                int choice = 99;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out choice))
                        break;
                }

                //User choice
                switch (choice)
                {
                    case 1:
                        Calculation();
                        break;
                    case 2:
                        PrintHistory();
                        break;
                    case 0:
                        Console.WriteLine("Goodbye! Thank you for using this application!");
                        applicationClosing = true;
                        break;
                    default:
                        Console.WriteLine("Unable to process your choice. Please try again.");
                        break;
                }
            }
        }


        //Method for taking values and doing the calculation
        private static void Calculation()
        {
            double val1 = 0;
            double val2 = 0;

            PrintSeparator();

            //First value
            while (true)
            {
                Console.Write("Enter your first value: ");
                if (double.TryParse(Console.ReadLine(), out val1))
                    break;
                else
                    Console.WriteLine("Unable to read that value, please try again.");
            }

            //Second value
            while (true)
            {
                Console.Write("Enter your second value: ");
                if (double.TryParse(Console.ReadLine(), out val2))
                    break;
                else
                    Console.WriteLine("Unable to read that value, please try again.");
            }

            //Operator choice and calculation
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Which operator do you want to use`? (+, -, *, /)");

                string operatorChoice = Console.ReadLine();
                string calculation = "";

                switch (operatorChoice)
                {
                    case "+":
                        calculation = $"{val1} + {val2} = {Addition(val1, val2)}";
                        break;
                    case "-":
                        calculation = $"{val1} - {val2} = {Subtraction(val1, val2)}";
                        break;
                    case "*":
                        calculation = $"{val1} * {val2} = {Multiplication(val1, val2)}";
                        break;
                    case "/":
                        calculation = $"{val1} / {val2} = {Division(val1, val2)}";
                        break;
                    default:
                        Console.WriteLine("Could not read that operator. Please try again!");
                        break;
                }

                Console.WriteLine(calculation);
                calculatorHistory.Add(calculation);
                break;
            }

        }

        //Prints the calculators history
        private static void PrintHistory()
        {
            Console.WriteLine();
            PrintSeparator();
            Console.WriteLine("\t{0}", "Calculator History:");

            for (int i = 0; i < calculatorHistory.Count; i++)
            {
                Console.WriteLine(" " + calculatorHistory[i]);
            }

            PrintSeparator();
            Console.WriteLine();
        }

        //Print menu
        private static void PrintMenu(string name)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome {0}!", name);
            PrintSeparator();
            Console.WriteLine("\t\t{0}", "*Menu*");
            Console.WriteLine("1) New Calculation");
            Console.WriteLine("2) View History");
            Console.WriteLine("0) Exit Application");
            PrintSeparator();
            Console.WriteLine();
        }

        //Helper method to print a separating line
        private static void PrintSeparator()
        { Console.WriteLine("*---------------------------------------*"); }

        //Math operations
        private static double Addition(double value1, double value2) { return value1 + value2; }
        private static double Subtraction(double value1, double value2) { return value1 - value2; }
        private static double Multiplication(double value1, double value2) { return value1 * value2; }
        private static double Division(double value1, double value2)
        {
            if (value2 != 0.00)
                return value1 / value2;
            else
                return 0;
        }
    }
}
