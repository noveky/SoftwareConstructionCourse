using System;

namespace SC_Assignment2
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
					string? read;
					int ent = -1;
					Console.Write("Choose a module (1~4): ");
					read = Console.ReadLine();
					if (read != null) ent = int.Parse(read);

					switch (ent)
					{
						case 1:
							{
								int num = -1;
								Console.Write("Enter a positive integer: ");
								read = Console.ReadLine();
								if (read != null) num = int.Parse(read);
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
								read = Console.ReadLine();
								string[] strArray = Array.Empty<string>();
								if (read != null) strArray = read.Split();
								if (strArray.Length == 0) throw new Exception();
								foreach (var str in strArray)
								{
									int ai = int.Parse(str);
									max = Math.Max(max, ai);
									min = Math.Min(min, ai);
									sum += ai;
								}
								double avg = (double)sum / strArray.Length;
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
								read = Console.ReadLine();
								if (read != null) m = int.Parse(read);
								if (m < 0) throw new Exception();
								Console.WriteLine("Enter a M*N matrix: ");
								for (int i = 0; i < m; ++i)
								{
									Console.Write("|");
									read = Console.ReadLine();

									string[] strArray = Array.Empty<string>();
									if (read != null) strArray = read.Split();
									if (i == 0) n = strArray.Length;
									else if (strArray.Length != n) throw new Exception();

									if (i >= strArray.Length) continue;
									int diagElem = int.Parse(strArray[i]);
									if (i == 0) c = diagElem;
									if (diagElem != c) isToeplitz = false;
								}
								Console.WriteLine($"Is Toeplitz matrix: {isToeplitz}");
							}
							break;
						default: break;
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