using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L51
{
    class Program
    {
        static List<int> chains = new List<int>();
        static int CompareCount(string s1, string s2)
        {
            int difs = 0;
            List<char> diffLetters = new List<char>();
            if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length; i++)
                    if (s1[i] != s2[i]) difs++;
            }
            else
            {
                int minL = s1.Length > s2.Length ? s2.Length : s1.Length;
                for (int i = 0; i < minL; i++)
                    if (s1[i] != s2[i]) difs++;
                difs += Math.Abs(s1.Length - s2.Length);
            }
            return difs;
        }
        static void Chain(List<string> words, string prev, int curChain, string schain)
        {
            bool changed = false;
            List<string> newWords = new List<string>(words);
            newWords.Remove(prev);
            foreach (var word in newWords)
            {
                if (CompareCount(prev, word) == 1)
                {
                    changed = true;
                    Chain(newWords, word, curChain + 1, schain + word + " ");
                }
            }
            if (!changed)
            {
                chains.Add(curChain);
                Console.WriteLine(schain);
            }
        }
        static int Start(List<string> words)
        {
            foreach(var word in words)
            {
                Chain(words, word, 1, word + " ");
            }
            return chains.Max();
        }
        static void Main()
        {
            List<string> words = new List<string>();
            int maxChainLength = 0;
            using (StreamReader str = new StreamReader("file.txt"))
            {
                string input = null;
                while ((input = str.ReadLine()) != null)
                {
                    words.Add(input);
                }
            }
            Console.WriteLine(Start(words));    
        }
    }
}
