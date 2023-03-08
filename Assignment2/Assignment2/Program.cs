using System;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Assignment2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// I/O流程
			while (true)
			{
				try
				{
					// 模块说明
					Console.Clear();
					Console.WriteLine("------- Assignment 2 -------");
					Console.WriteLine("1. Prime factors");
					Console.WriteLine("2. Array max, min, avg, sum");
					Console.WriteLine("3. Sieve of Eratosthenes");
					Console.WriteLine("4. Toeplitz matrix");
					Console.WriteLine("----------------------------");

					// 选择模块输入
					string? strRead;
					int moduleIndex = -1;
					Console.Write("Choose a module (1~4) or enter 0 to exit: ");
					strRead = Console.ReadLine();
					if (strRead != null) moduleIndex = int.Parse(strRead);

					// 模块调用
					CallModule(moduleIndex);
				}
				catch (Exception)
				{
					Console.WriteLine("Invalid input!");
				}

				// 暂停
				Console.WriteLine();
				Console.Write("Press any key to restart...");
				Console.ReadKey();
			}
		}

		static void CallModule(int index)
		{
			string? strRead;
			switch (index)
			{
				case 0: return;
				case 1:
					{
						// 输入
						int num = -1;
						Console.Write("Enter a positive integer: ");
						strRead = Console.ReadLine();
						if (strRead != null) num = int.Parse(strRead);

						// 解题
						List<int> facs = Problem1(num);

						// 输出
						StringBuilder stbWrite = new StringBuilder($"{num} = ");
						foreach (var fac in facs)
						{
							stbWrite.Append($"{fac} * ");
						}
						stbWrite.Remove(stbWrite.Length - 3, 3);
						Console.WriteLine(stbWrite);
					}
					break;
				case 2:
					{
						// 输入
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

						// 解题
						List<object> result = Problem2(arr);

						// 输出
						Console.WriteLine($"Max: {result[0]} Min: {result[1]} Avg: {result[2]} Sum: {result[3]}");
					}
					break;
				case 3:
					{
						// 初始化
						int num = 100;
						int[] arr = new int[num + 1]; // 等于0表示被筛去

						// 解题
						Problem3(arr);

						// 输出
						StringBuilder stbWrite = new StringBuilder("Primes in range 2~100: [");
						foreach (var i in arr)
						{
							if (i != 0) stbWrite.Append($"{i} ");
						}
						stbWrite[stbWrite.Length - 1] = ']';
						Console.WriteLine(stbWrite);
					}
					break;
				case 4:
					{
						// 输入
						int M = -1, N = 0;
						Console.Write("Enter M: ");
						strRead = Console.ReadLine();
						if (strRead != null) M = int.Parse(strRead);
						if (M < 0) throw new Exception();
						Console.WriteLine("Enter a M * N matrix: ");
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

						// 解题
						bool isToeplitz = Problem4(matrix);

						// 输出
						Console.WriteLine($"Is Toeplitz matrix: {isToeplitz}");
					}
					break;
				default: throw new Exception();
			}
		}

		static List<int> Problem1(int num)
		{
			if (num <= 0) throw new Exception();
			List<int> facs = new List<int>();
			for (int i = 2; i * i <= num; ++i)
			{
				while (num % i == 0)
				{
					facs.Add(i);
					num /= i;
				}
			}
			if (num != 1) facs.Add(num);
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
				if (i >= N) continue;
				int diagElem = matrix[i, i];
				if (i == 0) c = diagElem;
				if (diagElem != c) isToeplitz = false;
			}
			return isToeplitz;
		}
	}
}