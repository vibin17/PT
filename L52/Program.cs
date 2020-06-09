using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L52
{
    class Program
    {
        class Team : IComparable<Team>
        {
            public int N;
            public int Members;
            public Team(int n, int members)
            {
                N = n;
                Members = members;
            }
            public int CompareTo(Team b)
            {
                return -this.Members.CompareTo(b.Members);
            }
            public List<int> Seats = new List<int>();
        }
        class Table
        {
            public int N;
            public int Capacity;
            public int reservedSeats = 0;
            public Table(int n, int c)
            {
                N = n;
                Capacity = c;
            }
        }
        static void Main()
        {
            using (StreamReader stream = new StreamReader("file.txt"))
            {
                string input = null;
                while ((input = stream.ReadLine()) != "0 0")
                {
                    int m = Convert.ToInt32(input.Split(new char[] { ' ' })[0]);
                    int n = Convert.ToInt32(input.Split(new char[] { ' ' })[1]);
                    List<Team> teams = new List<Team>();
                    int totalMembers = 0;
                    int[] teamsMembers = stream.ReadLine().Split(new char[] { ' ' }).Select(s => Convert.ToInt32(s)).ToArray();
                    for (int i = 0; i < m; i++)
                    {
                        teams.Add(new Team(i + 1, teamsMembers[i]));
                        totalMembers += teamsMembers[i];
                    }
                    List<Table> tables = new List<Table>();
                    int[] tableCapacity = stream.ReadLine().Split(new char[] { ' ' }).Select(s => Convert.ToInt32(s)).ToArray();
                    for (int i = 0; i < n; i++)
                    {
                        tables.Add(new Table(i + 1, tableCapacity[i]));
                    }
                    List<Team> sortedTeams = new List<Team>(teams);
                    sortedTeams.Sort();
                    foreach (var table in tables)
                    {
                        foreach (var team in sortedTeams)
                        {
                            if (table.Capacity > 0)
                            {
                                if (team.Members > 0)
                                {
                                    table.Capacity--;
                                    team.Members--;
                                    totalMembers--;
                                    team.Seats.Add(table.N);
                                }
                            }
                        }
                    }
                    if (totalMembers == 0)
                    {
                        Console.WriteLine(1);
                        foreach (var team in teams)
                        {
                            foreach (int seat in team.Seats)
                                Console.Write($"{seat} ");
                            Console.WriteLine();
                        }
                    }
                    else Console.WriteLine(0);
                }
            }
        }
    }
}
                 

