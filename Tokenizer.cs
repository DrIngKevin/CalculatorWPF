using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorWPF
{
    internal class Tokenizer
    {
        //static Regex wholeRegex = new Regex(@"^[a-z]|\d.\d?|\+|\-|\*|\/|\^|\(|\)$");
        static Regex wholeRegex = new Regex(@"(\d+\.\d+|\(|[a-z]|\d+|\)|\+|\-|\/|\*|\^|$)");
        static Regex variableRegex = new Regex(@"^([a-z])$");
        static Regex numberRegex = new Regex(@"^(\d(.\d)?)$");
        static Regex weakOperatorRegex = new Regex(@"^(\+|\-)");
        static Regex strongOperatorRegex = new Regex(@"^(\*|\/)$");
        static Regex strongestOperatorRegex = new Regex(@"^(\^)$");
        static Regex bracketRegex = new Regex(@"^(\(|\))$");

        public static List<Token> Tokenize(string mathExpr)
        {
            List<Token> tokens = new List<Token>();
            MatchCollection collection = wholeRegex.Matches(mathExpr);

            foreach (Match m in collection)
            {
                Token token = new Token
                {
                    Text = m.Value,
                    type = m.Value switch
                    {
                        var t when variableRegex.IsMatch(t) => Token.Type.Variable,
                        var t when numberRegex.IsMatch(t) => Token.Type.Number,
                        var t when weakOperatorRegex.IsMatch(t) => Token.Type.WeakOperator,
                        var t when strongOperatorRegex.IsMatch(t) => Token.Type.StrongOperator,
                        var t when strongestOperatorRegex.IsMatch(t) => Token.Type.StrongestOperator,
                        var t when bracketRegex.IsMatch(t) => Token.Type.Bracket,
                        var t when t.Equals(string.Empty) => Token.Type.EndLine,
                        _ => Token.Type.Error
                    }
                };
                tokens.Add(token);
            }

            return tokens;
        }
    }
}
