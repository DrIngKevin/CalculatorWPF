using System;
using System.Collections.Generic;
using System.Globalization;

namespace CalculatorWPF.Expressions
{
    internal abstract class Expression
    {
        public Expression left;
        public Expression right;

        public abstract double Evaluate(Dictionary<string, double> variables);
    }


}
