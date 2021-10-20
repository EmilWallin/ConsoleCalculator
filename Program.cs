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

                int choice = -1;
                while (true)                            //User input
                {
                    Console.Write("Your choice: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                        break;
                    else
                        Console.WriteLine("Only numeral inputs please.");
                }

                //User choice switch
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

        #region Calculation related methods
        //Method for taking values and doing the calculation
        private static void Calculation()
        {
            PrintSeparator();

            //First and second value
            double val1 = UserValueInput("Enter your first value: ");
            double val2 = UserValueInput("Enter your second value: ");
            string calculation = "";

            //Operator choice and calculation
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Which operator do you want to use? (+, -, *, /)");
                Console.WriteLine("(0 to exit.)");

                string operatorChoice = Console.ReadLine();

                switch (operatorChoice)                         //Do calculation based on choice
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
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Could not read that operator. Please try again!");
                        break;
                }
                if (calculation != "")      //Check if calculation was made
                    break;
            }

            Console.WriteLine(calculation);
            calculatorHistory.Add(calculation);
        }

        //User input for value
        private static double UserValueInput(string userPrompt)
        {
            double value;
            while (true)
            {
                Console.Write(userPrompt);
                if (double.TryParse(Console.ReadLine(), out value))
                    break;
                else
                    Console.WriteLine("Unable to read that value, please try again.");
            }
            return value;
        }
        #endregion

        #region Calculation History
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
        #endregion

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

        #region MathOperations
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
        #endregion
    }
}
