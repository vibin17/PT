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
            Console.WriteLine(maxChainLength);
          
        }
    }
}
