using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L32
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
                    int n = Convert.ToInt32(input);
                    if (n >= 1000 || n < 1 )
                        Console.WriteLine("No solution");
                    else
                    {
                        Console.WriteLine(GetNumbsQuant(n));
                    }
                }
            }
        }
        static int GetNumbsQuant(int n)
        {
            int bits = 1, s = 0;
            List<int[]> numbs;
            while (bits < n)
            {
                for (int i = 1; i <= bits; i++)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        
                    }
                }
                bits++;
            }


        }
        static bool Calc(int[] numbs)
        {

        }
    }
}

