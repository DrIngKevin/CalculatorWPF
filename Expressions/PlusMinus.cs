using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF.Expressions
{
    internal class PlusMinus : Expression
    {
        public Token Operator { get; set; }

        public override double Evaluate(Dictionary<string, double> variables)
        {
            double leftVal = left.Evaluate(variables);
            double rightVal = right.Evaluate(variables);

            switch (Operator.Text)
            {
                case "+":
                    return leftVal + rightVal;
                case "-":
                    return leftVal - rightVal;
                default:
                    throw new Exception("Invalid operator");
            }
        }
    }
}
