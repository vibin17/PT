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
        class Town : IComparable<Town>
        {
            public int id;
            public Town(int a) { id = a; }
            public List<Town> AdjTowns = new List<Town>();
            public bool mark = false;
            static public void LinkTowns(Town t1, Town t2)
            {
                t1.AdjTowns.Add(t2);
                t2.AdjTowns.Add(t1);
            }
            static public Town GetTownFromList(Town[] towns, int townId)
            {
                foreach (var town in towns)
                    if (townId == town.id) return town;
                return null;
            }
            public int CompareTo(Town t)
            {
                return this.AdjTowns.Count.CompareTo(t.AdjTowns.Count);
            }
        }
        static void Main(string[] args)
        {
            using (StreamReader str = new StreamReader("file.txt"))
            {
                string input = str.ReadLine();
                int n = Convert.ToInt32(input.Split(' ')[0]);
                int m = Convert.ToInt32(input.Split(' ')[1]);
                Town[] towns = new Town[n];
                for (int i = 0; i < n; i++)
                    towns[i] = new Town(i + 1);
                for (int i = 0; i < m; i++)
                {
                    input = str.ReadLine();
                    int t1 = Convert.ToInt32(input.Split(' ')[0]);
                    int t2 = Convert.ToInt32(input.Split(' ')[1]);
                    Town.LinkTowns(Town.GetTownFromList(towns, t1), Town.GetTownFromList(towns, t2));
                }
                Array.Sort(towns);
                int stations = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    bool Linked = false;
                    foreach (var adjTown in towns[i].AdjTowns)
                    {
                        if (adjTown.mark) Linked = true;
                    }
                    if (!Linked)
                    {
                        towns[i].mark = true;
                        stations++;
                    }
                }
                Console.WriteLine(stations);
            }
        }
    }
}
