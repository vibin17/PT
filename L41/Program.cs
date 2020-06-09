using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L41
{
    class Program
    {
        class Town
        {
            Town() { }
            public List<Town> Links = new List<Town>();
            bool mark = false;
        }
        static void Main(string[] args)
        {
            using (StreamReader str = new StreamReader("file.txt"))
            {
                string input = str.ReadLine();
                int n = Convert.ToInt32(input.Split(' ')[0]);
                int m = Convert.ToInt32(input.Split(' ')[1]);
                Town[] towns = new Town[n];
                for (int i = 0; i < m; i++)
                {
                    input = str.ReadLine();
                    int town1 = Convert.ToInt32(input.Split(' ')[0]);
                    int town2 = Convert.ToInt32(input.Split(' ')[1]);
                    towns[town1 - 1].Links.Add(towns[town2 - 1]);
                    towns[town2 - 1].Links.Add(towns[town1 - 1]);
                }
            }
        }
    }
}
