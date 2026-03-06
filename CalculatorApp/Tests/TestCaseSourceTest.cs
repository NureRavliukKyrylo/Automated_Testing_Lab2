using CalculatorApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;

public class CalculatorTestData
{
    public static object[] AddTestCases =
    {
        new object[] { 1m, 2m, "+", 3m },
        new object[] { -5m, -10m, "+", -15m },
        new object[] { 1000000m, 5000000m, "+", 6000000m },
        new object[] { -1000000m, 1000000m, "+", 0m }
    };

    public static object[] MultiplyTestCases =
    {
        new object[] { 2m, 3m, "*", 6m },
        new object[] { -2m, 3m, "*", -6m },
        new object[] { 0m, 100m, "*", 0m },
        new object[] { 1000000m, 2000m, "*", 2000000000m }
    };
}

[TestFixture]
public class TestCaseSourceTest
{
    private Calculator calc;
    private FakeLogger logger;

    [SetUp]
    public void Setup()
    {
        logger = new FakeLogger();       
        calc = new Calculator(logger);   
    }

    [Test, TestCaseSource(typeof(CalculatorTestData), "AddTestCases")]
    public void Add_TestCasesSource(decimal a, decimal b, string op, decimal expected)
    {
        decimal result = calc.Calculate(a, b, op);

        Assert.AreEqual(expected, result);

  
        Assert.IsTrue(logger.Messages.Count > 0, "Logger should have at least one message");
        Assert.IsTrue(logger.Messages.Last().Contains(a.ToString()) && logger.Messages.Last().Contains(b.ToString()),
            "Logger message should contain input numbers");
    }

    [Test, TestCaseSource(typeof(CalculatorTestData), "MultiplyTestCases")]
    public void Multiply_TestCasesSource(decimal a, decimal b, string op, decimal expected)
    {
        decimal result = calc.Calculate(a, b, op);

        Assert.AreEqual(expected, result);

        Assert.IsTrue(logger.Messages.Count > 0, "Logger should have at least one message");
        Assert.IsTrue(logger.Messages.Last().Contains(a.ToString()) && logger.Messages.Last().Contains(b.ToString()),
            "Logger message should contain input numbers");
    }
}
