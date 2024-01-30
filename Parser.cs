using CalculatorWPF;
using CalculatorWPF.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Parser
{
    public List<Token> tokens;
    public int index;

    public Parser(List<Token> tokens)
    {
        this.tokens = tokens;
        this.index = 0;
    }

    public Expression Parse()
    {
        return AddSub();
    }

    private Expression AddSub()
    {
        Expression result = MulDiv();

        while (index < tokens.Count && (tokens[index].Text == "+" || tokens[index].Text == "-"))
        {
            Token op = tokens[index++];
            Expression right = MulDiv();
            result = new PlusMinus { left = result, Operator = op, right = right };
        }

        return result;
    }

    private Expression MulDiv()
    {
        Expression result = Pow();

        while (index < tokens.Count && (tokens[index].Text == "*" || tokens[index].Text == "/"))
        {
            Token op = tokens[index++];
            Expression right = Pow();
            result = new MalDiv { left = result, Operator = op, right = right };
        }

        return result;
    }

    private Expression Pow()
    {
        Expression result = Literal();

        while (index < tokens.Count && tokens[index].Text == "^")
        {
            Token op = tokens[index++];
            Expression right = Literal();
            result = new Pow { left = result, Operator = op, right = right };
        }

        return result;
    }

    private Expression Literal()
    {
        if (tokens[index].type == Token.Type.Number)
        {
            return new Literal { Value = tokens[index++] };
        }
        else if (tokens[index].type == Token.Type.Variable)
        {
            return new Variable { Name = tokens[index++] };
        }
        else if (tokens[index].Text == "(")
        {
            index++; // skip '('
            Expression result = AddSub();
            if (tokens[index].Text != ")")
            {
                throw new Exception("Expected ')'");
            }
            index++; // skip ')'
            return result;
        }
        else
        {
            throw new Exception("Expected a number, variable, or '('");
        }
    }
}
