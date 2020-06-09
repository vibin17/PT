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
                    if (n > 1000 || n < 1)
                        Console.WriteLine("No solution");
                    else
                        Console.WriteLine(GetNumbsQuant(n));
                }
            }
        }
        static int GetNumbsQuant(int n)
        {
            List<int[]> numbs = new List<int[]>();
            int[] numb = new int[] { 1 };
            numbs.Add(numb);
            int bits = 1, quant = 0;
            while (bits <= n)
            {
                numb = IncrNumb(numb);
                numbs.Add(numb);
                bits = numb.Length;
            }
            foreach (var number in numbs)
                if (CalcSum(number) == n) quant++;
            return quant;
        }
        static int CalcSum(int[] numb)
        {
            int sum = 0;
            foreach (var digit in numb)
                sum += digit != 4 ? digit : 1;
            return sum;
        }
        static int[] IncrNumb(int[] numb)
        {
            List<int> newNumb = new List<int>();
            int shift = 1;
            for (int i = 0; i < numb.Length; i++)
            {
                int digit = (numb[i] + shift) % 5;
                newNumb.Add(digit == 0 ? 1 : digit);
                shift = (numb[i] + shift) / 5;
            }
            if (shift != 0) newNumb.Add(shift);
            return newNumb.ToArray();
        }
    }
}

