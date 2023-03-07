using System;

namespace Assignment2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("------- Assignment 2 -------");
			Console.WriteLine("1. Prime factors");
			Console.WriteLine("2. Array max, min, avg, sum");
			Console.WriteLine("3. Sieve of Eratosthenes");
			Console.WriteLine("4. Toeplitz matrix");
			Console.WriteLine("----------------------------");

			while (true)
			{
				try
				{
					string? strRead;
					int ent = -1;
					Console.Write("Choose a module (1~4) or enter 0 to exit: ");
					strRead = Console.ReadLine();
					if (strRead != null) ent = int.Parse(strRead);

					switch (ent)
					{
						case 0: return;
						case 1:
							{
								int num = -1;
								Console.Write("Enter a positive integer: ");
								strRead = Console.ReadLine();
								if (strRead != null) num = int.Parse(strRead);
								if (num <= 0) throw new Exception();
								for (int i = 2; i <= num; ++i)
								{
									if (num % i == 0)
									{
										Console.Write($"{i} ");
										num /= i;
									}
									while (num % i == 0) num /= i;
								}
								Console.WriteLine();
							}
							break;
						case 2:
							{
								int max = int.MinValue, min = int.MaxValue, sum = 0;
								Console.Write("Enter an integer array: ");
								strRead = Console.ReadLine();
								string[] strReads = Array.Empty<string>();
								if (strRead != null) strReads = strRead.Trim().Split();
								if (strReads.Length == 0) throw new Exception();
								foreach (var str in strReads)
								{
									int ai = int.Parse(str);
									max = Math.Max(max, ai);
									min = Math.Min(min, ai);
									sum += ai;
								}
								double avg = (double)sum / strReads.Length;
								Console.WriteLine($"Max: {max} Min: {min} Avg: {avg} Sum: {sum}");
							}
							break;
						case 3:
							{
								int num = 100;
								int[] arr = new int[num + 1]; // 等于0表示被筛去
								for (int i = 2; i <= num; ++i) arr[i] = i;
								for (int i = 2; i <= num; ++i)
								{
									for (int j = i * i; j <= num; j += i) arr[j] = 0;
								}
								Console.Write("Primes in range 2~100: [");
								foreach (var i in arr)
								{
									if (i != 0) Console.Write($"{i} ");
								}
								Console.WriteLine("]");
							}
							break;
						case 4:
							{
								int m = -1, n = 0;
								int c = 0; // 托普利茨矩阵中的对角线常数
								bool isToeplitz = true;
								Console.Write("Enter M: ");
								strRead = Console.ReadLine();
								if (strRead != null) m = int.Parse(strRead);
								if (m < 0) throw new Exception();
								Console.WriteLine("Enter a M*N matrix: ");
								for (int i = 0; i < m; ++i)
								{
									Console.Write("|");
									strRead = Console.ReadLine();

									string[] strReads = Array.Empty<string>();
									if (strRead != null) strReads = strRead.Trim().Split();
									if (i == 0) n = strReads.Length;
									else if (strReads.Length != n) throw new Exception();

									if (i >= strReads.Length) continue;
									int diagElem = int.Parse(strReads[i]);
									if (i == 0) c = diagElem;
									if (diagElem != c) isToeplitz = false;
								}
								Console.WriteLine($"Is Toeplitz matrix: {isToeplitz}");
							}
							break;
						default: throw new Exception();
					}
				}
				catch (Exception)
				{
					Console.WriteLine("Invalid input!");
				}
				Console.WriteLine();
			}
		}
	}
}