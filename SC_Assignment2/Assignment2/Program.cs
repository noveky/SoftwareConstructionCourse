using System;
using System.Runtime.Intrinsics.X86;

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
								List<int> facs = Problem1(num);
								foreach (var fac in facs)
								{
									Console.Write($"{fac} ");
								}
								Console.WriteLine();
							}
							break;
						case 2:
							{
								Console.Write("Enter an integer array: ");
								strRead = Console.ReadLine();
								string[] strReads = Array.Empty<string>();
								if (strRead != null) strReads = strRead.Trim().Split();
								if (strReads.Length == 0) throw new Exception();
								int[] arr = new int[strReads.Length];
								for (int i = 0; i < strReads.Length; ++i)
								{
									int ai = int.Parse(strReads[i]);
									arr[i] = ai;
								}
								List<object> result = Problem2(arr);
								Console.WriteLine($"Max: {result[0]} Min: {result[1]} Avg: {result[2]} Sum: {result[3]}");
							}
							break;
						case 3:
							{
								int num = 100;
								int[] arr = new int[num + 1]; // 等于0表示被筛去
								Problem3(arr);
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
								int M = -1, N = 0;
								Console.Write("Enter M: ");
								strRead = Console.ReadLine();
								if (strRead != null) M = int.Parse(strRead);
								if (M < 0) throw new Exception();
								Console.WriteLine("Enter a M*N matrix: ");
								List<int>[] rows = new List<int>[M];
								for (int i = 0; i < M; ++i)
								{
									Console.Write("|");
									strRead = Console.ReadLine();
									
									string[] strElems = Array.Empty<string>();
									if (strRead != null) strElems = strRead.Trim().Split();
									if (i == 0) N = strElems.Length;
									else if (strElems.Length != N) throw new Exception(); // 矩阵输入有效性检测

									rows[i] = new List<int>();
									foreach (var strElem in strElems)
									{
										rows[i].Add(int.Parse(strElem));
									}
								}
								int[,] matrix = new int[M, N];
								for (int i = 0; i < M; ++i)
								{
									for (int j = 0; j < N; ++j)
									{
										matrix[i, j] = rows[i][j];
									}
								}
								bool isToeplitz = Problem4(matrix);
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

		static List<int> Problem1(int num)
		{
			if (num <= 0) throw new Exception();
			List<int> facs = new List<int>();
			for (int i = 2; i <= num; ++i)
			{
				if (num % i == 0)
				{
					facs.Add(i);
					num /= i;
				}
				while (num % i == 0) num /= i;
			}
			return facs;
		}

		static List<object> Problem2(int[] arr)
		{
			List<object> ret = new List<object>();
			int max = int.MinValue, min = int.MaxValue, sum = 0;
			foreach (var ai in arr)
			{
				max = Math.Max(max, ai);
				min = Math.Min(min, ai);
				sum += ai;
			}
			double avg = (double)sum / arr.Length;
			ret.Add(max);
			ret.Add(min);
			ret.Add(avg);
			ret.Add(sum);
			return ret;
		}

		static void Problem3(int[] arr)
		{
			int num = arr.Length - 1;
			for (int i = 2; i <= num; ++i) arr[i] = i;
			for (int i = 2; i <= num; ++i)
			{
				for (int j = i * i; j <= num; j += i) arr[j] = 0;
			}
		}

		static bool Problem4(int[,] matrix)
		{
			int M = matrix.GetLength(0);
			int N = matrix.GetLength(1);
			int c = 0; // 托普利茨矩阵中的对角线常数
			bool isToeplitz = true;
			for (int i = 0; i < M; ++i)
			{
				// 托普利茨矩阵判定
				if (i >= N) continue;
				int diagElem = matrix[i, i];
				if (i == 0) c = diagElem;
				if (diagElem != c) isToeplitz = false;
			}
			return isToeplitz;
		}
	}
}