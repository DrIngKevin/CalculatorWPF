using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF
{
    internal class Token
    {
        public enum Type { Variable, Number, WeakOperator, StrongOperator, StrongestOperator, Bracket, EndLine, Error};
        public string Text { get; set; } = string.Empty;
        public Type type { get; set; } = Type.Error;
    }
}
