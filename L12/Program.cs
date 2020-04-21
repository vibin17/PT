using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L12
{
    class Program
    {
        static void Main()
        {
            try
            {
               using (StreamReader stream = new StreamReader("file.txt"))
                {
                    int blocks = Convert.ToInt32(stream.ReadLine());
                    stream.ReadLine();
                    for (int i = 0; i < blocks; i++)
                    {
                        int n = Convert.ToInt32(stream.ReadLine());
                        int[][] tricks = new int[n][];
                        for (int j = 0; j < n; j++)
                            tricks[j] = stream.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray();
                        string input;
                        List<int> usedTricks = new List<int>();
                        while ((input = stream.ReadLine()) != null)
                            usedTricks.Add(Convert.ToInt32(input));
                        Card[] set = Card.GenerateSet();
                        for (int j = 0; j < tricks.Length; j++)
                        {
                            if (usedTricks.Contains(j + 1))
                                set = Trick(set, tricks[j]);
                        }
                        string result = string.Join("\n", set.Select(x => x.Info()).ToArray()) + "\n";
                        Console.Write(result);
                        Console.WriteLine("---------------");
                    }
                }
            }
            catch(IOException IOe)
            {
                Console.WriteLine(IOe.Message);
            }
            catch(FormatException Fe)
            {
                Console.WriteLine(Fe.Message);
            }
        }
        static Card[] Trick(Card[] set, int[] trick)
        {
            Card[] newSet = new Card[set.Length];
            for (int i = 0; i < 52; i++)
            {
                var trickCardNumb = trick[i] - 1;
                newSet[i] = set[trickCardNumb];
            }
            return newSet;
        }
    }
}
