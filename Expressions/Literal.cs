using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF.Expressions
{
    internal class Literal : Expression
    {
        public Token Value { get; set; }

        public override double Evaluate(Dictionary<string, double> variables)
        {
            if (double.TryParse(Value.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
            {
                return result;
            }
            else
            {
                // Handle the error
                throw new FormatException($"Unable to parse '{Value.Text}' as a double.");
            }
        }
    }
}
