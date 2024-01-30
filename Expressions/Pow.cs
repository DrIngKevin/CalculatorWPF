using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF.Expressions
{
    internal class Pow : Expression
    {
        public Token Operator { get; set; }

        public override double Evaluate(Dictionary<string, double> variables)
        {
            double leftVal = left.Evaluate(variables);
            double rightVal = right.Evaluate(variables);

            return Math.Pow(leftVal, rightVal);
        }
    }
}
