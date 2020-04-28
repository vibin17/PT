using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L31
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
                    UInt64 n = Convert.ToUInt64(input);
                    if (n >= 10000 || n == 0 || n % 2 == 0 || n % 5 == 0)
                        Console.WriteLine("No solution");
                    else
                        Console.WriteLine(GetUnits(n));
                    
                }
            }
        }
        static int GetUnits(UInt64 n)
        {
            int[] notUnits = new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 1; (UInt64)i * n <= UInt64.MaxValue; i++)
            {
                if (i % 2 == 0 || i % 5 == 0)
                    continue;
                int[] digs = GetDigitsArray((UInt64)i * n);
                if (digs.Intersect(notUnits).ToArray().Length == 0)
                    return digs.Length;
            }
            return 0;
        }
        static int[] GetDigitsArray(UInt64 n)
        {
            List<int> digs = new List<int>();
            UInt64 d = 10;
            while (n > 0)
            {
                digs.Add((int)(n % d));
                n /= 10;
            }
            digs.Reverse();
            return digs.ToArray();
        }
    }
}
