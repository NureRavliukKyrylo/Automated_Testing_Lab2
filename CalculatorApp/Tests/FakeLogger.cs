using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp;

namespace Tests
{
    public class FakeLogger : ILogger
    {
        public List<string> Messages { get; } = new List<string>();

        public void Log(string message)
        {
            Messages.Add(message);
        }
    }
}
