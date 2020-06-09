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
            public int Number;
            public int Members;
            public Team(int n, int members)
            {
                Number = n;
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
            public int Number;
            public int FreeSeats;
            public Table(int n, int c)
            {
                Number = n;
                FreeSeats = c;
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
                            if (table.FreeSeats > 0)
                            {
                                if (team.Members > 0)
                                {
                                    table.FreeSeats--;
                                    team.Members--;
                                    totalMembers--;
                                    team.Seats.Add(table.Number);
                                }
                            }
                        }
                    }
                    if (totalMembers == 0)
                    {
                        Console.WriteLine(1);
                        teams.OrderBy(x => x.Number);
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
                 

