using System;
using System.Data;

namespace CSharpPractice
{
    class Program
    {

		static void calculate()
        {
			Console.Write("Calculate: ");
			String input = Console.ReadLine();
			MyStack stack = new MyStack();

			foreach(char c in input)
            {
                if (Char.IsDigit(c))
                {

                }
				stack.Push(c);
            }
        }

        static void Main(string[] args)
        {
			Console.WriteLine("Calculate");
            DataTable dt = new DataTable();
            double answer = (double)dt.Compute("2 + -10 / 2 * (3 - 1) / 2", "");
            Console.WriteLine(answer);


		}
    }
}
