using System;

namespace ConsoleCalculator
{
	public class Program
	{
		public static void Main(string[] args)
		{
			double opr1 = 0, opr2 = 0, result;
			char? opt = null;
			string? input;
			try
			{
				Console.Write("Input operand 1 (double): ");
				input = Console.ReadLine();
				if (input != null) opr1 = double.Parse(input);
				Console.Write("Input operator (+, -, *, /): ");
				input = Console.ReadLine();
				if (input != null) opt = char.Parse(input);
				Console.Write("Input operand 2 (double): ");
				input = Console.ReadLine();
				if (input != null) opr2 = double.Parse(input);
				switch (opt)
				{
					case '+': result = opr1 + opr2; break;
					case '-': result = opr1 - opr2; break;
					case '*': result = opr1 * opr2; break;
					case '/': result = opr1 / opr2; break;
					default: throw new Exception();
				}
				Console.WriteLine(result);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}
	}
}