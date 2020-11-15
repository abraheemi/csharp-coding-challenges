using System;
using System.Data;

namespace CSharpPractice
{
    class Program
    {

		static void calculate()
        {
            String exp = "2 + -10 / 2 * (3 - 1) / 2";
            Console.WriteLine("Calculate: " + exp);

            DataTable dt = new DataTable();
            Console.WriteLine("DataTable: " + (double)dt.Compute(exp, ""));

            Console.WriteLine("Calculator: " + Calculator.Evaluate(exp));
			
        }

        static void Main(string[] args)
        {
            calculate();


		}
    }
}
