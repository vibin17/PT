using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace L21
{
    class Program
    {
        const string keySent = "the quick brown fox jumps over the lazy dog";
        static void Main()
        {
            try
            {
                using (StreamReader stream = new StreamReader("file.txt"))
                {
                    int blocks = Convert.ToInt32(stream.ReadLine());
                    for (int i = 0; i < blocks; i++)
                    {
                        stream.ReadLine();
                        string input = null;
                        List<string> sentences = new List<string>();
                        while ((input = stream.ReadLine()) != null)
                            sentences.Add(input);
                        Tuple<bool, Dictionary<char, char>> tuple = new Tuple<bool, Dictionary<char, char>>(false, null);
                        for (int j = 0; j < sentences.Count && !tuple.Item1; j++)
                        {
                            tuple = KeySentCheck(sentences[j]);
                        }
                        if (tuple.Item1)
                        {
                            string res = "";
                            foreach (var sent in sentences)
                                res += Decrypt(sent, tuple.Item2) + "\n";
                            Console.WriteLine(res);
                        }
                        else Console.WriteLine("No solution");
                    }
                }
            }
            catch (IOException IOe)
            {
                Console.WriteLine(IOe.Message);
            }
            catch (FormatException Fe)
            {
                Console.WriteLine(Fe.Message);
            }
        }
        static Tuple<bool, Dictionary<char, char>> KeySentCheck(string str)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();
            for (char i = 'a'; i <= 'z'; i++)
            {
                dict[i] = i;
            }
            int minL = keySent.Length < str.Length ? keySent.Length : str.Length;
            for (int i = 0; i < minL; i++)
            {
                if (str[i] != keySent[i])
                {
                    dict[str[i]] = keySent[i];
                }
            }
            string res = "";
            for (int i = 0; i < str.Count(); i++)
            {

                res += dict.Keys.Contains(str[i]) ? dict[str[i]] : str[i];
            }
            return new Tuple<bool, Dictionary<char, char>>(res == keySent, dict);
        }
        static string Decrypt (string str, Dictionary<char, char> dict)
        {
            string res = "";
            for (int i = 0; i < str.Count(); i++)
            {

                res += dict.Keys.Contains(str[i]) ? dict[str[i]] : str[i];
            }
            return res;
        }
    }   
}
