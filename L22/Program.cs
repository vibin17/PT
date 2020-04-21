using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace L22
{
    class Program
    {
        static void Main()
        {
            using (StreamReader stream = new StreamReader("file.txt"))
            {
                int blocks = Convert.ToInt32(stream.ReadLine());
                stream.ReadLine();
                for (int i = 0; i < blocks; i++)
                {
                    int n = Convert.ToInt32(stream.ReadLine());
                    Order[] orders = new Order[n];
                    for (int j = 0; j < n; j++)
                    {
                        string input = stream.ReadLine();
                        orders[j] = new Order(j + 1, Convert.ToInt32(input.Split(' ')[0]), Convert.ToInt32(input.Split(' ')[1]));

                    }
                    Array.Sort(orders);
                    foreach (var ord in orders)
                        Console.Write($"{ord.n} ");
                    Console.WriteLine();
                }
            }
        }
    }
}
