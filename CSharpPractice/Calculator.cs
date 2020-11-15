using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice
{
    class Calculator
    {

        public double Evaluate(String exp)
        {
            exp = exp.Replace(" ", "");
            char[] tokens = exp.ToCharArray();
            Stack<int> values = new Stack<int>();
            Stack<char> ops = new Stack<char>();

            for(int i=0; i < tokens.Length; ++i)
            {
                if (Char.IsDigit(tokens[i]))
                {
                    StringBuilder buff = new StringBuilder();
                    // Number might contain more than one digit
                    while(i < tokens.Length && Char.IsDigit(tokens[i]))
                    {
                        buff.Append(tokens[i++]);
                    }
                }
            }

            return 0.0;
        }

    }
}
