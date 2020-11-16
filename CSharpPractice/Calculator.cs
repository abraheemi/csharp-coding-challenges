 using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice
{
    class Calculator
    {

        public static double Evaluate(String exp)
        {
            exp = exp.Replace(" ", "");
            char[] tokens = exp.ToCharArray();
            Stack<double> values = new Stack<double>();
            Stack<char> ops = new Stack<char>();

            for(int i=0; i < tokens.Length; ++i)
            {
                //if (Char.IsDigit(tokens[i]))
                if (tokens[i] >= '0' && tokens[i] <= '9')
                {
                    StringBuilder buff = new StringBuilder();
                    // Number might contain more than one digit
                    int j = i + 1;
                    //while (j < tokens.Length && tokens[i] >= '0' && tokens[i] <= '9')
                    while (i < tokens.Length && tokens[i] >= '0' && tokens[i] <= '9')
                    {
                        buff.Append(tokens[i++]);
                        j++;
                    }
                    // Must point i to last digit.
                    // Loop will increment i to next position.
                    //i = j - 1;
                    i--;
                    values.Push(int.Parse(buff.ToString()));
                }
                else if(tokens[i] == '(')
                {
                    ops.Push(tokens[i]);
                }
                else if(tokens[i] == ')')
                {
                    while(ops.Peek() != '(')
                    {
                        values.Push(EvalOp(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    ops.Pop(); // Pops remaining parentheses
                }
                else if (IsOp(tokens[i]))
                {
                    // While the top of ops has same or greater precedence
                    // to current token, apply operator on top of ops to
                    // top two numbers in values stack
                    while(ops.Count > 0 && HasPrecedence(tokens[i], ops.Peek()))
                    {
                        values.Push(EvalOp(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    // Push current operator
                    ops.Push(tokens[i]);
                }
            }

            // At this point, the expression has been parsed.
            // Now apply remaining ops to remaining values.
            while (ops.Count > 0)
            {
                values.Push(EvalOp(ops.Pop(), values.Pop(), values.Pop()));
            }
            // Top value is the result
            return values.Pop();
        }

        public static double EvalOp(char op, double a, double b)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/':
                    if(b == 0)
                    {
                        throw new System.NotSupportedException("Cannot divide by zero");
                    }
                    return a / b;
            }
            return 0;
        }

        public static bool IsOp(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        public static bool HasPrecedence(char op1, char op2)
        {
            if(op2 == '(' || op2 == ')')
            {
                return false;
            }
            if((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
