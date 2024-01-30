using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF.Expressions
{
    internal class Variable : Expression
    {
        public Token Name { get; set; }

        public override double Evaluate(Dictionary<string, double> variables)
        {
            if (!variables.ContainsKey(Name.Text))
            {
                throw new Exception("Variable not found");
            }

            return variables[Name.Text];
        }
    }
}
