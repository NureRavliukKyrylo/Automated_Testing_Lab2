using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Calculator
    {
        private readonly ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        public decimal Add(decimal a, decimal b)
        {
            decimal result = a + b;
            _logger.Log($"Add: {a} + {b} = {result}");
            return result;
        }

        public decimal Subtract(decimal a, decimal b)
        {
            decimal result = a - b;
            _logger.Log($"Subtract: {a} - {b} = {result}");
            return result;
        }

        public decimal Multiply(decimal a, decimal b)
        {
            decimal result = a * b;
            _logger.Log($"Multiply: {a} * {b} = {result}");
            return result;
        }

        public decimal Divide(decimal a, decimal b)
        {
            if (b == 0)
            {
                _logger.Log("Divide by zero attempt");
                throw new DivideByZeroException("Cannot divide by zero");
            }

            decimal result = a / b;
            _logger.Log($"Divide: {a} / {b} = {result}");
            return result;
        }

        public decimal Calculate(decimal a, decimal b, string op)
        {
            return op switch
            {
                "+" => Add(a, b),
                "-" => Subtract(a, b),
                "*" => Multiply(a, b),
                "/" => Divide(a, b),
                _ => throw new ArgumentException("Invalid operation")
            };
        }
    }
}
