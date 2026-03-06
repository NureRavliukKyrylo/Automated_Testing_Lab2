using CalculatorApp;
using NUnit.Framework;
using System;
using Tests;

[TestFixture]
public class TestCaseTest
{
    private Calculator calc;
    private FakeLogger logger;

    [SetUp]
    public void Setup()
    {
        logger = new FakeLogger();    
        calc = new Calculator(logger); 
    }

    [TestCase(2, 3, "+", 5)]
    [TestCase(-5, 3, "+", -2)]
    [TestCase(1000000, 2000000, "+", 3000000)]
    public void Add_TestCases(decimal a, decimal b, string op, decimal expected)
    {
        decimal result = calc.Calculate(a, b, op);

        Assert.AreEqual(expected, result);
        Assert.IsTrue(logger.Messages.Any(), "Logger should have messages");
        Assert.IsTrue(logger.Messages.Last().Contains(a.ToString()) && logger.Messages.Last().Contains(b.ToString()),
            "Logger message should contain input numbers");
    }

    [TestCase(5, 3, "-", 2)]
    [TestCase(-5, 3, "-", -8)]
    [TestCase(0, 10, "-", -10)]
    public void Subtract_TestCases(decimal a, decimal b, string op, decimal expected)
    {
        decimal result = calc.Calculate(a, b, op);

        Assert.AreEqual(expected, result);
        Assert.IsTrue(logger.Messages.Any());
        Assert.IsTrue(logger.Messages.Last().Contains(a.ToString()) && logger.Messages.Last().Contains(b.ToString()));
    }

    [TestCase(2, 3, "*", 6)]
    [TestCase(-5, 3, "*", -15)]
    [TestCase(100000, 20000, "*", 2000000000)]
    public void Multiply_TestCases(decimal a, decimal b, string op, decimal expected)
    {
        decimal result = calc.Calculate(a, b, op);

        Assert.AreEqual(expected, result);
        Assert.IsTrue(logger.Messages.Any());
        Assert.IsTrue(logger.Messages.Last().Contains(a.ToString()) && logger.Messages.Last().Contains(b.ToString()));
    }

    [TestCase(6, 3, "/", 2)]
    [TestCase(-6, 3, "/", -2)]
    [TestCase(0, 5, "/", 0)]
    public void Divide_TestCases(decimal a, decimal b, string op, decimal expected)
    {
        decimal result = calc.Calculate(a, b, op);

        Assert.AreEqual(expected, result);
        Assert.IsTrue(logger.Messages.Any());
        Assert.IsTrue(logger.Messages.Last().Contains(a.ToString()) && logger.Messages.Last().Contains(b.ToString()));
    }

    [TestCase(10, 0, "/")]
    public void Divide_ByZero_Throws(decimal a, decimal b, string op)
    {
        var ex = Assert.Throws<DivideByZeroException>(() => calc.Calculate(a, b, op));
        Assert.AreEqual("Cannot divide by zero", ex.Message);

        Assert.IsTrue(logger.Messages.Any());
        Assert.IsTrue(logger.Messages.Last().Contains("Divide by zero attempt"), "Logger should indicate divide by zero");
    }

    [TestCase(1, 2, "%")]
    [TestCase(0, 0, "x")]
    public void InvalidOperation_Throws(decimal a, decimal b, string op)
    {
        Assert.Throws<ArgumentException>(() => calc.Calculate(a, b, op));

    }
}