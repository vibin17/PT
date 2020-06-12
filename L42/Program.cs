using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L42
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader str = new StreamReader("file.txt"))
            {
                string input = null;
                while ((input = str.ReadLine()) != null)
                {
                    int m = Convert.ToInt32(input.Split(new char[] { ' ' })[0]);
                    int n = Convert.ToInt32(input.Split(new char[] { ' ' })[1]);
                    int[,] matrix = new int[m, n];
                    int[,] dp = new int[m, n];
                    int[,] next = new int[m, n];
                    for (int i = 0; i < m; i++)
                    {
                        input = str.ReadLine();
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = Convert.ToInt32(input.Split(new char[] { ' ' })[j]);
                        }
                    }
                    for (int i = 0; i < m; i++)
                    {
                        dp[i, n - 1] = matrix[i, n - 1];
                    }
                    int y = 0;
                    for (int j = n - 2; j >= 0; j--)
                        for (int i = 0; i < m; i++)
                        {
                            int cur = Int32.MaxValue;
                            for (int k = -1; k <= 1; k++)
                            {
                                y = (i + k + m) % m;

                                if (dp[y, j + 1] < cur || (dp[y, j + 1] == cur && y < next[i, j]))
                                {
                                    cur = dp[y, j + 1];
                                    next[i, j] = y;
                                }
                            }
                            dp[i, j] = matrix[i, j] + cur;
                        }
                    int chainWeight = Int32.MaxValue;
                    for (int i = 0; i < m; i++)
                        if (dp[i, 0] < chainWeight)
                        {
                            chainWeight = dp[i, 0];
                            y = i;
                        }
                    Console.Write(y + 1);
                    for (int i = 0; i < n - 1; i++)
                    {
                        y = next[y, i];
                        Console.Write(" ");
                        Console.Write(y + 1);
                    }
                    Console.WriteLine();
                    Console.WriteLine(chainWeight);
                }
            }
        }
    }
}

