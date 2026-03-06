using CalculatorApp;
using System;

class Program
{
    static void Main()
    {
        ILogger logger = new ConsoleLogger();
        Calculator calc = new Calculator(logger);

        Console.WriteLine("Welcome to the Calculator!");
        Console.WriteLine("Enter 'exit' to quit.\n");

        while (true)
        {
            Console.WriteLine("Enter operation (+, -, *, /) or 'exit' to quit:");
            string operation = Console.ReadLine();
            if (operation.ToLower() == "exit")
                break;

            if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
            {
                Console.WriteLine("Invalid operation\n");
                continue;
            }

            Console.WriteLine("Enter first number:");
            string input1 = Console.ReadLine();
            if (input1.ToLower() == "exit")
                break;

            Console.WriteLine("Enter second number:");
            string input2 = Console.ReadLine();
            if (input2.ToLower() == "exit")
                break;

            if (!decimal.TryParse(input1, out decimal num1) ||
                !decimal.TryParse(input2, out decimal num2))
            {
                Console.WriteLine("Invalid number format\n");
                continue;
            }

            try
            {
                decimal result = calc.Calculate(num1, num2, operation);
                Console.WriteLine($"Result: {result}\n");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
        }

        Console.WriteLine("Calculator closed. Goodbye!");
    }
}